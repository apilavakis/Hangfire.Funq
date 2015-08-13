using Funq;
using Hangfire.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Funq
{
    public static class GlobalConfigurationExtensions
    {
        public static IGlobalConfiguration<FunqJobActivator> UseFunqActivator(
            [NotNull] this IGlobalConfiguration configuration,
            [NotNull] Container container)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (container == null) throw new ArgumentNullException("container");

            return configuration.UseActivator(new FunqJobActivator(container));
        }
    }
}