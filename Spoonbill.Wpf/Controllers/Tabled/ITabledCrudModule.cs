using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Tabled;

public interface ITabledCrudModule<TModel, in TKey> where TModel : class
{
    public IResult Create(TModel model);
    public TModel? Read(TKey key);
    public IResult Update(TModel model);
    public IResult Destroy(TModel model);
    public ICollection<TModel> List();
}