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

		public User GetUser(int id)
		{
			return new UserDataManager().GetUser(id);
		}

        public bool DeleteBlog(int id)
        {
            return new BlogDataManager().DeleteBlog(id);
        }

		public User GetUserByEmail(string email)
		{
			return new UserDataManager().GetUserByEmail(email);
		}

		public bool CreateUser(User user)
		{
			return new UserDataManager().CreateUser(user);
		}
    }
}
