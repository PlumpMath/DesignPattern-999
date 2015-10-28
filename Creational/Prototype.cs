
using System;

namespace designPatterns.Creational
{
   public class Prototype
    {

       public void Demonstrate()
       {
           var car1 = new Car { Name = "Car1"};

           Console.WriteLine($"car 1 is created with car1...");
           var car2 = car1.Clone();

           Console.WriteLine($"car 2 was prototyped from car 1 and have Name={car2.Name}");

           Console.WriteLine("car 2 name is setted to test");
           car2.Name = "test";

           Console.WriteLine($"the Car 1 Name is {car1.Name} and Car 2 Name is {car2.Name}");
       }
            
    }

    public class Car
    {
        public string Name { get; set; }

        public Car Clone()
        {
            return (Car) this.MemberwiseClone();
        }
 
    }
}
