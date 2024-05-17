using System.Windows;
using System.Windows.Markup;

namespace Spoonbill.Wpf.Frontend.Extensions;

/// <summary>
/// A Markup Extension that allows for generic types to be used in DataTemplate's DataType binding and other type requirements.
/// </summary>
public class GenericType : MarkupExtension
{
    public Type ResolverType { get; set; } = null!;
    public Type? Generic { get; set; } = null;
    public Type[] Generics { get; set; } = Array.Empty<Type>();

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        GenericTypeResolver? resolver = Activator.CreateInstance(ResolverType) as GenericTypeResolver;
        if (resolver == null)
            throw new ArgumentException($"Property {nameof(ResolverType)} should be of type {nameof(GenericTypeResolver)}");

        Type type = resolver.Resolve();

        List<Type> types = new List<Type>(Generics);
        if (Generic != null)
            types.Add(Generic);

        // if the type is not generic just return it straight
        if (!type.ContainsGenericParameters)
            return type;

        Type genericType = type.MakeGenericType(types.ToArray());
        return genericType;
    }
}

public abstract class GenericTypeResolver
{
    public abstract Type Resolve();
}