using Common.Domain;
using Server.SystemOperation;

namespace Tests
{
    public class AutomobilTests
    {
        private Automobil NapraviAutomobil(int id = 0) => new Automobil
        {
            IdAutomobil = id,
            Model = "Volkswagen Golf",
            Godiste = 2019,
            RegistracioniBroj = "NS-123-AB"
        };

        [Fact]
        public void WhereCondition_VracaIspravanUslov()
        {
            var automobil = NapraviAutomobil(id: 2);
            Assert.Equal("IdAutomobil = 2", automobil.WhereCondition);
        }

        [Fact]
        public void Values_SadrziIspravneVrednosti()
        {
            var automobil = NapraviAutomobil();
            Assert.Contains("Volkswagen Golf", automobil.Values);
            Assert.Contains("2019", automobil.Values);
            Assert.Contains("NS-123-AB", automobil.Values);
        }

        [Fact]
        public void VratiListuSviAutomobilSO_VracaPraznoKadaNemaAutomobila()
        {
            var broker = new InMemoryBroker();
            var so = new VratiListuSviAutomobilSO(broker);
            so.ExecuteTemplate();

            Assert.Empty(so.Result);
        }
    }
}
