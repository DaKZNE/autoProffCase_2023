using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    public class Libary : ILibary
    {

        public List<Book> Books { get; private set; }

        public Libary(List<Book> books)
        {
            Books = books;
        }

        public List<Book> addBooks(List<Book> books)
        {
            return Books.Concat(books).ToList();
        }

        public List<Book> removeBooks(List<Book> books)
        {
            return Books.Except(books).ToList();
        }

        public List<Book> FindBooks(string searchString)
        {

            List<string> searchCriteria = searchString.Split(" & ").Select(x => x.Trim('*')).ToList();

            List<Book> returnBooks = new List<Book>();

            List<string> fieldValues = typeof(Book).GetFields().Select(x => x.Name).ToList();

            foreach (Book book in Books)
            {
                int searcCriteriaTotal = searchCriteria.Count;
                int totalCriteriaFilled = 0;
                foreach (string searchWord in searchCriteria)
                {
                    foreach (string field in fieldValues)
                    {
                        dynamic fieldValue = book.GetType().GetField(field).GetValue(book);

                        dynamic vlsjh = fieldValue.GetType().Name;

                        if (fieldValue is List<string>)
                        {
                            foreach (string authors in fieldValue)
                            {
                                if (authors.Contains(searchWord))
                                {
                                    totalCriteriaFilled++;
                                    break;
                                }
                            }
                        }

                        if (fieldValue.ToString().Contains(searchWord))
                        {
                            totalCriteriaFilled++;
                        }
                    }
                }
                if (totalCriteriaFilled == searcCriteriaTotal)
                {
                    returnBooks.Add(book);
                }
            }

            return returnBooks;
        }
    }
}
