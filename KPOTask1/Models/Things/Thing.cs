namespace Models.Things;

using Interfaces;

public class Thing : IInventory
{
    public required string Name { get; set; }
    public int Number { get; set; }
}