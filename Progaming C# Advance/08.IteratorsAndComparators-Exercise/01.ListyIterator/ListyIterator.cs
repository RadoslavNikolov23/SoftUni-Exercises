using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators;

public class ListyIterator<T>
{
    public ListyIterator(List<T> element)
    {
        this.elements = element ?? throw new ArgumentNullException(nameof(element));
        internalIndex = 0;
    }

    private List<T> elements;
    private int internalIndex;

    public bool Move()
    {
        if (!HasNext()) return false;

        internalIndex++; 
        return true;
    }

    public bool HasNext()
    {
        if(internalIndex+1<this.elements.Count) return true;
        return false;
    }

    public void Print()
    {
        if(this.elements.Count!=0)
        Console.WriteLine($"{this.elements[internalIndex]}");
        else
        Console.WriteLine("Invalid Operation!");
    }

}
