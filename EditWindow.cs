using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormRekrutacja
{
    public partial class EditWindow : Form
    {
        public int oldText { get; set; }
        public EditWindow()
        {
            InitializeComponent();
           
        }
        ProductDb productDb = new ProductDb();        
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            
            int textToUpdate = Convert.ToInt32(textBox3.Text);
            productDb.UpdateToDatabaseValue(textToUpdate, oldText);            
            Close();
            
        }

        private void EditWindow_Load(object sender, EventArgs e)
        {        
            oldText = Convert.ToInt32(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
