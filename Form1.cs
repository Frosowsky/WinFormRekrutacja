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
            ProductDb productDb = new ProductDb();
            List<Product> products = new List<Product>();
            MapProduct mapProduct = new MapProduct(read.ViewDataTable(products));
            bindingSource1.DataSource = mapProduct.Map();
            dataGridView1.DataSource = bindingSource1;
            productDb.AddToDatabase(mapProduct.Map());
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDb productDb = new ProductDb();
           
            EditWindow editWindow = new EditWindow();
            
            if(dataGridView1.SelectedRows.Count != 0)
            {
                
                editWindow.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                editWindow.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                editWindow.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                editWindow.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                editWindow.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                editWindow.textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                editWindow.textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                editWindow.textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString() +  " %";
                editWindow.textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                editWindow.textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                editWindow.textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                editWindow.textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                editWindow.textBox13.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                 editWindow.ShowDialog();
                
                
            } 
            else
            {
                MessageBox.Show("Zaznacz wiersz do edycji");
                
            }



            
        }
    }
}
