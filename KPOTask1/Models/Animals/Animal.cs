namespace Models.Animals;

using Interfaces;

public abstract class Animal : IAlive, IInventory
{
    public required string? Name { get; set; }
    public int Food { get; set; }
    public int Number { get; set; }
    public bool IsHealthy { get; set; }
}