using System.Collections.Generic ;
using System.Linq ;
using Autodesk.Revit.DB ;

namespace revit_family_viewer.Service
{
  public class CategoryService
  {
    private readonly Document _document;

    public CategoryService(Document document)
    {
      _document = document;
    }

    public IEnumerable<Category> GetAllCategories()
    {
      return _document.Settings.Categories.Cast<Category>().Where( cat => cat.CategoryType == CategoryType.Model ) ;
    }
  }
}