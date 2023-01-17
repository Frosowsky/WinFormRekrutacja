using System;
using System.Collections.Generic;
using System.Data;
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

        

        public void UpdateToDatabaseValue(int value, int secondValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    var query = "UPDATE ProductsTable SET Kod=@Kod where Kod = @OldKod";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    sqlCommand.Parameters.AddWithValue("@Kod", value);
                    sqlCommand.Parameters.AddWithValue("@OldKod", secondValue);
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kod zaktualizowany");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddToDatabase(List<Product> products)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var query = "INSERT INTO ProductsTable VALUES (@Zdjęcie, @ZdjecieDrugie, @Kod, @Nazwa, @Ean, @Producent," +
                        "@Stan, @Vat, @Waga, @JednostkaMagazynowa, @OpisHTML, @MinimumZamowienie, @NumerKatalogowy)";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    foreach (Product product in products)
                    {

                        sqlCommand.Parameters.AddWithValue("@Zdjęcie", product.Zdjęcie);
                        sqlCommand.Parameters.AddWithValue("@ZdjecieDrugie", product.Photo);
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
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Parameters.Clear();
                    }
                    MessageBox.Show("Pomyślnie dodano plik do bazy danych");   
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
                
        }

        public DataSet Refresh()
        {
            try
            {   DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    var query = "Select * From ProductsTable";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);                 
                    da.Fill(ds, "ProductsTable");         
                    con.Close();
                         
                }
                return ds;
            }

            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public DataSet Search(int txt)
        {
            try
            {
                DataGridView dataGridView = new DataGridView();
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    var query = "Select * From ProductsTable where Kod = @Kod";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    sqlCommand.Parameters.AddWithValue("@Kod", txt);
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    da.Fill(ds, "ProductsTable");
                    con.Close();
                }
                return ds;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
}
