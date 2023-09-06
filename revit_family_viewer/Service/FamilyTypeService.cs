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

    public IList<FamilySymbol> GetFamiliesForCategory(Family family)
    {
      int familyId = family.Id.IntegerValue ;
      
      FilteredElementCollector collector = new FilteredElementCollector(_document)
        .OfClass(typeof(FamilySymbol));
      
      var filteredFamilyTypes = collector.Cast<FamilySymbol>()
        .Where(f => f.Family.Id.IntegerValue == familyId)
        .ToList();

      return filteredFamilyTypes ;
    }
  }
}