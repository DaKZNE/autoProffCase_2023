using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    public class Shelf : IShelf
    {

        public List<ShelfSlot> ShelfSlot { get; private set; }
        public int shelfID { get; private set; }

        public Shelf(int ID,List<ShelfSlot> books)
        {
            ShelfSlot = books;
            shelfID = ID;
        }

        public List<ShelfSlot> addBooks(List<ShelfSlot> books)
        {
            ShelfSlot.AddRange(books);

            return ShelfSlot;
        }

        public List<ShelfSlot> removeBooks(List<ShelfSlot> books)
        {
            return ShelfSlot.Except(books).ToList();
        }

        public List<ShelfSlot> FindBooks(string searchString)
        {

            List<string> searchCriteria = searchString.Split(" & ").Select(x => x.Trim('*')).ToList();

            List<ShelfSlot> returnBooks = new List<ShelfSlot>();

            List<string> fieldValues = typeof(Book).GetFields().Select(x => x.Name).ToList();

            List<string> filteredFieldValues = new List<string>() { "NumberOfPages" };

            fieldValues.RemoveAll(x => filteredFieldValues.Contains(x));

            foreach (ShelfSlot shelf in ShelfSlot)
            {
                int searcCriteriaTotal = searchCriteria.Count;
                int totalCriteriaFilled = 0;
                foreach (string searchWord in searchCriteria)
                {
                    foreach (string field in fieldValues)
                    {
                        dynamic fieldValue = shelf.book.GetType().GetField(field).GetValue(shelf.book);

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
                    returnBooks.Add(shelf);
                }
            }

            return returnBooks;
        }
    }

    public class ShelfSlot
    {
        public Book book { get; private set; }

        public int placement { get; private set; }


        public ShelfSlot (Book book, int placement)
        {
            this.book = book;
            this.placement = placement;
        }


    }
}
