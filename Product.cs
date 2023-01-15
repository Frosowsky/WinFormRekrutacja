using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormRekrutacja
{
    internal class Product
    {
        public string Zdjęcie { get; set; }
        public string Zdjecie { get; set; }
        public int Kod { get; set; }
        public string Nazwa { get; set; }
        public double Ean { get; set; }
        public string Producent { get; set; }
        public int Stan { get; set; }
        public int Vat { get; set; }
        public decimal Waga { get; set; }
        public string JednostkaMagazynowa { get; set; }
        public string OpisHTML { get; set; }
        public int MinimumZamowienie { get; set; }
        public string NumerKatalogowy { get; set; }

    }
}
