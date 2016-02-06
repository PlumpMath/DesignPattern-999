using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.behaviour
{
    public class ChainOFResponsabillity
    {
        public void Test()
        {

            var laonA = new loanRequest { Amount =10, Customer = "Ivan"};
            var laonb = new loanRequest { Amount = 1000, Customer = "bab" };
            var laoni = new loanRequest { Amount = 100000, Customer = "sad" };


            var manager = new Manager { Name = "aaa" ,  Succsessor = null};
            var casier = new casier {Name = "asda", Succsessor = manager};
            
            casier.HandlerRequest(laonA);
            casier.HandlerRequest(laonb);
            casier.HandlerRequest(laoni);
        } 
    }


    public class loanRequest
    {
        public string Customer { get; set; }  

        public decimal Amount { get; set; }
    }


    public interface IRequestHandler
    {
        string Name { get; set; }
        void HandlerRequest(loanRequest req);
        IRequestHandler Succsessor { get; set; }

    }


    public class casier : IRequestHandler
    {
        public string Name { get; set; }
        public void HandlerRequest(loanRequest req)
        {
            if(req.Amount <10000)
                Console.WriteLine("Loan was apporved");
            else
            {
               Succsessor.HandlerRequest(req);
            }

        }

        public IRequestHandler Succsessor { get; set; }
    }


    public class Manager:IRequestHandler
    {
        public string Name { get; set; }
        public void HandlerRequest(loanRequest req)
        {
           if(req.Amount>10000)
               Console.WriteLine("Loan was approved by manager");
        }

        public IRequestHandler Succsessor { get; set; }
    }
}
