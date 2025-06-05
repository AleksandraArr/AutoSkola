using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    
    public class KreirajEvidencioniObrazacSO : SystemOperationBase
    {
        public EvidencioniObrazac Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            //Result = (EvidencioniObrazac)broker.Add(new EvidencioniObrazac()
            //{
            //    Instruktor = new Instruktor(),
            //    Polaznik = new Polaznik()
            //});
            Result = new EvidencioniObrazac() { 
                Instruktor = new Instruktor(),
                Polaznik = new Polaznik()
            };
        }
    }
}
