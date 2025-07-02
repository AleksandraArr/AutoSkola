using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class KategorijaVozacke : IEntity
    {
        public int IdKategorijaVozacke { get; set; }
        public string Kategorija { get; set; }
        public string JacinaMotora { get; set; }

        public string TableName => "KategorijaVozacke";
        public string Values => $"'{Kategorija}', '{JacinaMotora}'";
        public string UpdateText => $"Kategorija = '{Kategorija}',JacinaMotora = '{JacinaMotora}'";
        public string WhereCondition => $"IdKategorijaVozacke = {IdKategorijaVozacke}";
        public string IdColumn => $"IdKategorijaVozacke";
        public string ColumnName => "IdKategorijaVozacke, Kategorija, JacinaMotora";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> kategorije = new List<IEntity>();
            while (reader.Read())
            {
                KategorijaVozacke kategorija = new KategorijaVozacke
                {
                    IdKategorijaVozacke = (int)reader["idKategorijaVozacke"],
                    Kategorija = (string)reader["kategorija"],
                    JacinaMotora = (string)reader["jacinaMotora"]
                };
                kategorije.Add(kategorija);
            }
            return kategorije;
        }
        public void SetId(int id)
        {
            IdKategorijaVozacke = id;
        }
    }
}
