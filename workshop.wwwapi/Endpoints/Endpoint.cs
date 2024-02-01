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
            


            var groupMembers = app.MapGroup("members");
            groupMembers.MapGet("/", GetBandMembers);
            groupMembers.MapPut("/", UpdateBandMember);

            var bandsGroup = app.MapGroup("bands");

            bandsGroup.MapGet("/", GetBands);
            bandsGroup.MapGet("/{id}", GetABand);

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBandMember(IRepository repository, int id, BandMemberPut model)
        {
            var entities = await repository.GetAllBands();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Band Member not found.");
            }
            var entity = await repository.GetMemberById(id);

            if (model.name != null)
            {
                if (entities.Any(x => x.Name == model.name))
                {
                    return Results.BadRequest("Product with provided name already exists");
                }
            }

            entity.Name = model.name != null ? model.name : entity.Name;
            entity.Description = model.description != null ? model.description : entity.Description;
       

            repository.UpdateBandMember(id, entity);

            return TypedResults.Created($"/{entity.Id}", entity);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBands(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetAllBands());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetABand(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetABand(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBandMembers(IRepository repository)
        {
            //source data
            var entities = await repository.GetAllBandMembers(); //lazy load
     
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
