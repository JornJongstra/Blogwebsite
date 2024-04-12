using Classes;
using BlogWebsiteCore;

namespace TestBlogWebsiteCore
{
	[TestClass]
	public class BlogCoreManagerUnitTests
	{
		[TestMethod]
		public void CreateBlog_WithValidData_BlogCreated()
		{
			Blog blog = new Blog();
			BlogCoreManager blogCoreManager = new BlogCoreManager();
			blog.Title = "Eindhoven Sport";
			blog.Text = "Lorem";
			blog.CreatedDateTime = DateTime.Now;
			//blog.Slug = "eindhoven-sport";
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
			//blog.Slug = "eindhoven-sport";
			blog.UserId = 1;

			bool result = blogCoreManager.CreateBlog(blog);
			Assert.AreEqual(false, result);
		}
	}
}
