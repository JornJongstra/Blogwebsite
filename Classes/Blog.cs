using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
	public class Blog
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string Slug { get; set; }
		public int UserId { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; }
		public List<Category> Categories { get; set; }
		public List<Comment> Comments { get; set; }
		public List<Like> Likes { get; set; }
	}
}
