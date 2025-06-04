using Common.Domain;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class ObrisiPolaznikSO : SystemOperationBase
    {
        private readonly Polaznik polaznik;

        public ObrisiPolaznikSO(Polaznik polaznik)
        {
            this.polaznik = polaznik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(polaznik);
        }
    }
}
