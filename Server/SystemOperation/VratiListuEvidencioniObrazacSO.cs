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

            string condition = $"idObrazac = {obrazac.IdObrazac}";
            List<Cas> casovi = broker.GetByCondition(new Cas(),condition).Cast<Cas>().ToList();

            foreach (EvidencioniObrazac obrazac in obrasci) 
                obrazac.Casovi = casovi;
            
            Result = obrasci;
            if (Result == null)
                throw new Exception("Ne postoje evidencioni obrasci.");

        }
    }
}