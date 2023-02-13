using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    public class Book : iBooks
    {
        public List<string> Authors = new List<string>();
        public string Publisher;
        public int PublicationYear;
        public int NumberOfPages;
        public string Title;

        //Default constructor with no parameters
        public Book()
        {

        }
        //Constructor with parameters
        public Book(List<string> authors, string title, string publisher, int publicationYear, int numberOfPages)
        {
            Authors = authors;
            Publisher = publisher;
            NumberOfPages = numberOfPages;
            PublicationYear = publicationYear;
            Title = title;
        }

        public List<Book> ReadBooks(string input)
        {

            List<Book> books = new List<Book>();
            //Seperates all books into individual datasets
            List<string> rawBookStrings = input.Split("Book:").ToList();

            rawBookStrings.RemoveAt(0); //Removes empty dataset created on position 0 which happens as a cause by the split

            foreach (string rawBookString in rawBookStrings)
            {

                List<string> unbrokenPairs = rawBookString.Split('\n').ToList();

                unbrokenPairs.RemoveAll(pair => pair == ""); //Removes all empty data notations created from the split.

                List<string> authors = new List<string>(); //New List to house all authors

                foreach(string unbrokenPair in unbrokenPairs)
                {
                    if (unbrokenPair.Contains("Author:")) //Sees if data is of a author
                    {
                        authors.Add(unbrokenPair.Split(":")[1]); // takes author name
                    }
                }

                unbrokenPairs.RemoveAll(item => item.Contains("Author")); //Removes all notes of authors from the raw data as those have been put in the authors list and will be returned through that.

                //Seperates all data into key/value pairs
                Dictionary<string, string> keyValuePairs = unbrokenPairs.Select(x => x.Split(':')).ToDictionary(x => x[0], x => x[1].Trim());

                //Builds return object.
                Book returnBook = new Book(authors, keyValuePairs["Title"], keyValuePairs["Publisher"], int.Parse(keyValuePairs["Published"]), int.Parse(keyValuePairs["NumberOfPages"]));
                books.Add(returnBook);

            }

            return books;
        }
    }

}
