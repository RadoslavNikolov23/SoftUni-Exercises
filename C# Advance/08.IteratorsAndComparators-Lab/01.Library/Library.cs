using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators;

public class Library:IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }
    private List<Book> books { get; set; }

    public IEnumerator<Book> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
