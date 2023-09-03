using System.Windows ;
using System.Windows.Controls;
using revit_family_viewer.Command ;

namespace revit_family_viewer
{
    public partial class FilteringControl : UserControl
    {
        public FilteringControl()
        {
            InitializeComponent();
        }
        
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            ShowViewerCommand command = new ShowViewerCommand() ;
            command.ShowDialogWithoutArgs();
            BindingUtils.SetDialogResultForParentWindow( this, true );
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            BindingUtils.SetDialogResultForParentWindow( this, false );
        }
        
    }
}