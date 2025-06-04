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
    public class PretraziEvidencioniObrazacSO : SystemOperationBase
    {
        public List<EvidencioniObrazac> Result { get; set; }
        public EvidencioniObrazacKriterijumiDTO objs;
        public PretraziEvidencioniObrazacSO(EvidencioniObrazacKriterijumiDTO objs) { 
            this.objs = objs;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<string> conditions = new List<string>();
            string join = "";
            if (objs.Polaznik != null)
                conditions.Add($"IdPolaznik = {objs.Polaznik.IdPolaznik}");

            if (objs.Instruktor != null)
                conditions.Add($"IdInstruktor = {objs.Instruktor.IdInstruktor}");

            if (objs.Automobil != null)
            {
                join = $" JOIN Cas ON Cas.IdObrazac = EvidencioniObrazac.IdObrazac\r\n";
                conditions.Add($"IdAutomobil = {objs.Automobil.IdAutomobil}");
            }


            string condition = "";
            if (conditions.Count > 0)
                condition = string.Join(" AND ", conditions);
            else
                condition = "1=1";

            Debug.WriteLine(condition);
            List<IEntity> lista = broker.GetByCondition(new EvidencioniObrazac(), condition, join);

            Result = lista.Cast<EvidencioniObrazac>().ToList();
            Debug.WriteLine(Result[0]);
            if (Result == null)
                throw new Exception("Ne postoje evidencioni obrasci.");

        }
    }
}
