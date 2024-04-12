using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWebsiteData;
using Classes;

namespace BlogWebsiteCore
{
    public class BlogCoreManager
    {
        public bool CreateBlog(Blog blog)
        {
	        if (!ValidateBlog(blog)) return false;
	        BlogDataManager blogDataManager = new BlogWebsiteData.BlogDataManager();
	        if (blogDataManager.Create(blog))
	        {
	            return true;
	        }

	        return false;
        }

        private bool ValidateBlog(Blog blog)
        {
            // Check if empty
            if (string.IsNullOrWhiteSpace(blog.Title)) return false;
            if (string.IsNullOrWhiteSpace(blog.Text)) return false;
            if (string.IsNullOrEmpty(blog.UserId.ToString())) return false;
            if (string.IsNullOrWhiteSpace(blog.CreatedDateTime.ToString())) return false;
            
            return true;
        }
    }
}
