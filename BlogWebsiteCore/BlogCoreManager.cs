﻿using Classes;

namespace BlogWebsiteCore
{
    public class BlogCoreManager
    {
        public bool CreateBlog(Blog blog)
        {
	        if (!ValidateBlog(blog)) return false;
	        if (ServiceHandler.Service.CreateBlog(blog))
	        {
	            return true;
	        }

	        return false;
        }

        public bool UpdateBlog(Blog blog)
        {
	        if (!ValidateBlog(blog)) return false;
			if (ServiceHandler.Service.UpdateBlog(blog))
			{
				return true;
			}

			return false;
		}
        public bool DeleteBlog(int id)
        {
            if (ServiceHandler.Service.DeleteBlog(id))
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
            if (blog.Categories.Count == 0) return false;
            
            return true;
        }

        public Blog GetBlog(int id)
        {
	        return ServiceHandler.Service.GetBlog(id);
        }

        public List<Blog> GetBlogs()
        {
	        return ServiceHandler.Service.GetBlogs();
        }
    }
}
