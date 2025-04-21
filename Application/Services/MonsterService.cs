using Domain.Entities;

namespace Application.Services;

/// <inheritdoc cref="IMonsterService"/>
public class MonsterService : IMonsterService
{
    public static readonly List<Monster> _defaultMonsters =
    [
        new("bat", "Bat", 1, 20),
        new("adultbat", "Bat", 5, 30),
        new("goblin", "Goblin", 1, 25)
    ];

    public List<Monster> GetMonsters() => _defaultMonsters;

    public Monster? GetMonster(string id) => GetMonsters().FirstOrDefault(monster => monster.Id == id);

    public bool TryGetMonster(string id, out Monster? monster)
    {
        monster = GetMonster(id);
        return monster is not null;
    }
}
