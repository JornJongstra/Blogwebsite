using System.Data.SqlClient;
using Classes;

namespace BlogWebsiteData
{
    public class BlogDataManager
    {
        private readonly string ConnectionString = "Data Source=DESKTOP-5DRN057\\SQLEXPRESS;Initial Catalog=Blogger;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool Create(Blog blog)
        {
	        try
	        {
		        using var sqlConnection = new SqlConnection(ConnectionString);

		        sqlConnection.Open();

		        SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Blogs] values (@Title, @Text, @Slug, @User_id)", sqlConnection);

		        cmd.Parameters.AddWithValue("@Title", blog.Title);
		        cmd.Parameters.AddWithValue("@Text", blog.Text);
		        cmd.Parameters.AddWithValue("@Slug", blog.Slug);
		        cmd.Parameters.AddWithValue("@User_id", blog.UserId);

		        cmd.ExecuteNonQuery();

		        sqlConnection.Close();

		        return true;
	        }
	        catch (SqlException)
	        {
		        return false;
	        }
        }

        public bool Update(Blog blog)
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

        public bool Delete(Blog blog)
        {
	        try
	        {
		        using var sqlConnection = new SqlConnection(ConnectionString);

		        sqlConnection.Open();

		        SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Blogs] WHERE id = '@Id'", sqlConnection);

		        cmd.Parameters.AddWithValue("@Id", blog.Id);

		        cmd.ExecuteNonQuery();

		        sqlConnection.Close();

		        return true;
			}
	        catch (Exception)
	        {
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

				SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Blogs] WHERE id = '@Id'", sqlConnection);

		        cmd.Parameters.AddWithValue("@Id", id);

		        using (SqlDataReader reader = cmd.ExecuteReader())
		        {
			        if (reader.Read())
			        {
				        blog.Id = reader.GetInt32(0);
						blog.Title = reader.GetString(1);
						blog.Text = reader.GetString(2);
						blog.Slug = reader.GetString(3);

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
    }
}
