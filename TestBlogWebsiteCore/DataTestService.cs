using BlogWebsiteCore;
using Classes;

namespace TestBlogWebsiteCore
{
    public class DataTestService : IDAL
    {
        public bool CreateBlog(Blog blog)
        {
            return true;
        }

        public bool CreateUser(User user)
        {
            return true;
        }

        public bool DeleteBlog(int id)
        {
            return true;
        }

        public Blog GetBlog(int id)
        {
            var blog = new Blog(10, "Title", "Text");

            return blog;
        }

        public List<Blog> GetBlogs()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            var user = new User("jorn.jongstra@kpnmail.nl", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");

            return user;
        }

        public bool UpdateBlog(Blog blog)
        {
            return true;
        }
    }
}
