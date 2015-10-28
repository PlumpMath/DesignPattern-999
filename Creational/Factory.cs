using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Creational
{
  public class Factory
    {
      public void Demonstrate()
      {
          ICar NewCar;

          Console.WriteLine("we are setting New Car as Ford");
            NewCar = new Ford();
          Console.WriteLine(NewCar.GetCarModel());
          

          Console.WriteLine("we are changin it to bmw");
            NewCar = new BMW();
            Console.WriteLine(NewCar.GetCarModel());
        }
    }


    public abstract class AbstractFactory
    {
        public static ICar CreateCar(int carID)
        {
            switch (carID)
            {
                case 1:
                {
                    return new Ford();
                }
                case 2:
                {
                    return new BMW();
                }
                default:
                {
                    return null;
                }   
            }
        }
    }

    public interface ICar
    {
        string GetCarModel();
    }


    public class Ford : ICar
    {
        public string GetCarModel()
        {
            return "Ford carr this is new ford";
        }

    }


    public class BMW:ICar
    {
        public string GetCarModel()
        {
            return "BMW Car is comming";
        }
    }
}
