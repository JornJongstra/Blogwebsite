using Classes;

namespace BlogWebsiteCore
{
	public class CategorieCoreManager
	{
		public List<Category> GetCategories()
		{
			return ServiceHandler.Service.GetCategories();
		}
	}
}
