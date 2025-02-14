namespace Services;

using Models.Animals;
class VeterinaryClinic
{
    public bool CheckHealth(Animal animal)
    {
        return animal.IsHealthy;
    }
}