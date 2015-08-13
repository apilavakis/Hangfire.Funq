using Funq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Funq
{
    public static class FunqExtensions
    {
        public static object TryResolve(this Container container, Type type)
        {
            var methodInfo = typeof(Container).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .First(x => x.Name == "TryResolve" &&
                       x.GetGenericArguments().Length == 1 &&
                       x.GetParameters().Length == 0);

            var genericMethodInfo = methodInfo.MakeGenericMethod(type);
            return genericMethodInfo.Invoke(container, new object[0]); ;
        }
    }
}