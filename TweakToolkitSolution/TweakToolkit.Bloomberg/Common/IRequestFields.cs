namespace TweakToolkit.Bloomberg.Common
{
    public interface IRequestFields
    {
        string SearchSpec { get; set; }

        bool ReturnFieldDocumentation { get; set; }
    }
}