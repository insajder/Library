using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2
{
    class Book : IBook
    {
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public string Author { get; set; }
        public GenreEnum Genre { get; set; }

        public Book() { }

        public Book(string title, int publishYear, string author)
        {
            Title = title;
            PublishYear = publishYear;
            Author = author;
        }

        public Book(string title, int publishYear, string author, GenreEnum genre)
        {
            Title = title;
            PublishYear = publishYear;
            Author = author;
            Genre = genre;
        }

        public void Print()
        {
            Console.WriteLine($"{Title}, {Author}, {PublishYear}");
        }     

        public override string ToString()
        {
            return $"{Title}, {Author}, {PublishYear}";
        }
    }
    
}
