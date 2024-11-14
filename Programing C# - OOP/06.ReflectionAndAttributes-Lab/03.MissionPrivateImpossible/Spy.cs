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

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classField = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods=classType.GetMethods(BindingFlags.Instance| BindingFlags.Public);
            MethodInfo[] classNonPublicMethods=classType.GetMethods(BindingFlags.Instance| BindingFlags.NonPublic);

            StringBuilder resultSB = new StringBuilder();

            foreach (FieldInfo field in classField)
                resultSB.AppendLine($"{field.Name} must be private");

            foreach (MethodInfo method in classPublicMethods)
                resultSB.AppendLine($"{method.Name} have to be public!");

            foreach (MethodInfo method in classNonPublicMethods)
                resultSB.AppendLine($"{method.Name} have to be private!");

            return resultSB.ToString().Trim();

        }

        public string RevealPrivateMethods(string className)
        {
            Type classType= Type.GetType(className);
            MethodInfo[] classMethods=classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder resultSB = new StringBuilder();
            resultSB.AppendLine($"All Private Methods of Class: {className}");
            resultSB.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in classMethods)
            {
                resultSB.AppendLine(method.Name);
            }

            return resultSB.ToString().Trim();
        }
    }
}
