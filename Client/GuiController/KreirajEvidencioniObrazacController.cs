using Client.UserControls.EvidencioniObrazac;
using Client.UserControls.Polaznik;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class KreirajEvidencioniObrazacController
    {
        private UCKreirajEvidencioniObrazac ucObrazac;
        private int idObrasca;

        public KreirajEvidencioniObrazacController(UCKreirajEvidencioniObrazac ucObrazac)
        {
            this.ucObrazac = ucObrazac;

        }

        internal void KreirajEvidencioniObrazac()
        {
            if (ucObrazac.CmbInstruktor.Items?.Count == 0 || ucObrazac.CmbPolaznik.Items?.Count == 0) {
                MessageBox.Show("Neophodno je da postoje instruktore i polaznici da biste kreirali evidencioni obrazac!", "Upozorenje",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            EvidencioniObrazac obrazac = new EvidencioniObrazac()
            {
                Instruktor = (Instruktor)ucObrazac.CmbInstruktor.Items[0],
                Polaznik = (Polaznik)ucObrazac.CmbPolaznik.Items[0]
            };
            Response response = Communication.Instance.KreirajEvidencioniObrazac(obrazac);
            try
            {
                if (response.IsSuccess)
                {
                    idObrasca = ((EvidencioniObrazac)response.Data).IdObrazac;
                    MessageBox.Show("Sistem je kreirao evidencioni obrazac!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucObrazac.TxtBrCasova.Enabled = true;
                    ucObrazac.CmbInstruktor.Enabled = true;
                    ucObrazac.CmbPolaznik.Enabled = true;
                    ucObrazac.DtpDatumPocetka.Enabled = true;
                    ucObrazac.BtnUbaci.Enabled = true;
                    ucObrazac.BtnKreiraj.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da kreira evidencioni obrazac.\n" + ex.Message);
            }
        }
        internal void PromeniEvidencioniObrazac()
        {
            try
            {
                if (!ucObrazac.Validacija())
                {
                    MessageBox.Show("Molim vas unesite sva polja!");
                }
                EvidencioniObrazac obrazac = new EvidencioniObrazac();
                obrazac.IdObrazac = idObrasca;
                obrazac.Polaznik = (Polaznik)ucObrazac.CmbPolaznik.SelectedItem;
                obrazac.Instruktor = (Instruktor)ucObrazac.CmbInstruktor.SelectedItem;
                obrazac.BrojCasova = int.Parse(ucObrazac.TxtBrCasova.Text);
                obrazac.DatumPocetka = ucObrazac.DtpDatumPocetka.Value;

                Communication.Instance.PromeniEvidencioniObrazac(obrazac);
                MessageBox.Show("Sistem je zapamtio evidencioni obrazac!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti polaznika.\n" + ex.Message);
            }
        }

        internal void VratiListuSviPolaznik()
        {
            try
            {
                List<Polaznik> polaznici = (List<Polaznik>)Communication.Instance.VratiListuSviPolaznik().Data;

                if (polaznici == null | polaznici.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih korisnika.");
                    ucObrazac.CmbPolaznik.DataSource = null;
                    return;
                }
                ucObrazac.CmbPolaznik.DataSource = polaznici;
                ucObrazac.CmbPolaznik.ValueMember = "IdPolaznik";
                ucObrazac.CmbPolaznik.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbPolaznik.SelectedIndex = -1;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita korisnike.\n" + ex.Message);

            }
        }
        internal void VratiListuSviInstruktor()
        {
            try
            {
                List<Instruktor> instruktori = (List<Instruktor>)Communication.Instance.VratiListuSviInstruktor().Data;

                if (instruktori == null || instruktori.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih instruktora.");
                    ucObrazac.CmbInstruktor.DataSource = null;
                    return;
                }
                ucObrazac.CmbInstruktor.DataSource = instruktori;
                ucObrazac.CmbInstruktor.ValueMember = "IdInstruktor";
                ucObrazac.CmbInstruktor.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbInstruktor.SelectedIndex = -1;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita instruktore.\n" + ex.Message);

            }
        }
    }
}
