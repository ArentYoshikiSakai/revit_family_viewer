using System.IO ;

namespace revit_family_viewer.Data
{
  public class FileData
  {
    public FileData()
    {
      
    }
    static FileData()
    {
      ProjectName = "revit_family_viewer" ;
      ViewerTabImage = "3dViewer.png" ;
      AssemblyPath = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location ) ;
      DllFilePath = Path.Combine( AssemblyPath, ProjectName + ".dll" ) ;
      ImageFolderPath = FindFolderInParents( AssemblyPath, "Resources" ) ;
    }
    // common name
    public static string ProjectName { get; private set ; }
    
    // file name
    public static string ViewerTabImage { get; private set ; }
    
    // path
    public static string AssemblyPath { get; private set ; }
    public static string DllFilePath { get; private set ; }
    
    public static string ImageFolderPath { get; private set ; }
    
    private static string FindFolderInParents( string startDir, string folderName )
    {
      DirectoryInfo dirInfo = new DirectoryInfo( startDir ) ;

      while ( dirInfo != null ) {
        var targetFolder = dirInfo.GetDirectories( folderName ) ;
        if ( targetFolder.Length > 0 ) {
          return targetFolder[ 0 ].FullName ;
        }
        
        dirInfo = dirInfo.Parent ;
      }
      
      return null ;
    }
  }
}