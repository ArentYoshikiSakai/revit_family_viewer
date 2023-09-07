using System.Windows ;
using revit_family_viewer.ViewModel ;

namespace revit_family_viewer
{
  public partial class ViewerWindow : Window
  {
    public ViewerWindow()
    {
      InitializeComponent() ;
      this.DataContext = new ViewerViewModel();
    }
  }
}