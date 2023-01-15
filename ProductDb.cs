using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormRekrutacja
{
    internal class ProductDb 
    {
       
        private readonly string connectionString = "Data Source=DESKTOP-1NUMHB5\\SQLEXPRESS01;Initial Catalog=EltesDb;Integrated Security=True";

        public void AddToDatabase(List<Product> products)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    var query = "Insert into ProductsTable VALUES (@Zdjęcie, @Zdjecie, @Kod, @Nazwa, @Ean, @Producent," +
                        "@Stan, @Vat, @Waga, @JednostkaMagazynowa, @OpisHTML, @MinimumZamowienie, @NumerKatalogowy)";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    foreach(Product product in products)
                    {
                        sqlCommand.Parameters.AddWithValue("@Zdjęcie", product.Zdjęcie);
                        sqlCommand.Parameters.AddWithValue("@Zdjecie", product.Zdjecie);
                        sqlCommand.Parameters.AddWithValue("@Kod", product.Kod);
                        sqlCommand.Parameters.AddWithValue("@Nazwa", product.Nazwa);
                        sqlCommand.Parameters.AddWithValue("@Ean", product.Ean);
                        sqlCommand.Parameters.AddWithValue("@Producent", product.Producent);
                        sqlCommand.Parameters.AddWithValue("@Stan", product.Stan);
                        sqlCommand.Parameters.AddWithValue("@Vat", product.Vat);
                        sqlCommand.Parameters.AddWithValue("@Waga", product.Waga);
                        sqlCommand.Parameters.AddWithValue("@JednostkaMagazynowa", product.JednostkaMagazynowa);
                        sqlCommand.Parameters.AddWithValue("@OpisHTML", product.OpisHTML);
                        sqlCommand.Parameters.AddWithValue("@MinimumZamowienie", product.MinimumZamowienie);
                        sqlCommand.Parameters.AddWithValue("@NumerKatalogowy", product.NumerKatalogowy);

                    }
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                
        }
       
    }
}
