using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
  public class Decorator
    {
    }


    public abstract class BakeryComponent
    {
        public abstract string GetName();
        public abstract double GetPrice();

    }

    public class  CackeBase:BakeryComponent
    {
        private string _cackeName = "Base Cakce";
        private double _cackePrice = 12;

        public override string GetName()
        {
            return _cackeName;
        }

        public override double GetPrice()
        {
            return _cackePrice;
        }
    }


    public abstract class Decorator : BakeryComponent
    {


        
    }
}
