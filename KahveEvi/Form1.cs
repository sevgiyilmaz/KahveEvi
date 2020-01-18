using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahveEvi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] Kahveler = { "Mistro", "Americano", "Bianco", "Cappucino", "Macchiato", "Con Panna", "Mocha" };
        string[] SogukIcecekler = { "Buzlu Caffe Latte", "Expresso Frappe", "Buzlu White Chocolate Mocha", "Buzlu Caramel Crest", "Ice Americano", "Buzlu Caffe Mocha" };
        string[] SicakIcecekler = { "Çay", "Sıcak Çikolata", "Chai Tea Latte" };

        private void Form1_Load(object sender, EventArgs e)
        {
            SiparisTemizle();
            cmbKahveler.Items.AddRange(Kahveler);
            cmbSogukIcecekler.Items.AddRange(SogukIcecekler);
            cmbSicakIcecekler.Items.AddRange(SicakIcecekler);
        }

        private void cmbKahveler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKahveler.SelectedIndex!=-1)
            {
                cmbSicakIcecekler.Enabled = false;
                cmbSogukIcecekler.Enabled = false;
                nudSoguk.Enabled = false;
                nudSıcak.Enabled = false;
            }
        }

        private void cmbSogukIcecekler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSogukIcecekler.SelectedIndex != -1)
            {
                cmbKahveler.Enabled = false;
                cmbSicakIcecekler.Enabled = false;
                nudKahve.Enabled = false;
                nudSıcak.Enabled = false;
            }
        }

        private void cmbSicakIcecekler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSicakIcecekler.SelectedIndex != -1)
            {
                cmbKahveler.Enabled = false;
                cmbSogukIcecekler.Enabled = false;
                nudKahve.Enabled = false;
                nudSoguk.Enabled = false;
            }
        }
        void SiparisTemizle()
        {
            cmbKahveler.Enabled = true;
            cmbSicakIcecekler.Enabled = true;
            cmbSogukIcecekler.Enabled = true;
            nudKahve.Enabled = true;
            nudSıcak.Enabled = true;
            nudSoguk.Enabled = true;
            cmbKahveler.SelectedIndex = -1;
            cmbSicakIcecekler.SelectedIndex = -1;
            cmbSogukIcecekler.SelectedIndex = -1;
            nudKahve.Value = 0;
            nudSıcak.Value = 0;
            nudSoguk.Value = 0;
            chb1.Checked = false;
            chb2.Checked = false;
            rbGrandi.Checked = false;
            rbVenti.Checked = false;
            rbTall.Checked = false;
            rbSoya.Checked = false;
            rbYagsiz.Checked = false;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if ((cmbKahveler.SelectedIndex!=-1||cmbSogukIcecekler.SelectedIndex!=-1||cmbSicakIcecekler.SelectedIndex!=-1)&&(nudKahve.Value!=0||nudSoguk.Value!=0||nudSıcak.Value!=0)&&(!string.IsNullOrWhiteSpace(txtAdSoyad.Text))&&(!string.IsNullOrWhiteSpace(txtTelefon.Text))&&(!string.IsNullOrWhiteSpace(txtAdres.Text)))
            {
                if (cmbKahveler.Enabled==true)
                {
                    SiparisEkle(cmbKahveler, nudKahve);
                }
                else if (cmbSogukIcecekler.Enabled==true)
                {
                    SiparisEkle(cmbSogukIcecekler, nudSoguk);
                }
                else if (cmbSicakIcecekler.Enabled==true)
                {
                    SiparisEkle(cmbSicakIcecekler, nudSıcak);
                }
            }
            else
            {
                MessageBox.Show("Eklemek İstediğiniz Ürün İle Birlikte, Bilgilerinizi Girerek Hesapla Butonuna Basınız...","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        decimal sonFiyat;
        void SiparisEkle(ComboBox cmb,NumericUpDown nud)
        {
            Siparis siparis = new Siparis();
            if (cmb.Name=="cmbKahveler")
            {
                siparis.Kahve = cmb.SelectedItem.ToString();
                siparis.Adet = Convert.ToInt32(nud.Value);
            }
            else if (cmb.Name=="cmbSogukIcecekler")
            {
                siparis.SogukIcecek = cmb.SelectedItem.ToString();
                siparis.Adet = Convert.ToInt32(nud.Value);
            }
            else if (cmb.Name=="cmbSicakIcecekler")
            {
                siparis.SicakIcecek = cmb.SelectedItem.ToString();
                siparis.Adet = Convert.ToInt32(nud.Value);
            }
            foreach (RadioButton radioButton in pnlSut.Controls)
            {
                if (radioButton.Checked)
                {
                    siparis.Sut = radioButton.Text;
                    break;
                }
            }
            foreach (Control control in gbExtralar.Controls)
            {
                if ((control is RadioButton) && (control as RadioButton).Checked)
                {
                    siparis.Boyut = control.Text;
                    break;
                }
            }
            if (chb1.Checked)
            {
                siparis.Shot = chb1.Text;
            }
            else if (chb2.Checked)
            {
                siparis.Shot = chb2.Text;
            }
            lsbSiparisler.Items.Add(siparis);
            sonFiyat += siparis.ToplamSiparisTutari;
            lblToplamSiparisTutari.Text = sonFiyat.ToString("c2");
            SiparisTemizle();
        }
        MusteriBilgileri[] musteriler = new MusteriBilgileri[0];
        int dizi = 0;
        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            MusteriBilgileri customer = new MusteriBilgileri();
            customer.AdSoyad = txtAdSoyad.Text.Trim();
            customer.Telefon = txtTelefon.Text.Trim();
            customer.Adres = txtAdres.Text.Trim();
            foreach (Siparis siparis in lsbSiparisler.Items)
            {
                customer.Siparisler.Add(siparis);
            }
            dizi++;
            Array.Resize(ref musteriler, dizi);
            musteriler[dizi - 1] = customer;
            MessageBox.Show($"Toplam{customer.Siparisler.Count} adet siparişiniz {customer.OdedigiUcret.ToString("c2")} tutarındadır.");
            txtAdres.Text = txtAdSoyad.Text = txtTelefon.Text = string.Empty;
            SiparisTemizle();
            sonFiyat = 0;
        }

        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
