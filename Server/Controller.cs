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
        private static Controller instance = null!;
        public static Controller Instance
        {
            get
            {
                if(instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { }

       //INSTRUKTOR
        public static Instruktor PrijaviInstruktor(Instruktor instruktor)
        {
            PrijaviInstruktorSO so = new PrijaviInstruktorSO(instruktor);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<Instruktor> VratiListuSviInstruktor()
        {
            VratiListuSviInstruktorSO so = new VratiListuSviInstruktorSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        //KATEGORIJA VOZACKE
        public static void UbaciKategorijaVozacke(KategorijaVozacke kategorija)
        {
            UbaciKategorijaVozackeSO so = new UbaciKategorijaVozackeSO(kategorija);
            so.ExecuteTemplate();
        }
        //POLAZNIK
        public static Polaznik KreirajPolaznik(Polaznik polaznik) {
            KreirajPolaznikSO so = new KreirajPolaznikSO(polaznik);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<Polaznik> VratiListuSviPolaznik()
        {
            VratiListuSviPolaznikSO so = new VratiListuSviPolaznikSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<Polaznik> VratiListuPolaznik(Polaznik polaznik)
        {
            VratiListuPolaznikSO so = new VratiListuPolaznikSO(polaznik);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static void ObrisiPolaznik(Polaznik polaznik)
        {
            ObrisiPolaznikSO so = new ObrisiPolaznikSO(polaznik);
            so.ExecuteTemplate();
        }
        public static Polaznik PromeniPolaznik(Polaznik polaznik)
        {
            PromeniPolaznikSO so = new PromeniPolaznikSO(polaznik);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<Polaznik> PretraziPolaznik(string tekst)
        {
            PretraziPolaznikSO so = new PretraziPolaznikSO(tekst);
            so.ExecuteTemplate();
            return so.Result;
        }
        //EVIDENCIONI OBRAZAC
        public static EvidencioniObrazac KreirajEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            KreirajEvidencioniObrazacSO so = new KreirajEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<EvidencioniObrazac> VratiListuSviEvidencioniObrazac()
        {
            VratiListuSviEvidencioniObrazacSO so = new VratiListuSviEvidencioniObrazacSO();
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<EvidencioniObrazac> VratiListuEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            VratiListuEvidencioniObrazacSO so = new VratiListuEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static List<EvidencioniObrazac> PretraziEvidencioniObrazac(EvidencioniObrazacKriterijumiDTO entities)
        {
            PretraziEvidencioniObrazacSO so = new PretraziEvidencioniObrazacSO(entities);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static EvidencioniObrazac PromeniEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            PromeniEvidencioniObrazacSO so = new PromeniEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
            return so.Result;
        }
        public static void ObrisiEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            ObrisiEvidencioniObrazacSO so = new ObrisiEvidencioniObrazacSO(obrazac);
            so.ExecuteTemplate();
        }
        //AUTOMOBIL
        public static List<Automobil> VratiListuSviAutomobil()
        {
            VratiListuSviAutomobilSO so = new VratiListuSviAutomobilSO();
            so.ExecuteTemplate();
            return so.Result;
        }
      
      
       
    }
}
