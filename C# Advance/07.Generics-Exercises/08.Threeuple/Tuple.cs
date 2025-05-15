using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threeuple;

public class Tuple<TOne,TTwo,TThree>
{
    public Tuple(TOne itemOne,TTwo itemTwo, TThree itemThree)
    {
        this.ItemOne = itemOne;
        this.ItemTwo = itemTwo;
        this.ItemThree = itemThree;
    }
    public TOne ItemOne { get; set; }
    public TTwo ItemTwo { get; set; }
    public TThree ItemThree { get; set; }

    public override string ToString()
    {

        return $"{ItemOne} -> {ItemTwo} -> {ItemThree}";
    }

}
