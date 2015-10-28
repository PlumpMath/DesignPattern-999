using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Creational
{
    public class Builder
    {
        public void Demonstrate()
        {
            var CarModels = new CarModel();
            CarModels.SetModel("Bmw");
            CarModels.SetWheels("4");

            var newObject = CarModels.Buid();

            Console.WriteLine($"the new car model {newObject.Model}");

        }


        public class CarModel
        {
            public string Model { get; set; }

            public string Wheels { get; set; }


            public void SetModel(string model)
            {
                Model = model;
            }

            public void SetWheels(string wheels)
            {
                Wheels = wheels;
            }

            public CarModel Buid()
            {
                return this;
            }
        }
    }
}
