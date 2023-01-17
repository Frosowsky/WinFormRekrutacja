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
    public partial class Szukaj : Form
    {
        public string searchingWord { get; set; }
        public Szukaj()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                searchingWord = textBox1.Text;
                ProductDb productDb = new ProductDb();
                if (!string.IsNullOrEmpty(searchingWord))
                {
                    int number;
                    bool success = int.TryParse(searchingWord, out number);
                    if (success)
                    {
                        productDb.Search(Convert.ToInt32(searchingWord));
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wprowadzona wartość jest błędna");
                    }


                }
                else
                {
                    MessageBox.Show("Wartość jest pusta");
                }
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
