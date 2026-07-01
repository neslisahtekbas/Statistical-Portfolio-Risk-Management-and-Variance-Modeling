using System.Data;
using System.Data.SqlClient;

namespace PortfoyYonetimi
{
    public class DB
    {
        // NOT: Hata almamak için veri dosyasının kendi bilgisayarınızdaki konumunu ' C:\....mdf; ' içine yapıştırın!
        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Desktop\Sınavlar\C#\C#\PortfoyYonetimi\PortfoyYonetimi\BorsaDB.mdf;Integrated Security=True";
        public static DataSet makeDBOperations(string query)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlDataAdapter adapter = new SqlDataAdapter(query, baglanti);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
    }
}