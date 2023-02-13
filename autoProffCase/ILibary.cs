using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoProffCase
{
    interface ILibary
    {
        List<Book> FindBooks(string searchString);
    }
}
