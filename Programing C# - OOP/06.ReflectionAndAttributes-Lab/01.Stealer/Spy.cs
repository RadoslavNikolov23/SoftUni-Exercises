using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        //StealFieldInfo

        public string StealFieldInfo(string nameToInvestigae, params string[] fieldsToIvestigate)
        {
            Type classType=Type.GetType(nameToInvestigae)!;

            FieldInfo[] classFields=classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            
            Object classInstance=  Activator.CreateInstance(classType, new object[] { })!;

            StringBuilder resultSB=new StringBuilder();

            resultSB.AppendLine($"Class under investigation: {classType}");

            foreach (FieldInfo field in classFields.Where(x=>fieldsToIvestigate.Contains(x.Name)))
                resultSB.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");

            return resultSB.ToString().Trim();
        }
    }
}
