namespace Models.Animals;


public class Herbo : Animal
{
    public int Kindness { get; }
    public Herbo(string name, int number, int food, int kindness) : base(name, number, food)
    {
        Kindness = kindness;
    }
}