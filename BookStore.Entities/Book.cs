using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public bool isStock { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
