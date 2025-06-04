using Common.Domain;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class PretraziPolaznikSO : SystemOperationBase
    {
        public List<Polaznik> Result { get; set; }
        public string tekst;
        public PretraziPolaznikSO(string tekst) { 
            this.tekst = tekst;
        }

        protected override void ExecuteConcreteOperation()
        {
            Polaznik polaznik = new Polaznik();

            string safeTekst = tekst.Replace("'", "''").Trim();

            if (string.IsNullOrEmpty(safeTekst))
            {
                Result = new List<Polaznik>();
                return;
            }

            string condition = $"Ime LIKE '%{safeTekst}%' OR Prezime LIKE '%{safeTekst}%' OR (Ime + ' ' + Prezime) LIKE '%{safeTekst}%'";
            Debug.WriteLine(condition);
            List<IEntity> lista = broker.GetByCondition(polaznik, condition);

            Result = lista.Cast<Polaznik>().ToList();

            if (Result == null)
                throw new Exception("Ne postoje evidencioni obrasci.");

        }
    }
}
