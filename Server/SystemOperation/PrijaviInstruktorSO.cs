using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class PrijaviInstruktorSO : SystemOperationBase
    {
        private readonly Instruktor instruktor;
        public Instruktor Result { get; set; }

        public PrijaviInstruktorSO(Instruktor instruktor)
        {
            this.instruktor = instruktor;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"korisnickoIme = '{instruktor.KorisnickoIme}' AND sifra = '{instruktor.Sifra}'";

            
            List<IEntity> lista = broker.GetByCondition(instruktor, condition);

            
            if (lista == null || lista.Count == 0)
                throw new Exception("Korisničko ime i šifra nisu ispravni.");

            
            Result = lista.OfType<Instruktor>().FirstOrDefault();


            if (Result == null)
                throw new Exception("Korisničko ime i šifra nisu ispravni.");

        }
    }
}
