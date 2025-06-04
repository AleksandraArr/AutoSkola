using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UbaciKategorijaVozackeSO : SystemOperationBase
    {
        private readonly KategorijaVozacke kategorijaVozacke;
        public UbaciKategorijaVozackeSO(KategorijaVozacke kategorijaVozacke)
        {
            this.kategorijaVozacke = kategorijaVozacke;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(kategorijaVozacke);
        }
    }
}
