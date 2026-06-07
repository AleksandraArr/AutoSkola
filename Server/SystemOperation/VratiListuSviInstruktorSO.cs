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
        public VratiListuSviInstruktorSO() : base() { }
        public VratiListuSviInstruktorSO(IBroker broker) : base(broker) { }

        public List<Instruktor> Result { get; set; } = null!;

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Instruktor());

            Result = lista.Cast<Instruktor>().ToList();

        }
    }
}