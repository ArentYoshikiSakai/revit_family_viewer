using System.Collections.ObjectModel ;
using System.ComponentModel;
using System.Windows.Media.Media3D;
using Autodesk.Revit.DB ;
using revit_family_viewer.Service ;

namespace revit_family_viewer.ViewModel
{
    public class ViewerViewModel : INotifyPropertyChanged
    {

        
        private MeshGeometry3D _modelGeometry;

        public MeshGeometry3D ModelGeometry
        {
            get { return _modelGeometry; }
            set
            {
                _modelGeometry = value;
                OnPropertyChanged(nameof(ModelGeometry));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }

}