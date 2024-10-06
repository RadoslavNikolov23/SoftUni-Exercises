using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple;

public class Tuple<TOne,TTwo>
{
    public Tuple(TOne itemOne,TTwo itemTwo)
    {
        this.ItemOne = itemOne;
        this.ItemTwo = itemTwo;
    }
    public TOne ItemOne { get; set; }
    public TTwo ItemTwo { get; set; }

    public override string ToString()
    {

        return $"{ItemOne} -> {ItemTwo}";
    }

}
