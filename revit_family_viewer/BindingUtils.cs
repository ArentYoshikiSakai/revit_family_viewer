using System.Windows ;
using System.Windows.Controls ;

namespace revit_family_viewer
{
  public class BindingUtils
  {
    public static void SetDialogResultForParentWindow(UserControl control, bool dialogResult)
    {
      Window parentWindow = Window.GetWindow(control);
      if (parentWindow != null)
      {
        parentWindow.DialogResult = dialogResult;
      }
    }
  }
}