using Common.Domain;
using Server.SystemOperation;

namespace Tests
{
    public class InstruktorTests
    {
        private Instruktor NapraviInstruktora(int id = 0) => new Instruktor
        {
            IdInstruktor = id,
            Ime = "Marko",
            Prezime = "Markovic",
            DatumZaposlenja = new DateTime(2020, 1, 10),
            Telefon = "0611234567",
            KorisnickoIme = "mmarkovic",
            Sifra = "sifra123"
        };

        [Fact]
        public void WhereCondition_VracaIspravanUslov()
        {
            var instruktor = NapraviInstruktora(id: 5);
            Assert.Equal("IdInstruktor = 5", instruktor.WhereCondition);
        }

        [Fact]
        public void ImeIPrezime_SpajaNazive()
        {
            var instruktor = NapraviInstruktora();
            Assert.Equal("Marko Markovic", instruktor.ImeIPrezime);
        }

        [Fact]
        public void Values_SadrziIspravanFormatDatuma()
        {
            var instruktor = NapraviInstruktora();
            Assert.Contains("2020-01-10", instruktor.Values);
        }

        [Fact]
        public void VratiListuSviInstruktorSO_VracaPraznoKadaNemaInstruktora()
        {
            var broker = new InMemoryBroker();
            var so = new VratiListuSviInstruktorSO(broker);
            so.ExecuteTemplate();

            Assert.Empty(so.Result);
        }
    }
}
