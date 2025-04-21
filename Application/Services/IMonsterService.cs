using Domain.Entities;

namespace Application.Services;

/// <summary>Responsible for getting one or many monsters.</summary>
public interface IMonsterService
{
    /// <summary>Gets all monsters.</summary>
    /// <returns>A collection of all monsters.</returns>
    List<Monster> GetMonsters();

    /// <summary>Gets a monster by it's identifier.</summary>
    /// <param name="id">The identifier to use when getting the monster.</param>
    /// <returns>A monster, defaults to <see langword="null"/>.</returns>
    Monster? GetMonster(string id);

    /// <summary>Tries to get a monster, and returns the status of the attempt.</summary>
    /// <param name="id">The identifier to use when getting the monster.</param>
    /// <param name="monster">The monster that is found, defaults to <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the monster was found, <see langword="false"/> otherwise.</returns>
    bool TryGetMonster(string id, out Monster? monster);
}
