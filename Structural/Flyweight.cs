using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{




    /// <summary>
    /// is defining the Intrinsict states of the Object
    /// </summary>
    public enum MoneyType
    {
        Metalic=1,
        Paper
    }


    /// <summary>
    /// Flyweight interface that provide the both states which are need for this DP
    /// </summary>
    public interface IMoney
    {
        /// <summary>
        /// stores the Intrinsict state of an object
        /// </summary>
        MoneyType moneyType { get; }

        /// <summary>
        /// providest the extrinsict state of an object
        /// </summary>
        /// <param name="moneyValue"></param>
        void GetFalledMoney(int moneyValue);
    }



    /// <summary>
    /// Concrete Flyweight immplementation from Flyweight Interface which will be used for different metal objects
    /// </summary>
    public class MetalMoney : IMoney
    {
        public MoneyType moneyType
        {
            get
            {
                return MoneyType.Metalic;
            }
        }

        public void GetFalledMoney(int moneyValue)
        {
            Console.WriteLine($"falling {moneyType.ToString()} with Value of {moneyValue}");
        }
    }


    /// <summary>
    /// Concrete flyweight immplementation for Paper money objects
    /// </summary>
    public class PaperMoney : IMoney
    {
        public MoneyType moneyType
        {
            get
            {
                return MoneyType.Paper;
            }
        }

        public void GetFalledMoney(int moneyValue)
        {
            Console.WriteLine($"flying {moneyType.ToString()} with value of {moneyValue}!!");
        }
    }



    /// <summary>
    /// Flyweight Object factory which is using both states and is counting the created objects
    /// </summary>
    public static class MoneyFacotry
    {
        public static int objectCounts = 0;

        static Dictionary<MoneyType, IMoney> _moneyOject;


       /// <summary>
       /// concrete factory of money object and manager of flyweight DP 
       /// </summary>
       /// <param name="moneytype"></param>
       /// <returns></returns>
        public static IMoney GetMoney(MoneyType moneytype)
        {
            if (_moneyOject == null)
                _moneyOject = new Dictionary<MoneyType, IMoney>();

            if (_moneyOject.ContainsKey(moneytype))
                return _moneyOject[moneytype];

            switch (moneytype)
            {
                case MoneyType.Metalic:
                    _moneyOject.Add(moneytype, new MetalMoney());
                    objectCounts++;
                    break;
                case MoneyType.Paper:
                    _moneyOject.Add(moneytype, new PaperMoney());
                    objectCounts++;
                    break;
                default:
                    break;
            }


            return _moneyOject[moneytype];
        }
    }


    public static class Flyweight
    {

        public static void Test()
        {
            int type = 1;           

            for(int value=0; value<1000;value++)
            {

                MoneyType mType = (MoneyType)type;

                var money= MoneyFacotry.GetMoney(mType);
                money.GetFalledMoney(value);

                if(type==1)
                {
                    type = 2;
                }
                else if(type==2)
                {
                    type = 1;
                }
                 
            }

            Console.WriteLine($"TotalCreated Objects are:{MoneyFacotry.objectCounts}");

        }
    }
}