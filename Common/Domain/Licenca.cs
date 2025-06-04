using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Licenca : IEntity
    {
        public int IdLicenca { get; set; }
        public Instruktor Instruktor { get; set; }
        public KategorijaVozacke KategorijaVozacke { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime DatumIsteka { get; set; }

        public string TableName => "Licenca";
        public string Values => $"{Instruktor.IdInstruktor}, {KategorijaVozacke.IdKategorijaVozacke}, '{DatumIzdavanja:yyyy-MM-dd}', '{DatumIsteka:yyyy-MM-dd}'";
        public string UpdateText =>
            $"IdInstruktor = {Instruktor.IdInstruktor}, " +
            $"IdKategorijaVozacke = {KategorijaVozacke.IdKategorijaVozacke}, " +
            $"DatumIzdavanja = '{DatumIzdavanja:yyyy-MM-dd}', " +
            $"DatumIsteka = '{DatumIsteka:yyyy-MM-dd}'";

        public string WhereCondition => $"IdLicenca = {IdLicenca}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> licence = new List<IEntity>();
            while (reader.Read())
            {
                Licenca licenca = new Licenca
                {
                    IdLicenca = (int)reader["idLicenca"],
                    Instruktor = new Instruktor { IdInstruktor = (int)reader["idInstruktor"] },
                    KategorijaVozacke = new KategorijaVozacke { IdKategorijaVozacke = (int)reader["idKategorijaVozacke"] },
                    DatumIzdavanja = (DateTime)reader["datumIzdavanja"],
                    DatumIsteka = (DateTime)reader["datumIsteka"]
                };
                licence.Add(licenca);
            }
            return licence;
        }
    }
}
