using System;
using System.Windows;
using System.Windows.Media.Media3D;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using revit_family_viewer.ViewModel;
using revit_family_viewer.Helpers;

namespace revit_family_viewer.Command
{
  [Transaction(TransactionMode.ReadOnly)]
  public class ShowFilteringCommand : IExternalCommand
  {
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      // Revitのモデルのジオメトリを取得
      Document doc = commandData.Application.ActiveUIDocument.Document;
      // ... (ジオメトリを取得するコード)

      var viewModel = new FamilyTypeFilteringViewModel( doc ) ;
      FilteringControl control = new FilteringControl();
      control.DataContext = viewModel;
      
      FamilyTypeFilteringWindow dialog = new FamilyTypeFilteringWindow() ;
      dialog.Content = control;
      dialog.ShowDialog() ;

      return Result.Succeeded;
    }
  }
    
    

}