using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace BlogWebsiteData
{
	public class CategorieDataManager
	{
		public List<Category> GetCategories()
		{
			List<Category> categories = new List<Category>();

			var cat1 = new Category();
			cat1.Id = 1;
			cat1.Name = "Sport";

			var cat2 = new Category();
			cat2.Id = 2;
			cat2.Name = "Hobby";

			categories.Add(cat1);
			categories.Add(cat2);

			return categories;
		}
	}
}
