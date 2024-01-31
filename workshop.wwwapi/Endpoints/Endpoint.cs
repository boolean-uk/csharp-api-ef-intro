using Microsoft.AspNetCore.Mvc;
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

            //var results = await repository.GetMembers();//lazy load (explicit loading 
            var results = new { data=await repository.GetMembers() };
            return TypedResults.Ok(results);
        }

    }
}
