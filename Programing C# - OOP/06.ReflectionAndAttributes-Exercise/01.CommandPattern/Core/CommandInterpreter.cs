using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {      
        public string Read(string args)
        {
            string[] array= args.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string commandName= array[0];
            string[] commandsArgs=array.Skip(1).ToArray();

            Dictionary<string,Type> commandTypes=Assembly.GetEntryAssembly().GetTypes()
                .Where(t=>t.Name.EndsWith("Command")).ToDictionary(t=>t.Name.Replace("Command",""), t=> t);

            if (!commandTypes.ContainsKey(commandName)) throw new InvalidOperationException("Wrong command!");

            ICommand mycom = (ICommand)Activator.CreateInstance(commandTypes[commandName]);
            return mycom.Execute(commandsArgs);

        }

        //----------- Alternative ----------:

        //public string Read(string args)
        //{
        //    string[] array= args.Split(" ",StringSplitOptions.RemoveEmptyEntries);
        //    string commandName= array[0];
        //    string[] commandsArgs=array.Skip(1).ToArray();

        //    Type typeCM=Assembly.GetEntryAssembly().GetTypes().First(x=>x.Name==$"{commandName}Command");

        //    if (typeCM == null) throw new InvalidOperationException("Wrong command!");

        //    ICommand mycom = (ICommand)Activator.CreateInstance(typeCM);
        //    return mycom.Execute(commandsArgs);

        //} 
    }
}
