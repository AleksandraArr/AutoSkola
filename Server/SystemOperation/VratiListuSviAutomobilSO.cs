using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class VratiListuSviAutomobilSO : SystemOperationBase
    {
        public List<Automobil> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Automobil());

            Result = lista.Cast<Automobil>().ToList();

            if (Result == null)
                throw new Exception("Ne postoje automobili.");

        }
    }
}
