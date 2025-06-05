using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        // Polaznik
        KreirajPolaznik,
        VratiListuPolaznik,
        VratiListuSviPolaznik,
        PromeniPolaznik,
        ObrisiPolaznik,
        PretraziPolaznik,

        // Kategorija vozacke
        UbaciKategorijaVozacke,

        // Instruktor
        PrijaviInstruktor,
        VratiListuInstruktor,
        VratiListuSviInstruktor,

        // Automobil
        VratiListuSviAutomobil,

        // Evidencioni obrazac
        KreirajEvidencioniObrazac,
        VratiListuEvidencioniObrazac,
        VratiListuSviEvidencioniObrazac,
        PromeniEvidencioniObrazac,
        ObrisiEvidencioniObrazac,
        PretraziEvidencioniObrazac
    }

}
