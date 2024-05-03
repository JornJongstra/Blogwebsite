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

            return View("Index");
        }
        public IActionResult Detail(int id)
        {
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            Blog blog = blogCoreManager.GetBlog(id);
            ViewBag.Blog = blog;

            return View("Detail");
        }

        public IActionResult Create()
        {
	        //CategorieCoreManager categorieCoreManager = new CategorieCoreManager();
            CategoryCoreManager categoryCoreManager = new CategoryCoreManager();
	        List<Category> categories = categoryCoreManager.GetCategories();
	        ViewBag.MyList = categories;
            return View();
        }

        public IActionResult Update(int blogId)
        {
            BlogCoreManager blogCoreManager = new BlogCoreManager();
            var blog = blogCoreManager.GetBlog(blogId);
            ViewBag.MyList = blog;
            return View();
        }

        public IActionResult CreateBlog(string blogTitle, int[] blogCategories, string blogText)
        {
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
    }
}
