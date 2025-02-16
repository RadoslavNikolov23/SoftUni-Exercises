using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM
{
    public class ExceptionMessages
    {
        public static string ItemCanBeNullAttribute=
             $"Item cannot be null";

        public static string InvalidOperation =
            "{0} Invalid Entities found in {1}!";
    }
}
