using Classes;

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
