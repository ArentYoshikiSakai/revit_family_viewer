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
        private FamilySymbol _selectedFamilySymbol;

        public FamilySymbol SelectedFamilySymbol
        {
            get { return _selectedFamilySymbol; }
            set { _selectedFamilySymbol = value; }
        }
        
        public ShowViewerCommand(FamilySymbol selectedFamilySymbol)
        {
            _selectedFamilySymbol = selectedFamilySymbol;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // ジオメトリのオプションを設定します。
            Options geomOptions = new Options();
            geomOptions.ComputeReferences = true;
            geomOptions.DetailLevel = ViewDetailLevel.Medium; // 詳細度を設定。必要に応じて変更可能。
            
            GeometryElement geomElem = _selectedFamilySymbol.get_Geometry(geomOptions);
            ShowGeometry( geomElem ) ;

            return Result.Succeeded;
        }

        public void ShowDialogWithoutArgs()
        {
            
        }

        
        public void ShowGeometry(GeometryElement geomElem)
        {
            // ... (ジオメトリを取得するコード)
        
            // ジオメトリをHelix ToolkitのMeshGeometry3Dに変換
            MeshGeometry3D mesh = ConvertToMeshGeometry3DHelper.ConvertToMeshGeometry3D(geomElem);
        
            // ダイアログを表示
            ViewerWindow viewerWindow = new ViewerWindow();
            ((ViewerViewModel)viewerWindow.DataContext).ModelGeometry = mesh;
        
            // Window window = new Window
            // {
            //     Title = "My 3D Viewer",
            //     Content = viewerWindow,
            //     Width = 800,
            //     Height = 600
            // };
            // window.ShowDialog();
            
        }
    }
    
    

}