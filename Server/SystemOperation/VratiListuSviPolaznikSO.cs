using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class VratiListuSviPolaznikSO : SystemOperationBase
    {
        public VratiListuSviPolaznikSO() : base() { }
        public VratiListuSviPolaznikSO(IBroker broker) : base(broker) { }

        public List<Polaznik> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Polaznik());

            Result = lista.Cast<Polaznik>().ToList();

        }
    }
}
