using System.Collections.ObjectModel ;
using Autodesk.Revit.DB ;
using revit_family_viewer.Service ;

namespace revit_family_viewer.ViewModel
{
  public class FamilyTypeFilteringViewModel
  {
    public ObservableCollection<Category> Categories { get; private set; } = new ObservableCollection<Category>();
    
    public FamilyTypeFilteringViewModel(Document doc)
    {
      var categoryService = new CategoryService(doc) ;
      var allCategories = categoryService.GetAllCategories();
      foreach (var cat in allCategories)
      {
        Categories.Add(cat);
      }
    }
  }
}