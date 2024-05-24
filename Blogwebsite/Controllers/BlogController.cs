using Microsoft.AspNetCore.Mvc;
using BlogWebsiteCore;
using Classes;

namespace BlogWebsite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            List<Blog> blogs = blogCoreManager.GetBlogs();
            ViewBag.Blogs = blogs;
			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);

			return View("Index");
        }
        public IActionResult Detail(int id)
        {
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            Blog blog = blogCoreManager.GetBlog(id);
            ViewBag.Blog = blog;
			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);

			return View("Detail");
        }

        public IActionResult Create()
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			//CategorieCoreManager categorieCoreManager = new CategorieCoreManager();
			CategoryCoreManager categoryCoreManager = new CategoryCoreManager();
	        List<Category> categories = categoryCoreManager.GetCategories();
	        ViewBag.MyList = categories;
			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
			return View();
        }

        public IActionResult Update(int id)
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();


			BlogCoreManager blogCoreManager = new BlogCoreManager();
            var blog = blogCoreManager.GetBlog(id);
            ViewBag.Blog = blog;
            ViewBag.BlogCategories = blog.Categories;

			if (!authController.IsOwnedByUser(blog.UserId)) return NotFound();

			CategoryCoreManager categoryCoreManager = new CategoryCoreManager();
            var categories = categoryCoreManager.GetCategories();
            ViewBag.Categories = categories;

			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);

			return View();
        }
        public IActionResult Delete(int id)
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			BlogCoreManager blogCoreManager = new BlogCoreManager();
            if (blogCoreManager.DeleteBlog(id))
            {
                return RedirectToAction("Index", "Profile");
            }
            return RedirectToAction("Index", "Profile");
        }

        public IActionResult CreateBlog(string blogTitle, int[] blogCategories, string blogText)
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			if (string.IsNullOrWhiteSpace(blogTitle))
            {
                return RedirectToAction("Create");
            }
            if (blogCategories.Length == 0)
            {
	            return RedirectToAction("Create");
            }
            if (string.IsNullOrWhiteSpace(blogText))
            {
	            return RedirectToAction("Create");
            }

			Blog blog = new Blog();
            
            BlogCoreManager blogCoreManager = new BlogCoreManager();

            blog.Title = blogTitle;
            blog.Text = blogText;
            blog.Slug = blogTitle.ToLower();
            blog.UserId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionVariables.SessionKeyUserId));
            blog.CreatedDateTime = DateTime.Now;
            blog.Categories = new List<Category>();

			for (int i = 0; i < blogCategories.Length; i++)
            {
	            Category category = new Category();
	            category.Id = blogCategories[i];
                blog.Categories.Add(category);
            }

            if (blogCoreManager.CreateBlog(blog))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        public IActionResult UpdateBlog(string blogTitle, int[] blogCategories, string blogText, int blogId)
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			if (string.IsNullOrWhiteSpace(blogTitle))
			{
				return RedirectToAction("Update", blogId);
			}
			if (blogCategories.Length == 0)
			{
				return RedirectToAction("Update", blogId);
			}
			if (string.IsNullOrWhiteSpace(blogText))
			{
				return RedirectToAction("Update", blogId);
			}

			Blog blog = new Blog();

			BlogCoreManager blogCoreManager = new BlogCoreManager();

			blog.Title = blogTitle;
			blog.Id = blogId;
			blog.Text = blogText;
			blog.Slug = blogTitle.ToLower();
			blog.UserId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionVariables.SessionKeyUserId));
			blog.CreatedDateTime = DateTime.Now;
			blog.Categories = new List<Category>();

			for (int i = 0; i < blogCategories.Length; i++)
			{
				Category category = new Category();
				category.Id = blogCategories[i];
				blog.Categories.Add(category);
			}

			if (blogCoreManager.UpdateBlog(blog))
			{
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Update", blogId);
			}
		}
    }
}
