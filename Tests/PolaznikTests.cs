using Common.Domain;
using Server.SystemOperation;

namespace Tests
{
    public class PolaznikTests
    {
        private Polaznik NapraviPolaznika(int id = 0) => new Polaznik
        {
            IdPolaznik = id,
            Ime = "Jovan",
            Prezime = "Jovanovic",
            DatumRodjenja = new DateTime(2000, 5, 15),
            Telefon = "0601234567"
        };

        [Fact]
        public void WhereCondition_VracaIspravanUslov()
        {
            var polaznik = NapraviPolaznika(id: 3);
            Assert.Equal("IdPolaznik = 3", polaznik.WhereCondition);
        }

        [Fact]
        public void Values_SadrziIspravanFormatDatuma()
        {
            var polaznik = NapraviPolaznika();
            Assert.Contains("2000-05-15", polaznik.Values);
        }

        [Fact]
        public void ImeIPrezime_SpajaNazive()
        {
            var polaznik = NapraviPolaznika();
            Assert.Equal("Jovan Jovanovic", polaznik.ImeIPrezime);
        }

        [Fact]
        public void KreirajPolaznikSO_DodeljenoId()
        {
            var broker = new InMemoryBroker();
            var polaznik = NapraviPolaznika();

            var so = new KreirajPolaznikSO(polaznik, broker);
            so.ExecuteTemplate();

            Assert.True(so.Result.IdPolaznik > 0);
        }

        [Fact]
        public void KreirajPolaznikSO_PolaznikSacuvanUBrokeru()
        {
            var broker = new InMemoryBroker();
            var polaznik = NapraviPolaznika();

            var so = new KreirajPolaznikSO(polaznik, broker);
            so.ExecuteTemplate();

            var lista = new VratiListuSviPolaznikSO(broker);
            lista.ExecuteTemplate();

            Assert.Single(lista.Result);
            Assert.Equal("Jovan", lista.Result[0].Ime);
        }

        [Fact]
        public void ObrisiPolaznikSO_UklanjaPolaznikaIzBrokera()
        {
            var broker = new InMemoryBroker();
            var polaznik = NapraviPolaznika();

            new KreirajPolaznikSO(polaznik, broker).ExecuteTemplate();
            new ObrisiPolaznikSO(polaznik, broker).ExecuteTemplate();

            var lista = new VratiListuSviPolaznikSO(broker);
            lista.ExecuteTemplate();

            Assert.Empty(lista.Result);
        }

        [Fact]
        public void PromeniPolaznikSO_AzuriraPodatke()
        {
            var broker = new InMemoryBroker();
            var polaznik = NapraviPolaznika();

            new KreirajPolaznikSO(polaznik, broker).ExecuteTemplate();

            polaznik.Ime = "Petar";
            var so = new PromeniPolaznikSO(polaznik, broker);
            so.ExecuteTemplate();

            Assert.Equal("Petar", so.Result.Ime);
        }
    }
}
