using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormRekrutacja
{
    internal class MapProduct
    {
        private  DataTable _dt { get; }
        public MapProduct(DataTable dt)
        {
            _dt = dt;
        }
        public List<Product> Map()
        {
            List<Product> list = new List<Product>();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {

                Product product = new Product();
                {



                    product.Zdjęcie = _dt.Rows[i]["zdjęcie"].ToString();
                    product.Photo = _dt.Rows[i]["zdjecie"].ToString();
                    product.Kod = Convert.ToInt32(_dt.Rows[i]["KOD"].ToString());
                    product.Nazwa = _dt.Rows[i]["nazwa"].ToString();
                    product.Ean = _dt.Rows[i]["EAN"].ToString();
                    product.Producent = _dt.Rows[i]["Producent"].ToString();
                    product.Stan = Convert.ToInt32(_dt.Rows[i]["atrybut stan unimet"].ToString());
                    product.Vat = Convert.ToInt32(_dt.Rows[i]["Vat"].ToString().TrimEnd('%'));
                    product.Waga = Convert.ToDecimal(_dt.Rows[i]["Waga"].ToString());
                    product.JednostkaMagazynowa = _dt.Rows[i]["jm"].ToString();
                    product.OpisHTML = _dt.Rows[i]["opis html"].ToString();
                    product.MinimumZamowienie = Convert.ToInt32(_dt.Rows[i]["atrybut unimet min zamówieniowe"].ToString());
                    product.NumerKatalogowy = _dt.Rows[i]["nr katalogowy"].ToString();
                }


                 list.Add(product);
            }
            return list;
        }
    }
}
