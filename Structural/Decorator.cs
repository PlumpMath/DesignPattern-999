using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{


    public  class DecoratorDP
    {

        public  void Demonstrate()
        {
            Pizza largeP = new LargePizza();
            largeP = new Cheese(largeP);
            largeP = new Papper(largeP);
            largeP = new Ham(largeP);

            var MidP = new MediumPizza();

            Console.WriteLine($" you have buyed {largeP.GetDescription()} with Price:{largeP.CalculateCost()}");
            Console.WriteLine($" you have buyed {MidP.Description} with Price:{MidP.CalculateCost()}");
          
        }
    }

    #region the Design Pattern



    /// <summary>
    /// Base component class
    /// </summary>
    public abstract class Pizza
    {
        public string Description { get; set; }

        public abstract string GetDescription();

        public abstract double CalculateCost();
    }

    /// <summary>
    /// Pizza Decorator
    /// </summary>
    public class PizzaDecorator : Pizza
    {
        protected Pizza _pizza;

        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost();
        }

        public override string GetDescription()
        {
            return _pizza.Description;
        }
    }

    #region concrete Decorator

    public class Cheese : PizzaDecorator
    {
        private string description = "Cheese";
        public Cheese(Pizza _pizza):base(_pizza)
        {
            
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.25;
        }

        public override string GetDescription()
        {
            return string.Format("{0} - {1}",_pizza.GetDescription(),description);
        }
    }

    public class Papper : PizzaDecorator
    {
        private string description = "Papper";
        public Papper(Pizza _pizza) : base(_pizza)
        {

        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 3.5;
        }

        public override string GetDescription()
        {
            return string.Format("{0} - {1}", _pizza.GetDescription(), description);
        }
    }

    public class Ham : PizzaDecorator
    {
        private string description = "Ham";
        public Ham(Pizza _pizza) : base(_pizza)
        {

        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 0.65;
        }

        public override string GetDescription()
        {
            return string.Format("{0} - {1}", _pizza.GetDescription(), description);
        }
    }


    #endregion 


    #region Concrete component immplementation

    public class SmallPizza : Pizza
    {
        public SmallPizza()
        {
            this.Description = "Small Pizza";
        }

        public override double CalculateCost()
        {
            return 3.00;
        }

        public override string GetDescription()
        {
            return this.Description;
        }
    }


    public class MediumPizza : Pizza
    {
        public MediumPizza()
        {
            this.Description = "Medium Pizza";
        }

        public override double CalculateCost()
        {
            return 5.00;
        }

        public override string GetDescription()
        {
            return this.Description;
        }
    }

    public class LargePizza : Pizza
    {
        public LargePizza()
        {
            this.Description = "Large Pizza";
        }

        public override double CalculateCost()
        {
            return 10.00;
        }

        public override string GetDescription()
        {
            return this.Description;
        }
    }

    #endregion

    #endregion

}
