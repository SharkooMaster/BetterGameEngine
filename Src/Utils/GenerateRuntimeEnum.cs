using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace BetterGameEngine.Utils
{
    public static class GenerateRuntimeEnum
    {
        public static Type Generate(string _name, string _aName, string[] _enums)
        {
            AppDomain current = AppDomain.CurrentDomain;

            AssemblyName aName = new AssemblyName(_aName);
            AssemblyBuilder aBuilder = current.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder mBuilder = aBuilder.DefineDynamicModule(aName.Name, aName.Name + ".dll");

            EnumBuilder eBuilder = mBuilder.DefineEnum(_name, TypeAttributes.Public, typeof(Enum));

            int i = 0;
            foreach (string _e in _enums)
            {
                eBuilder.DefineLiteral(_e, i);
                i++;
            }

            Type finished = eBuilder.CreateType();
            aBuilder.Save(aName.Name + ".dll");

            Assembly asm = Assembly.LoadFrom(aName.Name + ".dll");
            return asm.GetType(_name);
        }
    }
}

