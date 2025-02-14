namespace Services;

using Models.Animals;
using Models.Things;
using Interfaces;

public class Zoo
{
    private List<Animal> animals = new List<Animal>();
    private List<Thing> inventory = new List<Thing>();
    private VeterinaryClinic clinic;

    public Zoo(VeterinaryClinic clinic)
    {
        this.clinic = clinic;
    }

    public void AddAnimal(Animal animal)
    {
        if (clinic.CheckHealth(animal))
        {
            animals.Add(animal);
            Console.WriteLine($"{animal.Name} добавлено в зоопарк.");
        }
        else
        {
            Console.WriteLine($"{animal.Name} не прошло проверку здоровья.");
        }
    }

    public void AddThing(Thing thing)
    {
        inventory.Add(thing);
        Console.WriteLine($"{thing.Name} добавлено в инвентарь.");
    }

    public void ListAnimals()
    {
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name} - {animal.Food} кг еды/сутки");
        }
    }

    public List<Animal> GetAnimals() {
        return new List<Animal>(animals);
    }

    public List<Thing> GetInventory() {
        return new List<Thing>(inventory);
    }

    public int GetTotalFoodConsumption() {
        int totalFood = 0;
        foreach (var animal in animals)
        {
            totalFood += animal.Food;
        }
        return totalFood;
    }

    public void FoodReport()
    {
        int totalFood = 0;
        foreach (var animal in animals)
        {
            totalFood += animal.Food;
        }
        Console.WriteLine($"Общее потребление пищи: {totalFood} кг/сутки");
    }

    public void ContactZooAnimals()
    {
        foreach (var animal in animals)
        {
            if (animal is Herbo herbo && herbo.Kindness > 5)
            {
                Console.WriteLine($"{animal.Name} может участвовать в контактном зоопарке");
            }
        }
    }

    public void InventoryReport()
    {
        foreach (var thing in inventory)
        {
            Console.WriteLine($"{thing.Name} - Инвентарный номер: {thing.Number}");
        }
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name} - Инвентарный номер: {animal.Number}");
        }
    }
}