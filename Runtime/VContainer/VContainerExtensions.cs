#if ED_VCONTAINER_EXTENSIONS_SUPPORT

using System.Collections.Generic;
using VContainer;

namespace ED.Extensions.VContainer
{
    public static class VContainerExtensions
    {
        /// <summary>
        /// Force to create objects, which marked as "non-lazy" by interface.
        /// <a href="https://discussions.unity.com/t/vcontainer-does-not-create-an-instance-of-my-service/940846/10">Unity Discussions Post</a>
        /// <example>
        /// <code>
        /// public class SomeService : INonLazy
        /// {
        ///     // service stuff
        /// }
        /// protected override void Configure(IContainerBuilder builder)
        /// {
        ///     builder.Register<![CDATA[<SomeService>]]>().AsImplementedInterfaces();
        ///     builder.ForceCreateNonLazyTypes()
        /// }
        /// </code>
        /// </example>
        /// </summary>
        public static void ForceCreateNonLazyTypes(this IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(r => r.Resolve<IEnumerable<INonLazy>>());
        }
    }
}

#endif