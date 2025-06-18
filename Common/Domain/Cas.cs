using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Cas : IEntity
    {
        public int IdCas { get; set; }
        public EvidencioniObrazac Obrazac { get; set; } = new EvidencioniObrazac();
        public DateTime Datum { get; set; }
        public int Trajanje { get; set; }
        public Automobil Automobil { get; set; } = new Automobil();

        public string TableName => "Cas";
        public string Values => $"{Obrazac.IdObrazac}, '{Datum:yyyy-MM-dd}', {Trajanje}, {Automobil.IdAutomobil}";
        public string UpdateText => $"IdObrazac = {Obrazac.IdObrazac}, Datum = '{Datum:yyyy-MM-dd}', Trajanje = {Trajanje}, IdAutomobil = {Automobil.IdAutomobil}";
        public string WhereCondition => $"IdCas = {IdCas}";
        public string IdColumn => $"IdCas";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> casovi = new List<IEntity>();
            while (reader.Read())
            {
                Debug.WriteLine($"idObrazac: {reader["idObrazac"]}, idCas: {reader["idCas"]}, datum: {reader["datum"]}, trajanje: {reader["trajanje"]}, idAutomobil: {reader["idAutomobil"]}");

                Cas cas = new Cas
                {
                    Obrazac = new EvidencioniObrazac { IdObrazac = (int)reader["idObrazac"] },
                    IdCas = (int)reader["idCas"],
                    Datum = (DateTime)reader["datum"],
                    Trajanje = (int)reader["trajanje"],
                    Automobil = new Automobil { IdAutomobil = (int)reader["idAutomobil"] }
                };
                casovi.Add(cas);
            }
            return casovi;
        }
        public void SetId(int id)
        {
            IdCas = id;
        }
    }
}
