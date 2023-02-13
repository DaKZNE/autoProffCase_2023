using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    interface IShelf
    {
        List<ShelfSlot> FindBooks(string searchString);
        public List<ShelfSlot> removeBooks(List<ShelfSlot> books);
        public List<ShelfSlot> addBooks(List<ShelfSlot> books);
    }
}
