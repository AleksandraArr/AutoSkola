using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class EvidencioniObrazacKriterijumiDTO
    {
        public Polaznik Polaznik { get; set; }
        public Instruktor Instruktor { get; set; }
        public Automobil Automobil { get; set; }
    }
}
