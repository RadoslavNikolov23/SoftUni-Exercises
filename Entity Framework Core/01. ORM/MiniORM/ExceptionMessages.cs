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
        public static string ItemCanBeNullAttribute =
             $"Item cannot be null";

        public static string InvalidOperation =
            "{0} Invalid Entities found in {1}!";

        public static string NoTableNameFound =
           "Could not find a valid table name for DbSet {0}!";

        public static string InvalidNavigationPropertyName =
           "Foreign key {0} references navigation property with name {1} which does not exist!";

        public static string NavPropertyWithoutDbSetMessage =
            "DbSet could not be found for navigation property {0} of type {1}!";

    }
}