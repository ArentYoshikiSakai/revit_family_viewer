using System ;
using System.Collections.Generic ;
using System.IO ;
using Autodesk.Revit.DB ;
using Autodesk.Revit.UI ;
using Autodesk.UI.Windows ;
using System.Linq ;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes ;
using System.Windows.Media.Imaging;

namespace revit_family_viewer.Command
{
  [Transaction(TransactionMode.ReadOnly)]
  public class CreateRibbonTabCommand : IExternalCommand
  {
    private string _dir ;
    private string _introLabName ;
    private string _dllExtension  ;
    private string _introLabPath  ;
    private string _imageFolder  ;
    private string _imageFolderName  ;

    public Result Execute( ExternalCommandData commandData, ref string message, ElementSet elements )
    {
      UIApplication uiapp = commandData.Application ;
      GetDirName() ;

      try {
        string tabName = "3Dビュー" ;
        uiapp.CreateRibbonTab( tabName ) ;

        RibbonPanel panelAbc = uiapp.CreateRibbonPanel( tabName, "abc" ) ;
        RibbonPanel panelAdc = uiapp.CreateRibbonPanel( tabName, "adc" ) ;

        PushButtonData pushButtonDataHello = 
          new PushButtonData( "PushButtonHello", "Hello World", 
            _introLabPath, _introLabName + ".CreateRibbonTabCommand" );
        
        PushButton pushButtonHello = 
          panelAbc.AddItem( pushButtonDataHello ) as PushButton;
        
        var imagePath = Path.Combine( _dir, _imageFolderName, "3dViewer.png" );
        BitmapImage image = new BitmapImage(new Uri(imagePath));
        if ( image != null ) {
          pushButtonHello.LargeImage = image ; 
        }
        
        pushButtonHello.ToolTip = "simple push button";
        
        return Result.Succeeded;
      }
      catch ( Exception e ) {
        message = e.Message ;
        return Result.Failed ;
      }
      
    }

    private bool GetDirName()
    {
      // External application directory:
      _dir = Path.GetDirectoryName( 
        System.Reflection.Assembly
          .GetExecutingAssembly().Location );
 
      // External command path:
      _introLabName = "revit_family_viewer" ;
      _dllExtension = ".dll" ;
      _introLabPath = Path.Combine( _dir, _introLabName + _dllExtension );
 
      if( !File.Exists( _introLabPath ) )
      {
        TaskDialog.Show( "UIRibbon", "External command assembly not found: " 
                                     + _introLabPath );
        return false ;
      }

      _imageFolderName = "Resources" ;
      // Image path:
      _imageFolder = FindFolderInParents( _dir, _imageFolderName );

      if ( null == _imageFolder || ! Directory.Exists( _imageFolder ) ) {
        TaskDialog.Show( "UIRibbon", string.Format( "No image folder named '{0}' found in the parent directories of '{1}.", _imageFolderName, _dir ) ) ;

        return false ;
      }

      return true ;
    }

    private static string FindFolderInParents( string startDir, string folderName )
    {
      DirectoryInfo dirInfo = new DirectoryInfo( startDir ) ;

      while ( dirInfo != null ) {
        // 指定されたフォルダ名を持つサブディレクトリが存在するかどうかを確認
        var targetFolder = dirInfo.GetDirectories( folderName ) ;
        if ( targetFolder.Length > 0 ) {
          return targetFolder[ 0 ].FullName ;
        }

        // 親ディレクトリに移動
        dirInfo = dirInfo.Parent ;
      }

      // 見つからなかった場合はnullを返す
      return null ;
    }
  }
}