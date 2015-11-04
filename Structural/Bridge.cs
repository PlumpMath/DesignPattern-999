using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
    public class Bridge
    {
        /*

            ### Bridge DEsighn Pattern:

            ### Description:  this patter decauple the object of his immplementation
             
            ### Differance between Adapter and Bridge DP:
                    are that  Adapter is used to make things working after they are immplemented  and Bridge DP is to make things working before they are created

    */
        public void Demonstrate()
        {

            BaseCarManager carManager = new RefinedCarManager();
            carManager.CurrentCar = new Bmw();
            carManager.getCarType();

            carManager.CurrentCar = new Mercedes();
            carManager.getCarType();
        }
    }



    public class BaseCarManager
    {

        protected Car currentCat;

        public Car CurrentCar
        {
            set { currentCat = value; }
        }

        public virtual void getCarType()
        {
            currentCat.CarType();
        }
    }


    public class RefinedCarManager : BaseCarManager
    {
        public override void getCarType()
        {
            currentCat.CarType();
        }
    }

    public abstract class Car
    {
        public abstract void CarType();

    }


    public class Bmw : Car
    {
        public override void CarType()
        {
            Console.WriteLine("this car is BMW");
        }
    }

    public class Mercedes : Car
    {
        public override void CarType()
        {
            Console.WriteLine("this car is Mercedes");
        }
    }

}
