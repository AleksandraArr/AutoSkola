using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Instruktor : IEntity
    {
        public int IdInstruktor { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public string TableName => "Instruktor";

        public string Values => $"'{Ime}', '{Prezime}', '{DatumZaposlenja:yyyy-MM-dd}', '{Telefon}', '{KorisnickoIme}','{Sifra}'";
        public string UpdateText => $"Ime = '{Ime}', Prezime = '{Prezime}', DatumZaposlenja = '{DatumZaposlenja:yyyy-MM-dd}', Telefon = '{Telefon}', KorisnickoIme = '{KorisnickoIme}', Sifra = '{Sifra}'";
        public string WhereCondition => $"IdInstruktor = {IdInstruktor}";
        public string IdColumn => $"IdInstruktor";
        public string ColumnName => "IdInstruktor, Ime, Prezime, DatumZaposlenja, Telefon, KorisnickoIme, Sifra";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> instruktori = new List<IEntity>();
            while (reader.Read())
            {
                Instruktor instruktor = new Instruktor
                {
                    IdInstruktor = (int)reader["idInstruktor"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    DatumZaposlenja = DateTime.Parse(reader["datumZaposlenja"].ToString()),
                    Telefon = (string)reader["telefon"]
                };
                instruktori.Add(instruktor);
            }
            return instruktori;
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
            IdInstruktor = id;
        }
    }
}
