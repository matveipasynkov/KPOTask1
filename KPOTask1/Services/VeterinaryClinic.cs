namespace Services;

using Models.Animals;

public class VeterinaryClinic
{
    public bool CheckHealth(Animal animal) => new Random().Next(2) == 0; // Случайное решение о здоровье
}