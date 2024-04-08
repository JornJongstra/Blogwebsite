using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsiteCore
{
    public class BlogCoreManager
    {
        public string? Title { get; set; }

        public bool CreateBlog()
        {
            BlogWebsiteData.BlogDataManager blogDataManager = new BlogWebsiteData.BlogDataManager();
            if (blogDataManager.Create(Title))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
