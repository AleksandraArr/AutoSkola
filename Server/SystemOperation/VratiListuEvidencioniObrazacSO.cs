using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class VratiListuEvidencioniObrazacSO : SystemOperationBase
    {
        private readonly EvidencioniObrazac obrazac;
        public List<EvidencioniObrazac> Result { get; set; }
        public VratiListuEvidencioniObrazacSO(EvidencioniObrazac obrazac)
        {
            this.obrazac = obrazac;
        }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.Get(obrazac);

            
            Result = lista.Cast<EvidencioniObrazac>().ToList();

            if (Result == null)
                throw new Exception("Ne postoje evidencioni obrasci.");

        }
    }
}