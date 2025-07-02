using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class EvidencioniObrazac : IEntity
    {
        public int IdObrazac { get; set; }
        public DateTime DatumPocetka { get; set; }
        public int BrojCasova { get; set; }
        public Instruktor? Instruktor { get; set; }
        public Polaznik? Polaznik { get; set; }
        public List<Cas> Casovi { get; set; }
        public string TableName => "EvidencioniObrazac";
        public string Values =>
            $"'{DatumPocetka:yyyy-MM-dd}', {BrojCasova}, " +
            $"{(Instruktor != null ? Instruktor.IdInstruktor.ToString() : "null")}, " +
            $"{(Polaznik != null ? Polaznik.IdPolaznik.ToString() : "null")}";

        public string UpdateText =>
            $"DatumPocetka = '{DatumPocetka:yyyy-MM-dd}', " +
            $"BrojCasova = {BrojCasova}, " +
            $"IdInstruktor = {(Instruktor != null ? Instruktor.IdInstruktor.ToString() : "null")}, " +
            $"IdPolaznik = {(Polaznik != null ? Polaznik.IdPolaznik.ToString() : "null")}";
        public string WhereCondition => $"IdObrazac = {IdObrazac}";
        public string IdColumn => $"IdObrazac";
        public string ColumnName => "e.IdObrazac, e.DatumPocetka, e.BrojCasova, e.IdInstruktor, e.IdPolaznik";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> obrasci = new List<IEntity>();
            while (reader.Read())
            {
                EvidencioniObrazac obrazac = new EvidencioniObrazac
                {
                    IdObrazac = (int)reader["idObrazac"],
                    DatumPocetka = (DateTime)reader["datumPocetka"],
                    BrojCasova = (int)reader["brojCasova"],
                    Instruktor = reader["idInstruktor"] != DBNull.Value
                    ? new Instruktor { IdInstruktor = (int)reader["idInstruktor"] }
                    : null,
                    Polaznik = reader["idPolaznik"] != DBNull.Value
                    ? new Polaznik { IdPolaznik = (int)reader["idPolaznik"] }
                    : null,
                };
                obrasci.Add(obrazac);
            }
            return obrasci;
        }
        public void SetId(int id)
        {
            IdObrazac = id;
        }
    }
}
