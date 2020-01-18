using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahveEvi
{
    class Siparis
    {
        private string _kahve;
        private decimal _fiyat;
        public string Kahve
        {
            get
            {
                return _kahve;
            }
            set
            {
                switch (value)
                {
                    case "Mistro":
                        _fiyat = 4.5m;
                        break;
                    case "Americano":
                        _fiyat = 5.75m;
                        break;
                    case "Bianco":
                        _fiyat = 6;
                        break;
                    case "Cappucino":
                        _fiyat = 7.5m;
                        break;
                    case "Macchiato":
                        _fiyat = 6.75m;
                        break;
                    case "Con Panna":
                        _fiyat = 8;
                        break;
                    case "Mocha":
                        _fiyat = 7.75m;
                        break;
                }
                _kahve = value;
            }
        }
        private string _sogukIcecek;
        public string SogukIcecek
        {
            get
            {
                return _sogukIcecek;
            }
            set
            {
                switch (value)
                {
                    case "Buzlu Caffe Latte":
                        _fiyat = 5.5m;
                        break;
                    case "Expresso Frappe":
                        _fiyat = 5.5m;
                        break;
                    case "Buzlu White Chocolate Mocha":
                        _fiyat = 5.5m;
                        break;
                    case "Buzlu Caramel Crest":
                        _fiyat = 5.5m;
                        break;
                    case "Ice Americano":
                        _fiyat = 5.5m;
                        break;
                    case "Buzlu Caffe Mocha":
                        _fiyat = 5.5m;
                        break;
                }
                _sogukIcecek = value;
            }
        }
        private string _sicakIcecek;
        public string SicakIcecek
        {
            get
            {
                return _sicakIcecek;
            }
            set
            {
                switch (value)
                {
                    case "Çay":
                        _fiyat = 3;
                        break;
                    case "Sıcak Çikolata":
                        _fiyat = 4.5m;
                        break;
                    case "Chai Tea Latte":
                        _fiyat = 6.5m;
                        break;
                }
                _sicakIcecek = value;
            }
        }
        private string _shot;
        private decimal _shotFiyat = 0;
        public string Shot
        {
            get
            {
                return _shot;
            }
            set
            {
                switch (value)
                {
                    case "1x":
                        _shotFiyat = 0.75m;
                        break;
                    case "2x":
                        _shotFiyat = 1.5m;
                        break;
                }
                _shot = value;
            }
        }
        private string _sut;
        private decimal _sutFiyat = 0;
        public string Sut
        {
            get { return _sut; }
            set
            {
                if (value != string.Empty)
                {
                    _sutFiyat = 0.50m;
                }
                _sut = value;
            }
        }
        private string _boyut;
        private decimal _boyutCarpani = 1;
        public string Boyut
        {
            get
            {
                return _boyut;
            }
            set
            {
                switch (value)
                {
                    case "Tall":
                        _boyutCarpani = 1;
                        break;
                    case "Grande":
                        _boyutCarpani = 1.25m;
                        break;
                    case "Venti":
                        _boyutCarpani = 1.75m;
                        break;
                }
                _boyut = value;
            }           
        }
        public int Adet { get; set; }
        public decimal ToplamSiparisTutari
        {
            get
            {
                return Adet * ((_boyutCarpani * _fiyat) + _sutFiyat + _shotFiyat);
            }
        }
        public override string ToString()
        {
            return $"{Boyut}//{Kahve}{SogukIcecek}{SicakIcecek}//{Sut}//{Shot}//{Adet}adet:{ToplamSiparisTutari.ToString("c2")}";
        }

    }
}
