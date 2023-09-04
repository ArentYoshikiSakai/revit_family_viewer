using System.Collections.ObjectModel ;
using System.ComponentModel ;
using Autodesk.Revit.DB ;
using revit_family_viewer.Service ;

namespace revit_family_viewer.ViewModel
{
  public class FamilyTypeFilteringViewModel : INotifyPropertyChanged
  {
    private readonly FamilyService _familyService;
    public ObservableCollection<Category> Categories { get; private set; } = new ObservableCollection<Category>();
    
    private ObservableCollection<FamilySymbol> _families = new ObservableCollection<FamilySymbol>();
    public ObservableCollection<FamilySymbol> Families
    {
      get { return _families; }
      set
      {
        _families = value;
        OnPropertyChanged(nameof(Families));
      }
    }
    
    private Category _selectedCategory;
    public Category SelectedCategory
    {
      get { return _selectedCategory; }
      set
      {
        _selectedCategory = value;
        OnPropertyChanged(nameof(SelectedCategory));
        UpdateFamilies();
      }
    }
    
    public FamilyTypeFilteringViewModel(Document doc)
    {
      var categoryService = new CategoryService(doc) ;
      var allCategories = categoryService.GetAllCategories();
      foreach (var cat in allCategories)
      {
        Categories.Add(cat);
      }
      
      _familyService = new FamilyService(doc);
    }
    
    private void UpdateFamilies()
    {
      Families.Clear();
      if (SelectedCategory != null)
      {
        var familiesForSelectedCategory = _familyService.GetFamiliesForCategory(SelectedCategory);
        foreach (var family in familiesForSelectedCategory)
        {
          Families.Add(family);
        }
      }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}