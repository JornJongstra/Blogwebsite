using Classes;
using BlogWebsiteCore;

namespace TestBlogWebsiteCore
{
	[TestClass]
	public class BlogCoreManagerUnitTests
	{
        public BlogCoreManagerUnitTests() 
        {
            BlogWebsiteCore.ServiceHandler.SetService(new DataTestService());
        }

        [TestMethod]
        public void TC01_CreateUser_WithValidDate_UserCreated()
        {
            var user = new User("jornj", "wachtwoord", "jorn.jongstra@kpnmail.nl");

            var result = new AuthCoreManager().RegisterUser(user);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TC02_CreateUser_WithNotValidDate_UserCreated()
        {
            var user = new User("_+jorn", "password", "jorn.jongstra@kpnmail.nl");

            var result = new AuthCoreManager().RegisterUser(user);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TC03_CreateUser_WithNotValidDate_UserCreated()
        {
            var user = new User("jornj", "password", "jornjongstrakpnmailnl");

            var result = new AuthCoreManager().RegisterUser(user);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TC04_CreateUser_WithNotValidDate_UserCreated()
        {
            var user = new User("", "password", "jornjongstrakpnmailnl");

            var result = new AuthCoreManager().RegisterUser(user);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TC05_CreateUser_WithNotValidDate_UserCreated()
        {
            var user = new User("jornj", "asdf", "jornjongstrakpnmailnl");

            var result = new AuthCoreManager().RegisterUser(user);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TC06_LoginUser_WithValidDate_UserLogin()
        {
            var user = new User("jorn.jongstra@kpnmail.nl", "password");

            var result = new AuthCoreManager().LoginCheck(user.Email, user.Password);
            //Assert.AreSame("jorn.jongstra@kpnmail.nl", result.Email);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TC07_LoginUser_WithNotValidDate_UserLogin()
        {
            var user = new User("jorn.jongstra@kpnmail.nl", "");

            var result = new AuthCoreManager().LoginCheck(user.Email, user.Password);
            //Assert.AreSame("jorn.jongstra@kpnmail.nl", result.Email);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TC08_LoginUser_WithNotValidDate_UserLogin()
        {
            var user = new User("jornjongstrakpnmailnl", "password");

            var result = new AuthCoreManager().LoginCheck(user.Email, user.Password);
            //Assert.AreSame("jorn.jongstra@kpnmail.nl", result.Email);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TC11_CreateBlog_WithValidData_BlogCreated()
        {
            var blogCoreManager = new BlogCoreManager();

            List<Category> categories = new List<Category>();
            var category = new Category(1, "test");
            categories.Add(category);

            var blog = new Blog("Eindhoven Sport", "Lorem", "eindhoven-sport", 1, DateTime.Now, categories);

            var result = blogCoreManager.CreateBlog(blog);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TC12_CreateBlog_WithNotValidData_BlogCreated()
        {
            var blogCoreManager = new BlogCoreManager();

            List<Category> categories = new List<Category>();

            var blog = new Blog("Zondag voetbal", "Lorem", "eindhoven-sport", 1, DateTime.Now, categories);

            var result = blogCoreManager.CreateBlog(blog);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TC15_UpdateBlog_WithValidData_BlogUpdated()
        {
            var blogCoreManager = new BlogCoreManager();

            List<Category> categories = new List<Category>();
            var category = new Category(1, "test");
            categories.Add(category);


            var blog = new Blog("Eindhoven Sport", "Lorem", "eindhoven-sport", 1 , DateTime.Now, categories);

            var result = blogCoreManager.UpdateBlog(blog);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TC16_UpdateBlog_WithNotValidData_BlogUpdated()
        {
            var blogCoreManager = new BlogCoreManager();

            List<Category> categories = new List<Category>();
            var category = new Category(1, "test");
            categories.Add(category);

            var blog = new Blog("Eindhoven Sport", "", "eindhoven-sport", 1, DateTime.Now, categories);

            var result = blogCoreManager.UpdateBlog(blog);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TC18_DeleteBlog_WithValidData_BlogDeleted()
        {
            var result = new BlogCoreManager().DeleteBlog(5);
            Assert.AreEqual(true, result);
        }

    }
}
