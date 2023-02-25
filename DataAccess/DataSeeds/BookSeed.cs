using Domain.Entities;

namespace DataAccess.DataSeeds
{
    public class BookSeed
    {
        public static IEnumerable<Book> Data()
        {
            List<Book> data = new()
            {
                new Book
                {
                    Id = 1,
                    Title = "Harry Potter and Philosopher's Stone",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                },
                new Book
                {
                    Id = 2,
                    Title = "Harry Potter and Chamber of Secrets",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                },
                new Book
                {
                    Id = 3,
                    Title = "Harry Potter and Prisoner of Azkaban",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                },
                new Book
                {
                    Id = 4,
                    Title = "Harry Potter and Goblet of Fire",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                },
                new Book
                {
                    Id = 5,
                    Title = "Harry Potter and Order of the Phoenix",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                },
                new Book
                {
                    Id = 6,
                    Title = "Harry Potter and Half-Blood Prince",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                },
                new Book
                {
                    Id = 7,
                    Title = "Harry Potter and Deathly Hallows",
                    Author = "Rowling",
                    Genre = "Fantasy",
                    Content = "Harry Potter is a series of seven " +
                              "fantasy novels written by British author" +
                              " J. K. Rowling. The novels chronicle the " +
                              "lives of a young wizard, Harry Potter, and" +
                              " his friends Hermione Granger and Ron Weasley," +
                              " all of whom are students at Hogwarts School of" +
                              " Witchcraft and Wizardry.",
                    Cover = "Paper"
                }
            };
            return data;
        }
    }
}
