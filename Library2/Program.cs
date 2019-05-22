using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Library2
{
    class Program
    {
        /* • Napraviti C# program za Biblioteku koji koristi Enumerations,
            Negeneričke kolekcije, Generičke kolekcije, Dictionary definisati
            potrebne klase, atribute i metode. Primer: List <Knjiga>
            KnjigeBiblioteka
            • Program treba da sadrži sledeći mogućnosti
            – Unos podataka u obe vrste kolekcija
            – Podatke zapisati u .txt fajl
            – Koristiti logger biblioteku po želji
            – Štampa svih podatke iz obe vrste kolekcija 
            • Proširiti postojeći C# program za Biblioteku sa upotrebom Interfejsa, Liste
            • Primer: Interfejs IStudent
            • Program treba da sadrži sledeći mogućnosti
            – Pretragu podataka u obe vrste kolekcija */

        static void Main(string[] args)
        {
            List<Book> allBooks = new List<Book>();
            allBooks.Add(new Book("Origin", 2017, "Dan Brown", GenreEnum.MYSTERY));
            allBooks.Add(new Book("Inferno", 2013, "Dan Brown", GenreEnum.MYSTERY));
            allBooks.Add(new Book("The Gods Themselves", 1972, "Isaac Asimov", GenreEnum.FANTASY));
            allBooks.Add(new Book("Necronomicon", 2008, "H. P. Lovecraft", GenreEnum.HORROR));

            int option = 0;

            do
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1.Add book \n2.Search books \n3.Print books \n4.Write books in file \n5.Exit");
                try
                {
                    option = int.Parse(Console.ReadLine());

                    switch(option)
                    {
                        case 1:
                            AddBook(allBooks);
                            break;
                        case 2:
                            SearchBook(allBooks);
                            break;
                        case 3:
                            PrintBooks(allBooks);
                            break;
                        case 4:
                            WriteBookInFile(allBooks);
                            break;
                        case 5:
                            FileLogger.Info("The End");
                            break;
                        default:
                            Console.Write("Invalid option! Try again.");
                            FileLogger.Error("Error! Wrong entry.");
                            break;
                    }
                } catch(Exception e)
                {
                    Console.WriteLine(e);
                    FileLogger.Warn("Error! Wrong entry.");
                }
            } while (option != 5);
        }

        private static void WriteBookInFile(List<Book> allBooks)
        {
            if (allBooks.Count > 0)
            {
                string path = @"C:\Users\Public\Books.txt";

                foreach (Book b in allBooks)
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(b);
                    }
                }
            }
            else
            {
                Console.WriteLine("No book in library.");
            }
        }

        public static void PrintGenres()
        {
            //Console.WriteLine("1.Drama \n2.Tragedy \n3.Fantasy \n4.Horror \n5.Mystery");
            int i = 1;
            string[] enumNames = Enum.GetNames(typeof(GenreEnum));
            foreach (string enumName in enumNames)
            {
                Console.WriteLine($"{i++}.{enumName}");
            }
        }

        private static void PrintBooks(List<Book> allBooks)
        {
            if (allBooks.Count > 0) {
                Console.WriteLine("==================");
                Console.WriteLine("Books in library:");
                foreach (Book b in allBooks)
                {
                    b.Print();
                }
                Console.WriteLine("==================");
            } else {
                Console.WriteLine("No book in library.");
            }
        }

        private static void SearchBook(List<Book> allBooks)
        {
            if (allBooks.Count > 0)
            {
                Console.WriteLine("Enter the title of the book:");
                string searchTerm = Console.ReadLine();
                Book b = allBooks.Find(book => book.Title == searchTerm);
                if(b == null)
                {
                    Console.WriteLine("No book in library with requested title.");
                } else
                {
                    Console.WriteLine("==================");
                    Console.Write("Book found: ");
                    b.Print();
                    Console.WriteLine("==================");
                }
            }
            else
            {
                Console.WriteLine("No book in library.");
            }
        }

        private static void AddBook(List<Book> allBooks)
        {
            string title = ""; int publishYear = 0; string author = ""; GenreEnum genre = GenreEnum.DRAMA;
            bool error;
            do
            {
                error = false;
                try
                {
                    Console.WriteLine("Enter title of the book:");
                    title = Console.ReadLine();
                    Console.WriteLine("Enter publishing year of the book:");
                    publishYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter author of the book:");
                    author = Console.ReadLine();
                    PrintGenres();
                    genre = (GenreEnum)int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    error = true;
                }
                if(!Enum.IsDefined(typeof(GenreEnum), genre))
                {
                    error = true;
                }
                if (error)
                {
                    Console.WriteLine("Error! Wrong entry.");
                    FileLogger.Error("Error! Wrong entry.");
                }
            } while (error);

            Book book = new Book(title, publishYear, author, genre);
            allBooks.Add(book);

            /* string title; int publishYear; string author; GenreEnum genre;
            try
            {
                Console.WriteLine("Enter title of the book:");
                title = Console.ReadLine();
                Console.WriteLine("Enter publishing year of the book:");
                publishYear = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter author of the book:");
                author = Console.ReadLine();

                Book book = new Book(title, publishYear, author);

                PrintGenres();
                genre = (GenreEnum)int.Parse(Console.ReadLine());

                genre = int.Parse(Console.ReadLine());
                switch(genre)
                {
                    case 1:
                        book.Genre = GenreEnum.DRAMA;
                        break;
                    case 2:
                        book.Genre = GenreEnum.TRAGEDY;
                        break;
                    case 3:
                        book.Genre = GenreEnum.FANTASY;
                        break;
                    case 4:
                        book.Genre = GenreEnum.HORROR;
                        break;
                    case 5:
                        book.Genre = GenreEnum.MYSTERY;
                        break;
                } 
                
                allBooks.Add(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                FileLogger.Error("Error! Wrong entry.");
            } */
        }
    }
}
