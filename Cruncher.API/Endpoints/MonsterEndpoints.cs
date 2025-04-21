using API.Entities;
using Application.Services;
using Domain.Entities;

namespace API.Endpoints;

/// <summary>Extension members for adding monster endpoints to the application.</summary>
public static class MonsterEndpoints
{
    extension(WebApplication app)
    {
        /// <summary>Creates minimal API endpoints for monsters.</summary>
        /// <param name="app">The application to add endpoints to.</param>
        /// <returns>The <paramref name="app"/> for fluent chaining.</returns>
        public WebApplication AddMonsterEndpoints()
        {
            var monstersApi = app.MapGroup("/monsters");

            monstersApi.MapGet("/", ApiResult<List<Monster>> ([FromKeyedServices("monsterService")] IMonsterService monsterService) => monsterService.GetMonsters())
                .WithName("GetMonsters")
                .WithDescription("Gets all monsters.");

            monstersApi.MapGet("/{id}", ApiResult<Monster> ([FromKeyedServices("monsterService")] IMonsterService monsterService, string id) => monsterService.GetMonster(id))
                .WithName("GetMonsterById")
                .WithDescription("Gets a monster by identifier.");

            return app;
        }
    }
}
