using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlogWebsiteData
{
    public class BlogDataManager
    {
        private readonly string ConnectionString = "Data Source=DESKTOP-5DRN057\\SQLEXPRESS;Initial Catalog=Blogger;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool Create(string Title)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Blogs] values (@Title)", sqlConnection);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return true;
        }
    }
}
