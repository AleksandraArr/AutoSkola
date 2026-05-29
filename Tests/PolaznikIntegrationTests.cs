using Common.Domain;
using DBBroker;
using Server.SystemOperation;

namespace Tests
{
    public class PolaznikIntegrationTests : IDisposable
    {
        private const string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AutoSkolaTest;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private Broker NoviBroker() => new Broker(ConnectionString);

        private readonly List<Polaznik> kreiraniPolaznici = new();

        private Polaznik NapraviPolaznika() => new Polaznik
        {
            Ime = "Jovan",
            Prezime = "Jovanovic",
            DatumRodjenja = new DateTime(2000, 5, 15),
            Telefon = "0601234567"
        };

        [Fact]
        [Trait("Category", "Integration")]
        public void KreirajPolaznikSO_DodeljenoId()
        {
            var polaznik = NapraviPolaznika();
            var so = new KreirajPolaznikSO(polaznik, NoviBroker());
            so.ExecuteTemplate();

            kreiraniPolaznici.Add(so.Result);

            Assert.True(so.Result.IdPolaznik > 0);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void KreirajPolaznikSO_PolaznikSacuvanUBazi()
        {
            var polaznik = NapraviPolaznika();
            var kreirajSO = new KreirajPolaznikSO(polaznik, NoviBroker());
            kreirajSO.ExecuteTemplate();
            kreiraniPolaznici.Add(kreirajSO.Result);

            var listaSO = new VratiListuSviPolaznikSO(NoviBroker());
            listaSO.ExecuteTemplate();

            Assert.Contains(listaSO.Result, p => p.IdPolaznik == kreirajSO.Result.IdPolaznik);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void ObrisiPolaznikSO_UklanjaPolaznikaIzBaze()
        {
            var polaznik = NapraviPolaznika();
            new KreirajPolaznikSO(polaznik, NoviBroker()).ExecuteTemplate();

            new ObrisiPolaznikSO(polaznik, NoviBroker()).ExecuteTemplate();

            var listaSO = new VratiListuSviPolaznikSO(NoviBroker());
            listaSO.ExecuteTemplate();

            Assert.DoesNotContain(listaSO.Result, p => p.IdPolaznik == polaznik.IdPolaznik);
        }

        public void Dispose()
        {
            foreach (var polaznik in kreiraniPolaznici)
            {
                try { new ObrisiPolaznikSO(polaznik, NoviBroker()).ExecuteTemplate(); }
                catch { }
            }
        }
    }
}
