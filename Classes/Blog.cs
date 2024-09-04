namespace Classes
{
	public class Blog
	{
        public Blog(int id, string title, string text) 
        { 
            Id = id;
            Title = title;
            Text = text;
        }
        public Blog(int id, string title, string text, int userId, string author, List<Category> categories)
        {
            Id = id;
            Title = title;
            Text = text;
            UserId = userId;
            Author = author;
            Categories = categories;
        }
        public Blog(int id, string title, string text, string slug, int userId)
        {
            Id = id;
            Title = title;
            Text = text;
            Slug = slug;
            UserId = userId;
        }
        public Blog(int id, string title, string text, string slug, string author)
        {
            Id = id;
            Title = title;
            Text = text;
            Slug = slug;
            Author = author;
        }
        public Blog(int id, string title, string text, string slug, string author, List<Category> categories)
        {
            Id = id;
            Title = title;
            Text = text;
            Slug = slug;
            Author = author;
            Categories = categories;
        }
        public Blog(string title, string text, int userId, string author, List<Category> categories) 
        {
            Title = title;
            Text = text;
            UserId = userId;
            Author = author;
            Categories = categories;
        }
        public Blog(string title, string text, string slug, int userId, DateTime createdDateTime, List<Category> categories)
        {
            Title = title;
            Text = text;
            UserId = userId;
            Slug = slug;
            CreatedDateTime = createdDateTime;
            Categories = categories;
        }
        public Blog(string title, string text, int userId, string author)
        {
            Title = title;
            Text = text;
            UserId = userId;
            Author = author;
        }
        public Blog(int id, string title, string text, string slug, int userId, DateTime createdDateTime, List<Category> categories) 
        {
            Id = id;
            Title = title;
            Text = text;
            UserId = userId;
            Slug = slug;
            CreatedDateTime = createdDateTime;
            Categories = categories;
        }

        public int Id { get; }
        public string Title { get; }
		public string Text { get; }
		public string Slug { get; }
		public int UserId { get; }
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; }
		public List<Category> Categories { get; set; }
		public List<Comment> Comments { get; set; }
		public List<Like> Likes { get; set; }
	}


}
