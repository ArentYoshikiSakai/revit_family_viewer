using System ;
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
      BuiltInCategory builtInCategory = (BuiltInCategory)category.Id.IntegerValue;
      FilteredElementCollector collector = new FilteredElementCollector(_document)
        .OfClass(typeof(Family));

      var filteredFamilies = collector.Cast<Family>()
        .Where(f => f.FamilyCategory.Id.IntegerValue == (int)builtInCategory)
        .ToList();
      // // コンポーネントファミリの場合
      // if (IsComponentFamilyCategory(builtInCategory))
      // {
      //   collector.OfClass(typeof(FamilySymbol)).OfCategory(builtInCategory);
      // }
      // // システムファミリの場合
      // else
      // {
      //   Type systemFamilyType = GetSystemFamilyTypeForCategory(builtInCategory);
      //   collector.OfClass(systemFamilyType);
      // }

      return filteredFamilies ;
    }
  }
}