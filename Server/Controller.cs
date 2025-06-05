using Common;
using Common.Domain;
using Common.DTO;
using DBBroker;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private Broker broker;

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if(instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new Broker(); }

       //INSTRUKTOR
        public Instruktor PrijaviInstruktor(Instruktor instruktor)
        {
            PrijaviInstruktorSO so = new PrijaviInstruktorSO(instruktor);
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<Instruktor> VratiListuSviInstruktor()
        {
            VratiListuSviInstruktorSO so = new VratiListuSviInstruktorSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        //KATEGORIJA VOZACKE
        public void UbaciKategorijaVozacke(KategorijaVozacke kategorija)
        {
            UbaciKategorijaVozackeSO so = new UbaciKategorijaVozackeSO(kategorija);
            so.ExecuteTemplate();
        }
        //POLAZNIK
        public Polaznik KreirajPolaznik() {
            KreirajPolaznikSO so = new KreirajPolaznikSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<Polaznik> VratiListuSviPolaznik()
        {
            VratiListuSviPolaznikSO so = new VratiListuSviPolaznikSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<Polaznik> VratiListuPolaznik(Polaznik polaznik)
        {
            VratiListuPolaznikSO so = new VratiListuPolaznikSO(polaznik);
            so.ExecuteTemplate();
            return so.Result;
        }
        public void ObrisiPolaznik(Polaznik polaznik)
        {
            ObrisiPolaznikSO so = new ObrisiPolaznikSO(polaznik);
            so.ExecuteTemplate();
        }
        public Polaznik PromeniPolaznik(Polaznik polaznik)
        {
            PromeniPolaznikSO so = new PromeniPolaznikSO(polaznik);
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<Polaznik> PretraziPolaznik(string tekst)
        {
            PretraziPolaznikSO so = new PretraziPolaznikSO(tekst);
            so.ExecuteTemplate();
            return so.Result;
        }
        //EVIDENCIONI OBRAZAC
        public EvidencioniObrazac KreirajEvidencioniObrazac()
        {
            KreirajEvidencioniObrazacSO so = new KreirajEvidencioniObrazacSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<EvidencioniObrazac> VratiListuSviEvidencioniObrazac()
        {
            VratiListuSviEvidencioniObrazacSO so = new VratiListuSviEvidencioniObrazacSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<EvidencioniObrazac> VratiListuEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            VratiListuEvidencioniObrazacSO so = new VratiListuEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
            return so.Result;
        }
        public List<EvidencioniObrazac> PretraziEvidencioniObrazac(EvidencioniObrazacKriterijumiDTO entities)
        {
            PretraziEvidencioniObrazacSO so = new PretraziEvidencioniObrazacSO(entities);
            so.ExecuteTemplate();
            return so.Result;
        }
        public EvidencioniObrazac PromeniEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            PromeniEvidencioniObrazacSO so = new PromeniEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
            return so.Result;
        }
        public void ObrisiEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            ObrisiEvidencioniObrazacSO so = new ObrisiEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
        }
        //AUTOMOBIL
        public List<Automobil> VratiListuSviAutomobil()
        {
            VratiListuSviAutomobilSO so = new VratiListuSviAutomobilSO();
            so.ExecuteTemplate();
            return so.Result;
        }
      
      
       
    }
}
