using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            ProductDb productDb= new ProductDb();
            List<Product> products = new List<Product>();
            MapProduct mapProduct = new MapProduct(read.ViewDataTable(products));
            bindingSource1.DataSource = mapProduct.Map();           
            dataGridView1.DataSource = bindingSource1;
            productDb.AddToDatabase(mapProduct.Map());
            dataGridView1.ReadOnly= true;
            dataGridView1.Columns[3].ReadOnly = false;
            }
        
        }

        
}
