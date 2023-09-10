using System.Windows ;
using System.Windows.Controls;
using System.Windows.Media.Media3D ;
using revit_family_viewer.Command ;
using Autodesk.Revit.DB;
using revit_family_viewer.Helpers ;
using revit_family_viewer.ViewModel ;


namespace revit_family_viewer
{
    public partial class FilteringControl : UserControl
    {
        private FamilyTypeFilteringViewModel _viewModel ;
        
        public FilteringControl()
        {
            InitializeComponent();
        }
        
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            _viewModel = this.DataContext as FamilyTypeFilteringViewModel ;
            
            if (_viewModel != null && _viewModel.SelectedFamilySymbol != null)
            {
                ShowViewerCommand command = new ShowViewerCommand(_viewModel.SelectedFamilySymbol) ;
            
                string message = "";
                ElementSet elements = new ElementSet(); // 空の ElementSet を作成
                BindingUtils.SetDialogResultForParentWindow( this, true );
                // command.Execute(null, ref message, elements);
                
                var viewerWindow = new ViewerWindow();
                var viewerViewModel = viewerWindow.DataContext as ViewerViewModel;
                if (viewerViewModel != null) {
                    TestMethod1(viewerWindow) ;
                    var a = ( (ViewerViewModel)viewerWindow.DataContext ).ModelGeometry ;
                }

                viewerWindow.ShowDialog();
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            BindingUtils.SetDialogResultForParentWindow( this, false );
        }

        private void TestMethod1(ViewerWindow viewerWindow)
        {
            // ジオメトリのオプションを設定します。
            Options geomOptions = new Options();
            geomOptions.ComputeReferences = true;
            geomOptions.DetailLevel = ViewDetailLevel.Medium; // 詳細度を設定。必要に応じて変更可能。
            
            
            GeometryElement geomElem = _viewModel.SelectedFamilySymbol.get_Geometry(geomOptions);
            ShowGeometry( geomElem, viewerWindow ) ;

        }

        public void ShowGeometry(GeometryElement geomElem, ViewerWindow viewerWindow)
        {
            // ... (ジオメトリを取得するコード)
        
            // ジオメトリをHelix ToolkitのMeshGeometry3Dに変換
            MeshGeometry3D mesh = ConvertToMeshGeometry3DHelper.ConvertToMeshGeometry3D(geomElem);
        
            // ダイアログを表示
            ((ViewerViewModel)viewerWindow.DataContext).ModelGeometry = mesh;
            
        }
    }
}