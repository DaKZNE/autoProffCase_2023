using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    interface iLibary
    {
        Index FindBooks(string searchString);

        Shelf InsertBooks(List<ShelfSlot> book, int shelf);

    }
}
