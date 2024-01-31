using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.GenericDto;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class Endpoint
    {
        public static void ConfigureEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("bands");

            group.MapGet("/", GetBands);
            group.MapGet("/{id}", GetABand);
            group.MapGet("/member/", GetBandMembers);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBands(IRepository repository)
        { 
            return TypedResults.Ok(await repository.Get());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetABand(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetBand(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBandMembers(IRepository repository)
        {
            //source data
            var entities = await repository.GetMembers(); //lazy load
     
            //response data
            List<BandMemberDto> members = new List<BandMemberDto>();
            
            //explicit transfer to build up response
            foreach (var entity in entities) 
            {
                var member = new BandMemberDto() 
                { 
                    Name = entity.Name,
                    Description = entity.Description,
                    Band= new BandDto() { 
                        Name= entity.Band.Name, 
                        Genre=entity.Band.Genre, 
                        Formed=entity.Band.Formed, 
                        MeembersCount=entity.Band.MembersCount 
                    } 
                };
                members.Add(member);
            }


            //Consider the Generic Response class called Payload... 
            //Here I could return the members directly but to keep a consistant response structue I could 
            //wrap in a the payload class and place results into the data property

            Payload<List<BandMemberDto>> result = new Payload<List<BandMemberDto>>();
            result.data = members;

            return TypedResults.Ok(result);
        }

    }
}
