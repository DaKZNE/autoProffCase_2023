using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    public class Libary : iLibary
    {

        public List<Shelf> Shelfs { get; private set; }

        public Libary (List<Shelf> shelfs) {
            Shelfs = shelfs;
        }

        public Index FindBooks(string searchString)
        {
            Index index = new Index();

            foreach (Shelf shelf in Shelfs) {
                List<ShelfSlot> tempBooks = shelf.FindBooks(searchString);
                if(tempBooks.Count > 0) {
                    index.insertIndexedBooks(tempBooks);
                    index.insertIndex(shelf.shelfID);
                }

            }
            return index;
        }

        public Shelf InsertBooks(List<ShelfSlot> book, int shelf)
        {
            Shelf shelfToInsert = Shelfs.FirstOrDefault(x => x.shelfID == shelf);

            shelfToInsert.addBooks(book);

            return shelfToInsert;
        }
    }


    public class Index
    {
        public List<ShelfSlot> PlacedBooks { get; private set; } = new List<ShelfSlot>();   
        public List<int> shelveIdList { get; private set; } = new List<int>();

        public Index()
        {

        }

        public List<ShelfSlot> insertIndexedBooks(List<ShelfSlot> books)
        {
            this.PlacedBooks.AddRange(books);
            return this.PlacedBooks;

        }

        public List<int> insertIndex(int index)
        {
            shelveIdList.Add(index);
            return this.shelveIdList;
        }
    }
}
