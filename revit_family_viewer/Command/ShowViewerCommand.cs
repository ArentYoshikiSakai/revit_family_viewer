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
    public class ShowViewerCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Revitのモデルのジオメトリを取得
            Document doc = commandData.Application.ActiveUIDocument.Document;
            // ... (ジオメトリを取得するコード)

            var viewModel = new ViewerWindow() ;
            var dialog = new ViewerWindow() ;
            dialog.ShowDialog() ;

            return Result.Succeeded;
        }
        
        public void ShowDialogWithoutArgs()
        {
            ViewerWindow dialog = new ViewerWindow();
            dialog.ShowDialog();
        }
        
        // public void ShowGeometry(GeometryElement geomElem)
        // {
        //     // ... (ジオメトリを取得するコード)
        //
        //     // ジオメトリをHelix ToolkitのMeshGeometry3Dに変換
        //     MeshGeometry3D mesh = ConvertToMeshGeometry3DHelper.ConvertToMeshGeometry3D(geomElem);
        //
        //     // ダイアログを表示
        //     Your3DViewerControl viewerControl = new Your3DViewerControl();
        //     ((ViewerViewModel)viewerControl.DataContext).ModelGeometry = mesh;
        //
        //     Window window = new Window
        //     {
        //         Title = "My 3D Viewer",
        //         Content = viewerControl,
        //         Width = 800,
        //         Height = 600
        //     };
        //     window.ShowDialog();
        //     
        // }
    }
    
    

}