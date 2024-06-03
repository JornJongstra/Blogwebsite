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

		        SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Blogs] SET Title = @Title, Text = @Text, Slug = @Slug, User_id = @User_id WHERE Id = @Id", sqlConnection);

				//cmd.Parameters.Add("@Id", SqlDbType.VarChar);
				//cmd.Parameters["@Id"].Value = blog.Id;


				cmd.Parameters.AddWithValue("@Title", blog.Title);
		        cmd.Parameters.AddWithValue("@Text", blog.Text);
		        cmd.Parameters.AddWithValue("@Slug", blog.Slug);
		        cmd.Parameters.AddWithValue("@User_id", blog.UserId);
				cmd.Parameters.AddWithValue("@Id", blog.Id);

				cmd.ExecuteNonQuery();

				SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[BlogCategories] SET blog_id = @Blog_id, categorie_id = @Categorie_id WHERE Blog_id = @Blog_id", sqlConnection);

				cmd1.Parameters.AddWithValue("@Categorie_id", blog.Categories.First().Id);
				cmd1.Parameters.AddWithValue("@Blog_id", blog.Id);

				cmd1.ExecuteNonQuery();

				sqlConnection.Close();

		        return true;
			}
	        catch (Exception e)
	        {
                Console.WriteLine (e.ToString());
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

                int blogId = 0;
                int userId = 0;
                string title = "";
                string text = "";
                string author = "";
                List<Category> categories = new List<Category>();

                //SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.User_id, Blogs.Title, Blogs.Text, Users.Username, Categories.Id, Categories.Name FROM[dbo].[Blogs] INNER JOIN[dbo].[Users] ON Blogs.User_id = Users.Id INNER JOIN[dbo].[BlogCategories] ON BlogCategories.Blog_id = Blogs.Id INNER JOIN[dbo].[Categories] ON Categories.Id = BlogCategories.Categorie_id WHERE Blogs.User_id = @UserId", sqlConnection);

                SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.User_id, Blogs.Title, Blogs.Text, Users.Username FROM [dbo].[Blogs] INNER JOIN [dbo].[Users] ON Blogs.User_id = Users.Id WHERE Blogs.Id = @Id;", sqlConnection);

				cmd.Parameters.Add("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value = id;

                //cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
	                while (reader.Read())
	                {
		                blogId = reader.GetInt32(0);
                        userId = reader.GetInt32(1);
				        title = reader.GetString(2);
				        text = reader.GetString(3);
				        author = reader.GetString(4);
			        }
                }

                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("SELECT Categories.Id, Categories.Name FROM [dbo].[BlogCategories] INNER JOIN [dbo].[Categories] ON BlogCategories.Categorie_id = Categories.Id WHERE BlogCategories.Blog_id = @Blog_id", sqlConnection);

				cmd2.Parameters.Add("@Blog_id", SqlDbType.Int);
				cmd2.Parameters["@Blog_id"].Value = id;

				using (SqlDataReader reader = cmd2.ExecuteReader())
				{
					while (reader.Read())
					{
                        Category category = new Category(reader.GetInt32(0), reader.GetString(1));
                        categories.Add(category);
					}
				}

                
				cmd2.ExecuteNonQuery();
                Blog blog = new Blog(blogId, title, text, userId, author, categories);

                sqlConnection.Close();
                //Blog blog = new Blog(blogId, title, text, userId, author, categories);

                return blog;
	        }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

                //int blogId = 0;
                //int userId = 0;
                //string title = "";
                //string text = "";
                //string author = "";
                //string slug = "";

                SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.Title, Blogs.Text, Blogs.Slug, Users.Username, Categories.Id, Categories.Name FROM [dbo].[Blogs] INNER JOIN [dbo].[Users] ON Blogs.User_id = Users.Id INNER JOIN [dbo].[BlogCategories] ON BlogCategories.Blog_id = Blogs.Id INNER JOIN [dbo].[Categories] ON Categories.Id = BlogCategories.Categorie_id WHERE Blogs.User_id = @UserId", sqlConnection);

                cmd.Parameters.Add("@UserId", SqlDbType.Int);
                cmd.Parameters["@UserId"].Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int blogId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string text = reader.GetString(2);
                        string slug = reader.GetString(3);
                        string author = reader.GetString(4);
						List<Category> categories = new List<Category>();
						Category category = new Category(reader.GetInt32(5), reader.GetString(6));
                        categories.Add(category);

                        Blog blog = new Blog(blogId, title, text, id, author, categories);
                        
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

                //int blogId = 0;
                //int userId = 0;
                //string title = "";
                //string text = "";
                //string author = "";
                //string slug = "";

                SqlCommand cmd = new SqlCommand("SELECT Blogs.Id, Blogs.Title, Blogs.Text, Blogs.Slug, Users.Username  FROM [dbo].[Blogs] INNER JOIN [dbo].[Users] ON Blogs.User_id = Users.Id", sqlConnection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int blogId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string text = reader.GetString(2);
                        string slug = reader.GetString(3);
						string author = reader.GetString(4);
                        Blog blog = new Blog(blogId, title, text,slug, author);
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
