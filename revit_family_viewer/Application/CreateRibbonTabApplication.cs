using System ;
using System.Collections.Generic ;
using System.IO ;
using Autodesk.Revit.DB ;
using Autodesk.Revit.UI ;
using System.Linq ;
using Autodesk.Revit.ApplicationServices ;
using System.Windows.Media.Imaging ;
using revit_family_viewer.Data ;

namespace revit_family_viewer.Application
{
  public class CreateRibbonTabApplication : IExternalApplication
  {
    private RibbonPanel _panel ;

    public Result OnStartup( UIControlledApplication application )
    {
      try {
        CreateRibbonTab(application);
        AddButtonToRibbon(application);

        return Result.Succeeded ;
      }
      catch ( Exception e ) {
        TaskDialog.Show( "Error", e.Message ) ;
        return Result.Failed ;
      }
    }

    public Result OnShutdown( UIControlledApplication application )
    {
      return Result.Succeeded ;
    }

    private void CreateRibbonTab(UIControlledApplication application)
    {
      var tabName = "3Dビュー";
      application.CreateRibbonTab(tabName);
      var panelName = "3Dビュー" ;
      _panel = application.CreateRibbonPanel(tabName, panelName);
    }
    
    private void AddButtonToRibbon(UIControlledApplication application)
    {
      var pushButtonDataName = "PushButtonHello" ;
      var pushButtonDataText = "Hello World" ;
      var className = "revit_family_viewer.Command.ShowViewerCommand";
      PushButtonData pushButtonData = new PushButtonData(pushButtonDataName, pushButtonDataText, FileData.DllFilePath, className);
      PushButton pushButton = _panel.AddItem(pushButtonData) as PushButton;

      var viewerTabImagePath = Path.Combine(FileData.ImageFolderPath, FileData.ViewerTabImage);
      BitmapImage image = new BitmapImage(new Uri(viewerTabImagePath));
      pushButton.LargeImage = image;
      pushButton.ToolTip = "simple push button";
    }
  }
}