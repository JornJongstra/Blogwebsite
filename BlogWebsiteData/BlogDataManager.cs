using System.Data;
using System.Data.SqlClient;
using Classes;

namespace BlogWebsiteData
{
    public class BlogDataManager
    {
        private readonly string ConnectionString = "Data Source=DESKTOP-5DRN057\\SQLEXPRESS;Initial Catalog=Blogger;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool CreateBlog(Blog blog)
        {
	        try
	        {
                int categorie_id = Convert.ToInt32(blog.Categories.First().Id);
		        using var sqlConnection = new SqlConnection(ConnectionString);

		        sqlConnection.Open();

		        SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Blogs] output INSERTED.ID values (@Title, @Text, @Slug, @User_id)", sqlConnection);

		        cmd.Parameters.AddWithValue("@Title", blog.Title);
		        cmd.Parameters.AddWithValue("@Text", blog.Text);
		        cmd.Parameters.AddWithValue("@Slug", blog.Slug);
		        cmd.Parameters.AddWithValue("@User_id", blog.UserId);

                //cmd.ExecuteNonQuery();

		        int blog_id = (int)cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("INSERT INTO [dbo].[BlogCategories] values (@Blog_id, @Categorie_id)", sqlConnection);

                cmd1.Parameters.AddWithValue("@Categorie_id", categorie_id);
                cmd1.Parameters.AddWithValue("@Blog_id", blog_id);

                cmd1.ExecuteNonQuery();

                sqlConnection.Close();

		        return true;
	        }
	        catch (SqlException e)
	        {
                Console.WriteLine(e.ToString());
		        return false;
	        }
        }

        public bool UpdateBlog(Blog blog)
        {
	        try
	        {
		        using var sqlConnection = new SqlConnection(ConnectionString);

		        sqlConnection.Open();

		        SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Blogs] SET title = '@Title', text = '@Text', slug = '@Slug' WHERE user_id = '@User_id'", sqlConnection);

		        cmd.Parameters.AddWithValue("@Title", blog.Title);
		        cmd.Parameters.AddWithValue("@Text", blog.Text);
		        cmd.Parameters.AddWithValue("@Slug", blog.Slug);
		        cmd.Parameters.AddWithValue("@User_id", blog.UserId);

		        cmd.ExecuteNonQuery();

		        sqlConnection.Close();

		        return true;
			}
	        catch (Exception)
	        {
		        return false;
	        }
        }

        public bool DeleteBlog(int id)
        {
	        try
	        {
		        using var sqlConnection = new SqlConnection(ConnectionString);

		        sqlConnection.Open();

		        SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Blogs] WHERE Blogs.Id = @Id", sqlConnection);

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;
                //cmd.Parameters.AddWithValue("@Id", id);

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

        public Blog GetBlog(int id)
        {
	        try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                sqlConnection.Open();

                Blog blog = new Blog();

		        SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.Title, Blogs.Text, Users.Username FROM [dbo].[Blogs] INNER JOIN [dbo].[Users] ON Blogs.User_id = Users.Id WHERE Blogs.Id = @Id;", sqlConnection);

				cmd.Parameters.Add("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value = id;
                //cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
	                while (reader.Read())
	                {
		                blog.Id = reader.GetInt32(0);
				        blog.Title = reader.GetString(1);
				        blog.Text = reader.GetString(2);
				        blog.Author = reader.GetString(3);
			        }
                }

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                return blog;
	        }
            catch (Exception)
            {
                return null;
            }
        }
		public List<Blog> GetBlogsFromUser(int id)
		{
            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                sqlConnection.Open();

                List<Blog> blogs = new List<Blog>();

                SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.Title, Blogs.Text, Blogs.Slug, Users.Username  FROM [dbo].[Blogs] INNER JOIN [dbo].[Users] ON Blogs.User_id = Users.Id WHERE Blogs.User_id = @UserId", sqlConnection);

                cmd.Parameters.Add("@UserId", SqlDbType.Int);
                cmd.Parameters["@UserId"].Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Blog blog = new Blog();
                        blog.Id = reader.GetInt32(0);
                        blog.Title = reader.GetString(1);
                        blog.Text = reader.GetString(2);
                        blog.Slug = reader.GetString(3);
                        blog.Author = reader.GetString(4);
                        blogs.Add(blog);
                    }
                }

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Blog> GetBlogs()
        {
            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                sqlConnection.Open();

                List<Blog> blogs = new List<Blog>();

                SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.Title, Blogs.Text, Blogs.Slug, Users.Username  FROM [dbo].[Blogs] INNER JOIN [dbo].[Users] ON Blogs.User_id = Users.Id", sqlConnection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
						Blog blog = new Blog();
                        blog.Id = reader.GetInt32(0);
                        blog.Title = reader.GetString(1);
                        blog.Text = reader.GetString(2);
                        blog.Slug = reader.GetString(3);
						blog.Author = reader.GetString(4);
						blogs.Add(blog);
                    }
                }

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                return blogs;
            }
            catch (Exception)
            {
                return null;
            }

		}
    }
}
