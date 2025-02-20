#if ED_VCONTAINER_EXTENSIONS_SUPPORT

namespace ED.Extensions.VContainer
{
    /// <summary>
    /// Marks types as "non-lazy".
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
    public interface INonLazy { }
}

#endif