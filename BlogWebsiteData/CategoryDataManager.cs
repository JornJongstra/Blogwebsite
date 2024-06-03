using Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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

				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM [dbo].[Categories]", connection);

					connection.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var CategorieId = Convert.ToInt32(reader["Id"]);
							var CategorieName = Convert.ToString(reader["Name"]);

							Category category = new Category(CategorieId, CategorieName);
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
