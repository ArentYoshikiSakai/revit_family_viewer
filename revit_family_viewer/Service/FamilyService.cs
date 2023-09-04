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

    public IList<FamilySymbol> GetFamiliesForCategory(Category category)
    {
      BuiltInCategory builtInCategory = (BuiltInCategory)category.Id.IntegerValue;
      // FilteredElementCollector collector = new FilteredElementCollector(_document);
      FilteredElementCollector collector = new FilteredElementCollector(_document).OfClass(typeof(FamilySymbol)).OfCategory(builtInCategory);
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
      
      return collector.Cast<FamilySymbol>().ToList();
    }
    
    private bool IsComponentFamilyCategory(BuiltInCategory category)
    {
      List<BuiltInCategory> componentCategories = new List<BuiltInCategory>
      {
        BuiltInCategory.OST_Doors,
        BuiltInCategory.OST_Windows,
        BuiltInCategory.OST_Furniture,
        BuiltInCategory.OST_FurnitureSystems,
        BuiltInCategory.OST_Casework,
        BuiltInCategory.OST_SpecialityEquipment,
        BuiltInCategory.OST_Entourage,
        BuiltInCategory.OST_Planting,
        BuiltInCategory.OST_LightingFixtures,
        BuiltInCategory.OST_MechanicalEquipment,
        BuiltInCategory.OST_PlumbingFixtures,
        BuiltInCategory.OST_ElectricalEquipment,
        BuiltInCategory.OST_ElectricalFixtures,
        BuiltInCategory.OST_Parking,
        BuiltInCategory.OST_Site,
        BuiltInCategory.OST_ElectricalCircuit,
        BuiltInCategory.OST_SecurityDevices,
        BuiltInCategory.OST_TelephoneDevices,
        BuiltInCategory.OST_FireAlarmDevices,
        BuiltInCategory.OST_DataDevices,
        BuiltInCategory.OST_CommunicationDevices,
        BuiltInCategory.OST_NurseCallDevices,
        BuiltInCategory.OST_DuctCurves,
        BuiltInCategory.OST_PipeCurves,
        BuiltInCategory.OST_PipeFitting,
        BuiltInCategory.OST_PipeAccessory,
        BuiltInCategory.OST_DuctFitting,
        BuiltInCategory.OST_DuctAccessory,
        BuiltInCategory.OST_PipeInsulations,
        BuiltInCategory.OST_DuctLinings,
        BuiltInCategory.OST_HVAC_Zones,
      };

      return componentCategories.Contains(category);
    }

    private Type GetSystemFamilyTypeForCategory(BuiltInCategory category)
    {
      switch (category)
      {
        case BuiltInCategory.OST_Walls:
          return typeof(WallType);
        // 他のシステムファミリのタイプに対するケースを追加
        default:
          throw new Exception("Unknown system family category.");
      }
    }
  }
}