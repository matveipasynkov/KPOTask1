namespace Services;

using Models.Animals;
public class VeterinaryClinic
{
    public bool CheckHealth(Animal animal)
    {
        return animal.IsHealthy;
    }
}