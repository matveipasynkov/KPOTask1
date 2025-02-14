namespace KPOTask1Test;

using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using Models;
using Models.Animals;
using Models.Things;
using Services;
public class ZooTests
{
    [Fact]
    public void AddAnimal_HealthyAnimal_ShouldBeAdded()
    {
        var mockClinic = new Mock<VeterinaryClinic>();
        mockClinic.Setup(c => c.CheckHealth(It.IsAny<Animal>())).Returns(true);
        var zoo = new Zoo(mockClinic.Object);
        var animal = new Rabbit { Name = "Багз", Food = 5, IsHealthy = true, Number = 1234, Kindness = 7 };

        zoo.AddAnimal(animal);
        
        Assert.Contains(animal, zoo.GetAnimals());
    }

    [Fact]
    public void AddAnimal_UnhealthyAnimal_ShouldNotBeAdded()
    {
        var mockClinic = new Mock<VeterinaryClinic>();
        mockClinic.Setup(c => c.CheckHealth(It.IsAny<Animal>())).Returns(false);
        var zoo = new Zoo(mockClinic.Object);
        var animal = new Rabbit { Name = "Багз", Food = 5, IsHealthy = false, Number = 1234, Kindness = 7 };

        zoo.AddAnimal(animal);
        
        Assert.DoesNotContain(animal, zoo.GetAnimals());
    }

    [Fact]
    public void AddThing_ShouldBeAddedToInventory()
    {
        var mockClinic = new Mock<VeterinaryClinic>();
        var zoo = new Zoo(mockClinic.Object);
        var table = new Table { Name = "Стол", Number = 5678 };
        
        zoo.AddThing(table);
        
        Assert.Contains(table, zoo.GetInventory());
    }

    [Fact]
    public void FoodReport_ShouldReturnCorrectTotal()
    {
        var mockClinic = new Mock<VeterinaryClinic>();
        var zoo = new Zoo(mockClinic.Object);
        var animal1 = new Rabbit { Name = "Багз", Food = 5, IsHealthy = true, Number = 1234, Kindness = 7 };
        var animal2 = new Tiger { Name = "Шерхан", Food = 10, IsHealthy = true, Number = 5678 };

        zoo.AddAnimal(animal1);
        zoo.AddAnimal(animal2);
        
        Assert.Equal(15, zoo.GetTotalFoodConsumption());
    }
}
