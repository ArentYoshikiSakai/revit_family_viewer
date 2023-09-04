using System.Collections.Generic ;
using System.Linq ;
using Autodesk.Revit.DB ;

namespace revit_family_viewer.Service
{
  public class FamilyTypeService
  {
    private readonly Document _document;
    public FamilyTypeService(Document doc)
    {
      _document = doc;
    }

    public IList<FamilySymbol> GetFamiliesForCategory(Category category)
    {
      BuiltInCategory builtInCategory = (BuiltInCategory)category.Id.IntegerValue;
      // FilteredElementCollector collector = new FilteredElementCollector(_document);
      FilteredElementCollector collector = new FilteredElementCollector(_document).OfClass(typeof(FamilySymbol)).OfCategory(builtInCategory);

      return collector.Cast<FamilySymbol>().ToList();
    }
  }
}