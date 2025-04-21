namespace Domain.Entities;

/// <summary>Represents a monster.</summary>
/// <param name="Id">The monster's unique identifier.</param>
/// <param name="Name">The monster's name.</param>
/// <param name="Level">The monster's level.</param>
/// <param name="Health">The amount of total health the monster has.</param>
/// <param name="Alive">A flag indicating if the monster is alive.</param>
public record Monster(string Id, string Name, int Level, int Health, bool Alive = true);
