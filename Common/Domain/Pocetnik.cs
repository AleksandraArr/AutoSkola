using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Pocetnik : Polaznik
    { 
        public int IdPolaznik { get; set; }
        public Boolean StrahOdVoznje { get; set; }
        public DateTime DatumIzdavanjaLekarskog { get; set; }
        public int BrojPoenaNaTeoriji { get; set; }
        public string TableName => "Pocetnik";
        public string Values => $"'{StrahOdVoznje}', '{DatumIzdavanjaLekarskog:yyyy-mm-dd}', '{BrojPoenaNaTeoriji}'";
        public string UpdateText =>
            $"StrahOdVoznje = '{StrahOdVoznje}', " +
            $"DatumIzdavanjaLekarskog = '{DatumIzdavanjaLekarskog:yyyy-MM-dd}', " +
            $"BrojPoenaNaTeoriji = {BrojPoenaNaTeoriji}";
        public string ColumnName => "IdPolaznik, StrahOdVoznje, DatumIzdavanjaLekarskog, BrojPoenaNaTeoriji";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> pocetnici = new List<IEntity>();
            while (reader.Read())
            {
                Pocetnik p = new Pocetnik
                {
                    IdPolaznik = (int)reader["idPolaznik"],
                    StrahOdVoznje = (Boolean)reader["strahOdVoznje"],
                    DatumIzdavanjaLekarskog = (DateTime)reader["datumIzdavanjaLekarskog"],
                    BrojPoenaNaTeoriji = (int)reader["brojPoenaNaTeoriji"]
                };
                pocetnici.Add(p);
            }
            return pocetnici;
        }
    }
}
