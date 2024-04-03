using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public List<Blog> Blogs { get; set; }
		public List<Like> Likes { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
