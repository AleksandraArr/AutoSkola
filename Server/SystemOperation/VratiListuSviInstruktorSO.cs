using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class VratiListuSviInstruktorSO : SystemOperationBase
    {
        public List<Instruktor> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Instruktor());

            Result = lista.Cast<Instruktor>().ToList();

            if (Result == null)
                throw new Exception("Ne postoje instruktori.");

        }
    }
}