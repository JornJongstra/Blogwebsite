using BlogWebsiteCore;
using Classes;

namespace BlogWebsiteData
{
	public class MsSqlService : IDAL
	{
		public Blog GetBlog(int id)
		{
			return new BlogDataManager().GetBlog(id);
		}

		public List<Blog> GetBlogs()
		{
			return new BlogDataManager().GetBlogs();
		}

		public bool CreateBlog(Blog blog)
		{
			return new BlogDataManager().CreateBlog(blog);
		}

		public bool UpdateBlog(Blog blog)
		{
			return new BlogDataManager().UpdateBlog(blog);
		}

		public List<Category> GetCategories()
		{
			return new CategoryDataManager().GetCategories();
		}
	}
}
