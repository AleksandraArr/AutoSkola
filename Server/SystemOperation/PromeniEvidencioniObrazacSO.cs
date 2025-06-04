using Common.Domain;
using DBBroker;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class PromeniEvidencioniObrazacSO : SystemOperationBase
    {
        private readonly EvidencioniObrazac obrazac;
        public EvidencioniObrazac Result { get; set; }

        public PromeniEvidencioniObrazacSO(EvidencioniObrazac obrazac)
        {
            this.obrazac = obrazac;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (EvidencioniObrazac)broker.Update(obrazac);
        }
    }
}
