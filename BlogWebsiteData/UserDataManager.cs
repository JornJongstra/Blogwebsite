using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Reflection.Metadata;

namespace BlogWebsiteData
{
    public class UserDataManager
    {
        private readonly string ConnectionString = "Data Source=DESKTOP-5DRN057\\SQLEXPRESS;Initial Catalog=Blogger;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public User GetUser(int id)
        {
            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                sqlConnection.Open();

                User user = new User();

                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Users] WHERE Users.Id = @Id;", sqlConnection);

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Password = reader.GetString(3);
                    }
                }

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                BlogDataManager blogDataManager = new BlogDataManager();
                user.Blogs = blogDataManager.GetBlogsFromUser(id);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
