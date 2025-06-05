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
        private readonly Polaznik polaznik;
        public Polaznik Result { get; set; }
        public KreirajPolaznikSO(Polaznik polaznik)
        {
            this.polaznik = polaznik;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (Polaznik)broker.Add(polaznik);
        }
    }
}
