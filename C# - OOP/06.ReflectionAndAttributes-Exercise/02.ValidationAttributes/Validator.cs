using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null) return false;

            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] atributes=property.GetCustomAttributes<MyValidationAttribute>().ToArray();
                Object propertyValue = property.GetValue(obj);


                foreach (var attribute in atributes)
                {
                    if (!attribute.IsValid(propertyValue)) return false;

                }
            }
            return true;
        }
    }
}
