using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Models.Animals;
using Models.Things;
using Services;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<VeterinaryClinic>();
        services.AddSingleton<Zoo>();
        var provider = services.BuildServiceProvider();

        var zoo = provider.GetRequiredService<Zoo>();
        zoo.AddAnimal(new Monkey(1));
        zoo.AddAnimal(new Tiger(2));
        zoo.AddThing(new Table(100));
        
        zoo.PrintReport();
        zoo.ListInteractiveAnimals();
        zoo.ListInventory();
    }
}
