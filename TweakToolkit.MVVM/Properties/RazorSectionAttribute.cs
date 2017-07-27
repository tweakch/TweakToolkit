using System;

namespace TweakToolkit.MVVM.Properties
{
    /// <summary>
    ///     Razor attribute. Indicates that a parameter or a method is a Razor section.
    ///     Use this attribute for custom wrappers similar to
    ///     <see cref="System.Web.WebPages.WebPageBase.RenderSection(string)" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method, Inherited = true)]
    public sealed class RazorSectionAttribute : Attribute
    {
    }
}