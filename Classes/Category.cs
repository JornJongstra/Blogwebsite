using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
