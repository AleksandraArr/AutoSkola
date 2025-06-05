using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    
    public class KreirajPolaznikSO : SystemOperationBase
    {
        public Polaznik Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            // Result = (Polaznik)broker.Add(new Polaznik());
            Result = new Polaznik();
        }
    }
}
