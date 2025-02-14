namespace Models.Animals;

using Interfaces;

public abstract class Animal : IAlive, IInventory
{
    public int Food { get; protected set; }
    public int Number { get; }
    public string Name { get; }

    protected Animal(string name, int number, int food)
    {
        Name = name;
        Number = number;
        Food = food;
    }
}
