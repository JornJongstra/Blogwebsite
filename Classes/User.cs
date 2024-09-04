namespace Classes
{
	public class User
	{
        public User(string email, string password) 
        { 
            Email = email;
            Password = password;
        }
        public User(int id, string username, string password, string email, List<Blog>? blogs, List<Like>? likes, List<Comment>? comments)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Blogs = blogs;
            Likes = likes;
            Comments = comments;
        }

        public User (int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public User(int id, string username, string password, string email, List<Blog>? blogs)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Blogs = blogs;
        }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public int Id { get; }
		public string Username { get; }
		public string Password { get; private set; }
		public string Email { get; }
		public List<Blog>? Blogs { get; }
		public List<Like>? Likes { get; }
		public List<Comment>? Comments { get; }

        public void SetPassword(string newPassword)
        {
            this.Password = newPassword;
        }
	}
}
