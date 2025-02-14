namespace Models.Things;

using Interfaces;

public class Thing : IInventory
{
    public int Number { get; }
    public string Name { get; }
    public Thing(string name, int number)
    {
        Name = name;
        Number = number;
    }
}