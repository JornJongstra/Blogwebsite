namespace Classes
{
	public class Category
	{
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Category(int id)
        {
            Id = id;
        }
        public int Id { get; }

        public string Name { get; }
	}
}
