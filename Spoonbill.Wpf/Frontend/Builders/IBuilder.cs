namespace Spoonbill.Wpf.Frontend.Builders;

public interface IBuilder<out T>
{
    public T Build();
}