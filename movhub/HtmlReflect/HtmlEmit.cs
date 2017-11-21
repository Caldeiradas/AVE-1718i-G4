using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace HtmlReflect
{


    interface PropertyInfoGetter
    {
        string GetHtmlString(object target);
    }

    public abstract class AbstractPropGetter : PropertyInfoGetter
    {
        public abstract string GetHtmlString(object target);

        public static string FormatNotIgnoreToHtml(string name, string value)
        {
            return String.Format("<li class='list-group-item'><strong>{0}</strong>:{1}</li>", name, value);
        }

        public static string FormatHtmlAsToHtml(string htmlRef, string name, string value)
        {
            return htmlRef.Replace("{name}", name.Replace("{value}", value));
        }
    }

    public class HtmlEmit
    {
        static readonly MethodInfo FormatNotIgnoreToHtml = typeof(AbstractPropGetter).GetMethod("FormatNotIgnoreToHtml", new Type[] { typeof(String), typeof(String) });
        static readonly MethodInfo FormatHtmlAsToHtm = typeof(AbstractPropGetter).GetMethod("FormatHtmlAsToHtml", new Type[] { typeof(String), typeof(String), typeof(object) });
        

        //maps a type to its emited methods
        static Dictionary<Type, PropertyInfoGetter> markedProps = new Dictionary<Type, PropertyInfoGetter>();

        public string ToHtml(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfoGetter getter;
            if (!markedProps.TryGetValue(objType, out getter))
            {
                getter = EmitGetter(objType);
                markedProps.Add(objType, getter);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='list-group'>");
            sb.Append(getter.GetHtmlString(obj));
            sb.Append("</ul>");
            return sb.ToString();
        }


        public string ToHtml(object[] arr)
        {
            return null;
        }


        private PropertyInfoGetter EmitGetter(Type objType)
        {
            string name = objType.Name + "PropertyInfoGetter";
            AssemblyName asmName = new AssemblyName(name);

            AssemblyBuilder asmB =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    asmName,
                    AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder moduleB =
                asmB.DefineDynamicModule(name, name + ".dll");

            TypeBuilder typeB = moduleB.DefineType(
                name,
                TypeAttributes.Public,
                typeof(AbstractPropGetter));

            MethodBuilder methodB = typeB.DefineMethod(
                "GetHtmlString",
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.ReuseSlot,
                typeof(string), // Return type
                new Type[] { typeof(object) }); // Type of arguments

            ILGenerator il = methodB.GetILGenerator();

            PropertyInfo[] props = objType.GetProperties();

            LocalBuilder target = il.DeclareLocal(objType);
            il.Emit(OpCodes.Ldarg_1);          // push target
            il.Emit(OpCodes.Castclass, objType); // castclass
            il.Emit(OpCodes.Stloc, target);    // store on local variable 

            foreach (PropertyInfo p in props)
            {
                object[] attrs = p.GetCustomAttributes(typeof(HtmlIgnoreAttribute), true);
                if (attrs.Length != 0) continue;
                il.Emit(OpCodes.Ldstr, p.Name);    // push on stack the property name
                                                   //  il.Emit(OpCodes.Ldloc, target);    // ldloc target

                //MethodInfo pGetMethod = objType.GetProperty(p.Name,
                //   BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                //   ).GetGetMethod(true);
                il.Emit(OpCodes.Ldloc, target);    // ldloc target
                //il.Emit(OpCodes.Callvirt, objType.GetMethod(pGetMethod.Name, new Type[] { typeof(object) }));
                // if (p.PropertyType.IsValueType)
                //       il.Emit(OpCodes.Box, p.PropertyType); // box
                //il.Emit(OpCodes.Call, FormatNotIgnoreToHtml);

            }



                Type getterType = typeB.CreateType();

            asmB.Save(asmName.Name + ".dll");

            return (PropertyInfoGetter)Activator.CreateInstance(getterType);
        }
    }
}

