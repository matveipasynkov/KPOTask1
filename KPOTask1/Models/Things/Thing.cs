namespace Models.Things;

using Interfaces;

class Thing : IInventory
{
    public required string Name { get; set; }
    public int Number { get; set; }
}