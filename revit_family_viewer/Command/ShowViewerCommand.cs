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
            Options geomOptions = new Options();
            geomOptions.ComputeReferences = true;
            geomOptions.DetailLevel = ViewDetailLevel.Medium;
            
            GeometryElement geomElem = _selectedFamilySymbol.get_Geometry(geomOptions);
            ShowGeometry( geomElem ) ;

            return Result.Succeeded;
        }
        
        public void ShowGeometry(GeometryElement geomElem)
        {
            MeshGeometry3D mesh = ConvertToMeshGeometry3DHelper.ConvertToMeshGeometry3D(geomElem);
            
            ViewerWindow viewerWindow = new ViewerWindow();
            // ((ViewerViewModel)viewerWindow.DataContext).ModelGeometry = mesh;
        }
    }
    
    

}