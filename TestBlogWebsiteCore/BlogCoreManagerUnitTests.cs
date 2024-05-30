using Classes;
using BlogWebsiteCore;

namespace TestBlogWebsiteCore
{
	[TestClass]
	public class BlogCoreManagerUnitTests
	{
        [TestMethod]
        public void CreateUser_WithValidData_UserCreated()
        {
			User user = new User();

			user.Username = "Test";
			user.Email = "Test@gmail.com";
			user.Password = "Test123";

			AuthCoreManager authCoreManager = new AuthCoreManager();
			bool result = authCoreManager.RegisterUser(user);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CreateUser_WithNotValidData_NoUsername_UserCreated()
        {
            User user = new User();

            user.Username = "";
            user.Email = "Test@gmail.com";
            user.Password = "Test123";

            AuthCoreManager authCoreManager = new AuthCoreManager();
            bool result = authCoreManager.RegisterUser(user);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CreateUser_WithNotValidData_NoEmail_UserCreated()
        {
            User user = new User();

            user.Username = "Test";
            user.Email = "";
            user.Password = "Test123";

            AuthCoreManager authCoreManager = new AuthCoreManager();
            bool result = authCoreManager.RegisterUser(user);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CreateUser_WithNotValidData_NoPassword_UserCreated()
        {
            User user = new User();

            user.Username = "Test";
            user.Email = "Test@gmail.com";
            user.Password = "";

            AuthCoreManager authCoreManager = new AuthCoreManager();
            bool result = authCoreManager.RegisterUser(user);
            Assert.AreEqual(false, result);
        }


        [TestMethod]
		public void CreateBlog_WithValidData_BlogCreated()
		{
			Blog blog = new Blog();
			BlogCoreManager blogCoreManager = new BlogCoreManager();
			blog.Title = "Eindhoven Sport";
			blog.Text = "Lorem";
			blog.CreatedDateTime = DateTime.Now;
			blog.Slug = "eindhoven-sport";
			blog.Categories = new List<Category>();
			Category category = new Category();
			category.Name = "Sport";
			category.Id = 1;
			blog.Categories.Add(category);
			blog.UserId = 1;

			bool result = blogCoreManager.CreateBlog(blog);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void CreateBlog_WithNotValidData_BlogCreated()
		{
            Blog blog = new Blog();
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            blog.Title = "";
            blog.Text = "";
            blog.CreatedDateTime = DateTime.Now;
            blog.Slug = "eindhoven-sport";
            blog.Categories = new List<Category>();
            Category category = new Category();
            category.Name = "Sport";
            category.Id = 1;
            blog.Categories.Add(category);
            blog.UserId = 1;

            bool result = blogCoreManager.CreateBlog(blog);
			Assert.AreEqual(false, result);
		}

        [TestMethod]
        public void UpdateBlog_WithNotValidData_BlogUpdated()
        {
            Blog blog = new Blog();
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            blog.Title = "";
            blog.Text = "";
            blog.Id = 1;
            blog.CreatedDateTime = DateTime.Now;
            blog.Slug = "eindhoven-sport";
            blog.Categories = new List<Category>();
            Category category = new Category();
            category.Name = "Sport";
            category.Id = 1;
            blog.Categories.Add(category);
            blog.UserId = 1;

            bool result = blogCoreManager.UpdateBlog(blog);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UpdateBlog_WithValidData_BlogUpdated()
        {
            Blog blog = new Blog();
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            blog.Title = "Sport";
            blog.Text = "Lorem";
            blog.Id = 1;
            blog.CreatedDateTime = DateTime.Now;
            blog.Slug = "eindhoven-sport";
            blog.Categories = new List<Category>();
            Category category = new Category();
            category.Name = "Sport";
            category.Id = 1;
            blog.Categories.Add(category);
            blog.UserId = 1;

            bool result = blogCoreManager.UpdateBlog(blog);
            Assert.AreEqual(true, result);
        }

    }
}
