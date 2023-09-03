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
      Document doc = commandData.Application.ActiveUIDocument.Document;
      FilteringControl control = SetupFilteringControl(doc);
      ShowFilteringDialog(control);

      return Result.Succeeded;
    }
    
    private FilteringControl SetupFilteringControl(Document doc)
    {
      var viewModel = new FamilyTypeFilteringViewModel(doc);
      FilteringControl control = new FilteringControl();
      control.DataContext = viewModel;
      return control;
    }

    private void ShowFilteringDialog(FilteringControl control)
    {
      FamilyTypeFilteringWindow dialog = new FamilyTypeFilteringWindow();
      dialog.Content = control;
      dialog.ShowDialog();
    }
  }
    
    

}