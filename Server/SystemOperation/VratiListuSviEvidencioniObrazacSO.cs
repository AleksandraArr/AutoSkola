using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class VratiListuSviEvidencioniObrazacSO : SystemOperationBase
    {
        public VratiListuSviEvidencioniObrazacSO() : base() { }
        public VratiListuSviEvidencioniObrazacSO(IBroker broker) : base(broker) { }

        public List<EvidencioniObrazac> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new EvidencioniObrazac());

            Result = lista.Cast<EvidencioniObrazac>().ToList();

            if (Result == null)
                throw new InvalidOperationException("Ne postoje evidencioni obrasci.");

        }
    }
}
