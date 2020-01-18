using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahveEvi
{
    class MusteriBilgileri
    {
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public List<Siparis> Siparisler = new List<Siparis>();
        private decimal _odedigiUcret;
        public decimal OdedigiUcret
        {
            get
            {
                foreach (Siparis siparis in Siparisler)
                {
                    _odedigiUcret += siparis.ToplamSiparisTutari;
                }
                return _odedigiUcret;
            }
        }
    }
}
