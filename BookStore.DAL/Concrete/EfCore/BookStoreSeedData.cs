using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Concrete.EfCore
{
    public static class BookStoreSeedData
    {
        public static void EnsureSeedData(this BookStoreContext db)
        {
            if (!db.Books.Any() || !db.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author
                    {
                        Name = "Stephen",
                        Surname = "King",
                        Citizen = "USA",
                        Books = new List<Book>
                        {
                            new Book
                            {
                                Name = "It",
                                Description = "King began writing the novel in 1981, having first conceived of the tale in 1978.",
                                isStock = true,
                                Publisher = "Alfa",
                                Price = 45
                            },
                            new Book
                            {
                                Name = "The Dead Zone",
                                Description = "The Dead Zone is the eighth book published by Stephen King; it is his seventh novel, and the fifth novel under his own name.",
                                isStock = true,
                                Publisher = "Mega",
                                Price = 35
                            },
                            new Book
                            {
                                Name = "The Shining",
                                Description = "The Shining is the third book published by Stephen King; it is his third novel.",
                                isStock = false,
                                Publisher = "Teta",
                                Price = 10

                            }
                        }

                    },
                    new Author
                    {
                        Name = "Tess",
                        Surname = "Gerritsen",
                        Citizen = "USA",
                        Books = new List<Book>
                        {
                            new Book
                            {
                                Name = "The Surgeon",
                                Description = "In Boston, there’s a killer on the loose. A killer who targets lone women, who breaks into their apartments.",
                                isStock = true,
                                Publisher = "Alfa",
                                Price = 50
                            },
                            new Book
                            {
                                Name = "The Apprentice",
                                Description = "A year has passed since the capture of the Surgeon, serial killer Warren Hoyt, yet the memory of his brutal crimes continues to haunt Boston homicide detective Jane Rizzoli.",
                                isStock = true,
                                Publisher = "Mega",
                                Price = 5
                            },
                            new Book
                            {
                                Name = "Body Double",
                                Description = "As a pathologist in downtown Boston, she has seen more than her share of corpses. But never before has the body on the medical examiner’s table been her own.",
                                isStock = false,
                                Publisher = "Teta",
                                Price = 30
                            }
                        }

                    },
                    new Author
                    {
                        Name = "Markus",
                        Surname = "Zuzak",
                        Citizen = "Australia",
                        Books = new List<Book>
                        {
                            new Book
                            {
                                Name = "The Book Thief",
                                Description = "It is 1939. Nazi Germany. The country is holding its breath. Death has never been busier, and will be busier still.",
                                isStock = true,
                                Publisher = "Alfa",
                                Price = 20
                            },
                            new Book
                            {
                                Name = "I Am the Messenger",
                                Description = "Ed Kennedy is an underage cabdriver without much of a future. He's pathetic at playing cards, hopelessly in love with his best friend.",
                                isStock = true,
                                Publisher = "Mega",
                                Price = 25
                            },
                            new Book
                            {
                                Name = "Bridge of Clay",
                                Description = "The breathtaking story of five brothers who bring each other up in a world run by their own rules.",
                                isStock = false,
                                Publisher = "Teta",
                                Price = 40
                            }
                        }

                    }
                };
                db.Authors.AddRange(authors);
                db.SaveChanges();
            }
        }
    }
}
