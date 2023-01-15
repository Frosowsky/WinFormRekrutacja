using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormRekrutacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            Readfile read = new Readfile();
            List<Product> products = new List<Product>();
            Product product = new Product();
            bindingSource1.DataSource = read.InputToDB();
            dataGridView1.DataSource = bindingSource1;
            for(int i=0; i<dataGridView1.Rows.Count-1; i++)
            {
            

                    product.Zdjęcie = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        product.Zdjecie = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        product.Kod = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        product.Nazwa = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        product.Ean = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        product.Producent = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        product.Stan = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    product.Vat = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString().TrimEnd('%'));
                        product.Waga = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value.ToString());
                        product.JednostkaMagazynowa = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        product.OpisHTML = dataGridView1.Rows[i].Cells[10].Value.ToString();
                        product.MinimumZamowienie = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value.ToString());
                        product.NumerKatalogowy = dataGridView1.Rows[i].Cells[12].Value.ToString();
    
                products.Add(product);
            }
        }

        
    }
}
