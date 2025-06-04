using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Povratnik : Polaznik
    {
        public int IdPolaznik { get; set; }
        public string BrojDozvole { get; set; }
        public DateTime DatumIstekaDozvole { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public string RazlogPovratka { get; set; }
        public int BrojKaznenihBodova { get; set; }

        public string TableName => "Povratnik";

        public string Values => $"'{BrojDozvole}', '{DatumIstekaDozvole:yyyy-MM-dd}', '{DatumPolaganja:yyyy-MM-dd}', '{RazlogPovratka}', '{BrojKaznenihBodova}'";
        public string UpdateText =>
            $"BrojDozvole = '{BrojDozvole}', " +
            $"DatumIstekaDozvole = '{DatumIstekaDozvole:yyyy-MM-dd}', " +
            $"DatumPolaganja = '{DatumPolaganja:yyyy-MM-dd}', " +
            $"RazlogPovratka = '{RazlogPovratka}', " +
            $"BrojKaznenihBodova = {BrojKaznenihBodova}";
        
        public string WhereCondition => $"IdPolaznik = {IdPolaznik}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> povratnici = new List<IEntity>();
            while (reader.Read())
            {
                Povratnik p = new Povratnik
                {
                    IdPolaznik = (int)reader["idPolaznik"],
                    BrojDozvole = reader["brojDozvole"].ToString(),
                    DatumIstekaDozvole = (DateTime)reader["datumIstekaDozvole"],
                    DatumPolaganja = (DateTime)reader["datumPolaganja"],
                    RazlogPovratka = reader["razlogPovratka"].ToString(),
                    BrojKaznenihBodova = (int)reader["brojKaznenihBodova"]
                };
                povratnici.Add(p);
            }
            return povratnici;
        }
    }
}
