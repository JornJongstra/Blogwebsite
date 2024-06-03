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

                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Users] WHERE Users.Id = @Id;", sqlConnection);

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

				int userId = 0;
				string username = "";
				string email = "";
				string password = "";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(3), reader.GetString(2));
                        userId = reader.GetInt32(0);
                        username = reader.GetString(1);
                        email = reader.GetString(2);
                        password = reader.GetString(3);
                    }
                }

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                BlogDataManager blogDataManager = new BlogDataManager();
                List<Blog> blogs = blogDataManager.GetBlogsFromUser(id);

                User user = new User(userId, username, password, email, blogs);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public User GetUserByEmail(string email)
        {
			try
			{
				using var sqlConnection = new SqlConnection(ConnectionString);

				sqlConnection.Open();
								
				SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Users] WHERE Users.Email = @Email;", sqlConnection);

				cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value = email;

				int userId = 0;
				string username = "";
				string userEmail = "";
				string password = "";

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						userId = reader.GetInt32(0);
						username = reader.GetString(1);
						userEmail = reader.GetString(2);
						password = reader.GetString(3);
                    }
				}

				cmd.ExecuteNonQuery();

				sqlConnection.Close();

                User user = new User(userId, username, password, email);

                return user;
			}
			catch (Exception)
			{
				return null;
			}
		}
        public bool CreateUser(User user)
        {
			try
			{
				using var sqlConnection = new SqlConnection(ConnectionString);

				sqlConnection.Open();

				SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Users] values (@Username, @Email, @Password, @Role)", sqlConnection);

				cmd.Parameters.AddWithValue("@Username", user.Username);
				cmd.Parameters.AddWithValue("@Email", user.Email);
				cmd.Parameters.AddWithValue("@Password", user.Password);
				cmd.Parameters.AddWithValue("@Role", 0);

				cmd.ExecuteNonQuery();

				sqlConnection.Close();

				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return false;
			}
		}
    }
}
