using System ;
using System.Collections.Generic ;
using Autodesk.Revit.DB ;
using Autodesk.Revit.UI ;
using Autodesk.UI.Windows ;
using System.Linq ;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes ;

namespace revit_family_viewer.Command
{
  [Transaction(TransactionMode.ReadOnly)]
  public class CreateRibbonTabCommand : IExternalCommand
  {
    public Result Execute( ExternalCommandData commandData, ref string message, ElementSet elements )
    {
      UIApplication uiapp = commandData.Application ;
      Application app = uiapp.Application ;

      try {
        string tabName = "3Dビュー" ;
        uiapp.CreateRibbonTab( tabName ) ;
        
        return Result.Succeeded;
      }
      catch ( Exception e ) {
        message = e.Message ;
        return Result.Failed ;
      }
      
    }
  }
}