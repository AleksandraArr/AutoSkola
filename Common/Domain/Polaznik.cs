using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Polaznik : IEntity
    {
        public int IdPolaznik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }

        public string TableName => "Polaznik";

        public string Values => $"'{Ime}', '{Prezime}', '{DatumRodjenja:yyyy-MM-dd}', '{Telefon}'";
        public string UpdateText => $"Ime = '{Ime}', Prezime = '{Prezime}', DatumRodjenja = '{DatumRodjenja:yyyy-MM-dd}', Telefon = '{Telefon}'";
        public string WhereCondition => $"IdPolaznik = {IdPolaznik}";
        public string IdColumn => $"IdPolaznik";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> polaznici = new List<IEntity>();
            while (reader.Read())
            {
                Polaznik p = new Polaznik
                {
                    IdPolaznik = (int)reader["idPolaznik"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    DatumRodjenja = (DateTime)reader["datumRodjenja"],
                    Telefon = (string)reader["telefon"]
                };
                polaznici.Add(p);
            }
            return polaznici;
        }

        public string ImeIPrezime
        {
            get { return Ime + " " + Prezime; }
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
        public void SetId(int id)
        {
            IdPolaznik = id;
        }
    }
}
