using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsiteCore
{
	public class CategoryCoreManager
	{
		public List<Category> GetCategories()
		{
			return ServiceHandler.Service.GetCategories(); 
		}
	}
}
