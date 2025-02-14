namespace Services;

using Models.Animals;
using Models.Things;
using Interfaces;

public class Zoo
{
    private List<IInventory> inventory = new();
    private VeterinaryClinic clinic;
    
    public Zoo(VeterinaryClinic clinic)
    {
        this.clinic = clinic;
    }
    
    public void AddAnimal(Animal animal)
    {
        if (clinic.CheckHealth(animal))
        {
            inventory.Add(animal);
            Console.WriteLine($"{animal.Name} принят в зоопарк!");
        }
        else
        {
            Console.WriteLine($"{animal.Name} не прошел проверку здоровья!");
        }
    }
    
    public void AddThing(Thing thing)
    {
        inventory.Add(thing);
    }
    
    public void PrintReport()
    {
        int totalFood = inventory.OfType<IAlive>().Sum(a => a.Food);
        Console.WriteLine($"Всего животных: {inventory.OfType<Animal>().Count()} \nПотребление еды: {totalFood} кг/день");
    }
    
    public void ListInteractiveAnimals()
    {
        var interactive = inventory.OfType<Herbo>().Where(h => h.Kindness > 5);
        Console.WriteLine("Животные для контактного зоопарка:");
        foreach (var animal in interactive)
        {
            Console.WriteLine(animal.Name);
        }
    }
    
    public void ListInventory()
    {
        Console.WriteLine("Инвентаризация зоопарка:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.GetType().Name} - Инв. номер: {item.Number}");
        }
    }
}
