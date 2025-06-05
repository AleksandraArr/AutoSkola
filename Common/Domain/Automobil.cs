using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Automobil : IEntity
    {
        public int IdAutomobil { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }
        public string RegistracioniBroj { get; set; }

        public string TableName => "Automobil";
        public string Values => $"'{Model}', {Godiste}, '{RegistracioniBroj}'";
        public string UpdateText => $"Model = '{Model}', Godiste = {Godiste}, RegistracioniBroj = '{RegistracioniBroj}'";
        public string WhereCondition => $"IdAutomobil = {IdAutomobil}";

        public string IdColumn => $"IdAutomobil";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> automobili = new List<IEntity>();
            while (reader.Read())
            {
                Automobil automobil = new Automobil
                {
                    IdAutomobil = (int)reader["idAutomobil"],
                    Model = (string)reader["model"],
                    Godiste = (int)reader["godiste"],
                    RegistracioniBroj = (string)reader["registracioniBroj"]
                };
                automobili.Add(automobil);
            }
            return automobili;
        }

        public void SetId(int id) {
            IdAutomobil = id;
        }
    }
}
