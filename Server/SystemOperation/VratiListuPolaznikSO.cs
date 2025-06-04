using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class VratiListuPolaznikSO : SystemOperationBase
    {

        private readonly Polaznik polaznik;
        public VratiListuPolaznikSO(Polaznik polaznik)
        {
            this.polaznik = polaznik;
        }
        public List<Polaznik> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.Get(polaznik);

            Result = lista.Cast<Polaznik>().ToList();

            if (Result == null)
                throw new Exception("Ne postoje polaznici.");

        }
    }
}
