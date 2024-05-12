using Classes;

namespace BlogWebsiteCore
{
	public interface IDAL
	{
		public Blog GetBlog(int id);
		public List<Blog> GetBlogs();
		public Boolean CreateBlog(Blog blog);
		public Boolean UpdateBlog(Blog blog);
		public Boolean DeleteBlog(int id);
		public List<Category> GetCategories();
		public User GetUser(int id);
	}
}
