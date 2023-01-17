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
        ProductDb productDb = new ProductDb();
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                Readfile read = new Readfile();
                
                List<Product> products = new List<Product>();
                MapProduct mapProduct = new MapProduct(read.ViewDataTable(products));
                bindingSource1.DataSource = mapProduct.Map();
                dataGridView1.DataSource = bindingSource1;
                productDb.AddToDatabase(mapProduct.Map());
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);   
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EditWindow editWindow = new EditWindow();

                if (dataGridView1.SelectedRows.Count != 0)
                {

                    editWindow.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    editWindow.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    editWindow.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    editWindow.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    editWindow.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    editWindow.textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    editWindow.textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    editWindow.textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString() + " %";
                    editWindow.textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    editWindow.textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    editWindow.textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    editWindow.textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    editWindow.textBox13.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                    editWindow.ShowDialog();

                    GridRefresh();
                }

                else

                {
                    MessageBox.Show("Zaznacz wiersz do edycji");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GridRefresh("Baza danych została odświeżona");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GridRefresh(string message)
        {
            bindingSource1.DataSource = productDb.Refresh().Tables["ProductsTable"].DefaultView;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();
            MessageBox.Show(message);
        }
        public void GridRefresh()
        {
   
            bindingSource1.DataSource = productDb.Refresh().Tables["ProductsTable"].DefaultView;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {        
                Szukaj szukaj = new Szukaj();
                szukaj.ShowDialog();
                bindingSource1.DataSource = productDb.Search(szukaj.searchingWord).Tables["ProductsTable"].DefaultView;
                dataGridView1.DataSource = bindingSource1;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
