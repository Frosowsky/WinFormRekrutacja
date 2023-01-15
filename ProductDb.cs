using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WinFormRekrutacja
{
    internal class ProductDb 
    {

        public void connection()
        {
            string connectionString = "Data Source=DESKTOP-1NUMHB5\\SQLEXPRESS01;Initial Catalog=EltesDb;Integrated Security=True";
            var con = new SqlConnection(connectionString);
            try
            {
                con.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
       
    }
}
