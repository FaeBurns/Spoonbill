using System.Windows.Markup;

namespace Spoonbill.Wpf.Frontend.Extensions;

// https://community.devexpress.com/blogs/wpf/archive/2022/02/07/dependency-injection-in-a-wpf-mvvm-application.aspx
public class DISource : MarkupExtension
{
    public static Func<Type, object> Resolver { get; set; } = null!;
    public Type Type { get; set; } = null!;
    public override object ProvideValue(IServiceProvider serviceProvider) => Resolver.Invoke(Type);
}