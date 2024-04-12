using Microsoft.AspNetCore.Mvc;
using BlogWebsiteCore;
using Classes;

namespace BlogWebsite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Update()
        {
            return View("Update");
        }

        public IActionResult CreateBlog(string blogTitle)
        {
            if (string.IsNullOrWhiteSpace(blogTitle))
            {
                return RedirectToAction("Create");
            }

            Blog blog = new Blog();
            BlogCoreManager blogCoreManager = new BlogCoreManager();

            blog.Title = blogTitle;
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
