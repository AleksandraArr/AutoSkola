using Common.Domain;
using Server.SystemOperation;

namespace Tests
{
    public class EvidencioniObrazacTests
    {
        private EvidencioniObrazac NapraviObrazac(int id = 0) => new EvidencioniObrazac
        {
            IdObrazac = id,
            DatumPocetka = new DateTime(2024, 3, 1),
            BrojCasova = 10,
            Polaznik = new Polaznik { IdPolaznik = 1 },
            Instruktor = new Instruktor { IdInstruktor = 1 }
        };

        [Fact]
        public void KreirajEvidencioniObrazacSO_DodeljenoId()
        {
            var broker = new InMemoryBroker();
            var obrazac = NapraviObrazac();

            var so = new KreirajEvidencioniObrazacSO(obrazac, broker);
            so.ExecuteTemplate();

            Assert.True(so.Result.IdObrazac > 0);
        }

        [Fact]
        public void KreirajEvidencioniObrazacSO_ObrazacSacuvanUBrokeru()
        {
            var broker = new InMemoryBroker();
            var obrazac = NapraviObrazac();

            new KreirajEvidencioniObrazacSO(obrazac, broker).ExecuteTemplate();

            var lista = new VratiListuSviEvidencioniObrazacSO(broker);
            lista.ExecuteTemplate();

            Assert.Single(lista.Result);
            Assert.Equal(10, lista.Result[0].BrojCasova);
        }

        [Fact]
        public void ObrisiEvidencioniObrazacSO_UklanjaObrazacIzBrokera()
        {
            var broker = new InMemoryBroker();
            var obrazac = NapraviObrazac();

            new KreirajEvidencioniObrazacSO(obrazac, broker).ExecuteTemplate();
            new ObrisiEvidencioniObrazacSO(obrazac, broker).ExecuteTemplate();

            var lista = new VratiListuSviEvidencioniObrazacSO(broker);
            lista.ExecuteTemplate();

            Assert.Empty(lista.Result);
        }

        [Fact]
        public void PromeniEvidencioniObrazacSO_AzuriraBrojCasova()
        {
            var broker = new InMemoryBroker();
            var obrazac = NapraviObrazac();

            new KreirajEvidencioniObrazacSO(obrazac, broker).ExecuteTemplate();

            obrazac.BrojCasova = 20;
            var so = new PromeniEvidencioniObrazacSO(obrazac, broker);
            so.ExecuteTemplate();

            Assert.Equal(20, so.Result.BrojCasova);
        }
    }
}
