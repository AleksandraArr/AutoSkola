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
        public Polaznik Result { get; set; } = null!;
        public KreirajPolaznikSO(Polaznik polaznik) : base()
        {
            this.polaznik = polaznik;
        }

        public KreirajPolaznikSO(Polaznik polaznik, IBroker broker) : base(broker)
        {
            this.polaznik = polaznik;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (Polaznik)broker.Add(polaznik);
        }
    }
}
