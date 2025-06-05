using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    
    public class KreirajEvidencioniObrazacSO : SystemOperationBase
    {
        private readonly EvidencioniObrazac obrazac;
        public EvidencioniObrazac Result { get; set; }
        public KreirajEvidencioniObrazacSO(EvidencioniObrazac obrazac) {
            this.obrazac = obrazac;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (EvidencioniObrazac)broker.Add(obrazac);
        }
    }
}
