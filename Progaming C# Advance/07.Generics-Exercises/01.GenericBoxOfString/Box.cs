using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString;

public class Box<TValue>
{
    public Box(TValue element)
    {
        Element = element;
    }

    public TValue Element { get; set; }

    public override string ToString()
    {
        Type type = typeof(TValue);
        return $"{type}: {Element}";
    }
}
