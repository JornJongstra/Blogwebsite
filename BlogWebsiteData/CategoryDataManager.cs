using Classes;
using System.Data.SqlClient;

namespace BlogWebsiteData
{
	public class CategoryDataManager
	{
		private readonly string ConnectionString = "Data Source=DESKTOP-5DRN057\\SQLEXPRESS;Initial Catalog=Blogger;Integrated Security=True;Connect Timeout=30;Encrypt=False";
		public List<Category> GetCategories()
		{
			try
			{
				List<Category> categories = new List<Category>();

				using (var connection = new SqlConnection(ConnectionString))
				{
					var cmd = new SqlCommand("SELECT Id, Name FROM [dbo].[Categories]", connection);

					connection.Open();
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var CategorieId = Convert.ToInt32(reader["Id"]);
							var CategorieName = Convert.ToString(reader["Name"]);

							var category = new Category(CategorieId, CategorieName);
							categories.Add(category);
						}
					}

					cmd.ExecuteNonQuery();

					connection.Close();
				}

				return categories;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
