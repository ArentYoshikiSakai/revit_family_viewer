using System.Collections.Generic ;
using System.Linq ;
using Autodesk.Revit.DB ;

namespace revit_family_viewer.Service
{
  public class FamilyService
  {
    private readonly Document _document;
    public FamilyService(Document doc)
    {
      _document = doc;
    }

    public IList<Family> GetFamiliesForCategory(Category category)
    {
      // BuiltInCategory builtInCategory = (BuiltInCategory)category.Id.IntegerValue;
      // FilteredElementCollector collector = new FilteredElementCollector(_document).OfClass(typeof(Family)).OfCategory(builtInCategory);
      FilteredElementCollector collector = new FilteredElementCollector(_document);
      collector.OfClass(typeof(Family))
        .WherePasses(new ElementCategoryFilter(category.Id));

      return collector.Cast<Family>().ToList();
    }
  }
}