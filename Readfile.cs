using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormRekrutacja
{
    internal class Readfile
    {

        public string GetLoadString()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            return dlg.FileName;
        }

        public DataTable InputToDB()
        {   try
            {
            ProductDb productDb = new ProductDb();
            Product product = new Product();
            DataTable dt = new DataTable();
            var lines = File.ReadAllLines(GetLoadString());
            var headers = lines[0].Split(';');
            
                foreach (var header in headers)
                {
                    if (!string.IsNullOrEmpty(header))
                    {
                        dt.Columns.Add(header);
                    }
                }

                for (int i = 2; i < lines.Length; i++)
                {
                    var dataWords = lines[i].Split(';');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    int rowIndex = 0;
                    foreach (string word in dataWords)
                    {
                        if (!string.IsNullOrEmpty(headers[columnIndex]))
                        {
                            dr[rowIndex] = word;
                            rowIndex++;

                        }
                        columnIndex++;
                    }
                    dt.Rows.Add(dr);
                    
                }

               return dt;           
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
         
        }
  
    }
}
