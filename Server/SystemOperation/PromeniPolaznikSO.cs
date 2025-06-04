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
        public class PromeniPolaznikSO : SystemOperationBase
        {
            private readonly Polaznik polaznik;
            public Polaznik Result { get; set; }

            public PromeniPolaznikSO(Polaznik polaznik)
            {
                this.polaznik = polaznik;
            }

            protected override void ExecuteConcreteOperation()
            {
                Result = (Polaznik)broker.Update(polaznik);
            }
        }
}
