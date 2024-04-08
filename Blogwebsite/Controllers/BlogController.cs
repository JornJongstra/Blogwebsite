﻿using Microsoft.AspNetCore.Mvc;
using BlogWebsiteCore;

namespace BlogWebsite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateBlog(string blogTitle)
        {
            if (string.IsNullOrWhiteSpace(blogTitle))
            {
                return RedirectToAction("Create");
            }

            BlogWebsiteCore.BlogCoreManager blog = new BlogWebsiteCore.BlogCoreManager();
            blog.Title = blogTitle;
            if (blog.CreateBlog())
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