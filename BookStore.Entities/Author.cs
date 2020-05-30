using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Citizen { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
