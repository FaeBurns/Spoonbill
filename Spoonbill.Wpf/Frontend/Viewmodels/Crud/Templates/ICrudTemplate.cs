using System.Windows;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public interface ICrudTemplate
{
    /// <summary>
    /// Gets the template to use for a list item.
    /// </summary>
    public DataTemplate ListTemplate { get; }
    
    /// <summary>
    /// Gets the template to use for introspection.
    /// </summary>
    public DataTemplate IntrospectTemplate { get; }
    
    /// <summary>
    /// Builds the collection of data to populate the list view with. 
    /// </summary>
    /// <returns></returns>
    public ICollection<object> BuildList();
    
    /// <summary>
    /// Saves a change to the database.
    /// </summary>
    /// <param name="model">The model to save.</param>
    /// <param name="mode">The mode to save it in.</param>
    /// <returns>The result of the database operation.</returns>
    public IResult Save(object model, IntrospectMode mode);

    /// <summary>
    /// Deletes the model from the database.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public IResult Delete(object model);
}