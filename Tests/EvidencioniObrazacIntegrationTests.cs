using Common.Domain;
using DBBroker;
using Server.SystemOperation;

namespace Tests
{
    public class EvidencioniObrazacIntegrationTests : IDisposable
    {
        private const string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AutoSkolaTest;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private Broker NoviBroker() => new Broker(ConnectionString);

        private readonly List<EvidencioniObrazac> kreiraniObrasci = new();

        private EvidencioniObrazac NapraviObrazac() => new EvidencioniObrazac
        {
            DatumPocetka = new DateTime(2024, 3, 1),
            BrojCasova = 10
        };

        [Fact]
        [Trait("Category", "Integration")]
        public void KreirajEvidencioniObrazacSO_DodeljenoId()
        {
            var obrazac = NapraviObrazac();
            var so = new KreirajEvidencioniObrazacSO(obrazac, NoviBroker());
            so.ExecuteTemplate();

            kreiraniObrasci.Add(so.Result);

            Assert.True(so.Result.IdObrazac > 0);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void KreirajEvidencioniObrazacSO_ObrazacSacuvanUBazi()
        {
            var obrazac = NapraviObrazac();
            var kreirajSO = new KreirajEvidencioniObrazacSO(obrazac, NoviBroker());
            kreirajSO.ExecuteTemplate();
            kreiraniObrasci.Add(kreirajSO.Result);

            var listaSO = new VratiListuSviEvidencioniObrazacSO(NoviBroker());
            listaSO.ExecuteTemplate();

            Assert.Contains(listaSO.Result, o => o.IdObrazac == kreirajSO.Result.IdObrazac);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void ObrisiEvidencioniObrazacSO_UklanjaObrazacIzBaze()
        {
            var obrazac = NapraviObrazac();
            new KreirajEvidencioniObrazacSO(obrazac, NoviBroker()).ExecuteTemplate();

            new ObrisiEvidencioniObrazacSO(obrazac, NoviBroker()).ExecuteTemplate();

            var listaSO = new VratiListuSviEvidencioniObrazacSO(NoviBroker());
            listaSO.ExecuteTemplate();

            Assert.DoesNotContain(listaSO.Result, o => o.IdObrazac == obrazac.IdObrazac);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void PromeniEvidencioniObrazacSO_AzuriraBrojCasovaUBazi()
        {
            var obrazac = NapraviObrazac();
            new KreirajEvidencioniObrazacSO(obrazac, NoviBroker()).ExecuteTemplate();
            kreiraniObrasci.Add(obrazac);

            obrazac.BrojCasova = 20;
            var so = new PromeniEvidencioniObrazacSO(obrazac, NoviBroker());
            so.ExecuteTemplate();

            Assert.Equal(20, so.Result.BrojCasova);
        }

        public void Dispose()
        {
            foreach (var obrazac in kreiraniObrasci)
            {
                try { new ObrisiEvidencioniObrazacSO(obrazac, NoviBroker()).ExecuteTemplate(); }
                catch { }
            }
        }
    }
}
