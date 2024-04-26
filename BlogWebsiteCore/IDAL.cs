using Classes;

namespace BlogWebsiteCore
{
	public interface IDAL
	{
		public Blog GetBlog(int id);
		public List<Blog> GetBlogs();
		public Boolean CreateBlog(Blog blog);
		public Boolean UpdateBlog(Blog blog);
		public List<Category> GetCategories();
	}
}
