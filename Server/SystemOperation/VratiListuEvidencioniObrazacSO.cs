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
            List<EvidencioniObrazac> obrasci = broker.Get(obrazac).Cast<EvidencioniObrazac>().ToList();

            List<Cas> casovi = broker.GetByCondition(new Cas(),obrazac.WhereCondition).Cast<Cas>().ToList();

            foreach (EvidencioniObrazac o in obrasci)
                o.Casovi = casovi;
            
            Result = obrasci;
            if (Result == null)
                throw new InvalidOperationException("Ne postoje evidencioni obrasci.");

        }
    }
}