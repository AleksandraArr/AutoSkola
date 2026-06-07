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
        public EvidencioniObrazac Result { get; set; } = null!;
        public KreirajEvidencioniObrazacSO(EvidencioniObrazac obrazac) : base()
        {
            this.obrazac = obrazac;
        }

        public KreirajEvidencioniObrazacSO(EvidencioniObrazac obrazac, IBroker broker) : base(broker)
        {
            this.obrazac = obrazac;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (EvidencioniObrazac)broker.Add(obrazac);
        }
    }
}
