using Funq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Funq
{
    /// <summary>
    /// Hangfire Job Activator based on Funq IoC Container.
    /// </summary>
    public class FunqJobActivator : JobActivator
    {
        private Container container;

        /// <summary>
        /// Initializes new instance of WindsorJobActivator with a Windsor Kernel
        /// </summary>
        /// <param name="container">Container that will be used to create instance
        /// of classes during job activation process.</param>
        public FunqJobActivator(Container container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        /// <summary>
        /// Activates a job of a given type using the Funq
        /// </summary>
        /// <param name="type">Type of job to activate</param>
        /// <returns></returns>
        public override object ActivateJob(Type type)
        {
            return container.TryResolve(type);
        }
    }
}