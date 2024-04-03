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
		public List<Categorie> Categories { get; set; }
		public List<Like> Likes { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
