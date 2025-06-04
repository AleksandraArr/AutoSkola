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
    public class ObrisiEvidencioniObrazacSO : SystemOperationBase
    {
        private readonly EvidencioniObrazac obrazac;

        public ObrisiEvidencioniObrazacSO(EvidencioniObrazac obrazac)
        {
            this.obrazac = obrazac;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(obrazac);
        }
    }
}
