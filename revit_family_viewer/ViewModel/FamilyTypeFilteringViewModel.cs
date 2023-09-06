using System.Collections.ObjectModel ;
using System.ComponentModel ;
using Autodesk.Revit.DB ;
using revit_family_viewer.Service ;

namespace revit_family_viewer.ViewModel
{
  public class FamilyTypeFilteringViewModel : INotifyPropertyChanged
  {
    private readonly FamilyService _familyService;
    private readonly FamilyTypeService _familyTypeService;
    public ObservableCollection<Category> Categories { get; private set; } = new ObservableCollection<Category>();

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
    
    private Family _selectedFamily;
    public Family SelectedFamily
    {
      get { return _selectedFamily; }
      set
      {
        _selectedFamily = value;
        OnPropertyChanged(nameof(SelectedFamily));
        UpdateFamilyTypes();
      }
    }
    
    private FamilySymbol _selectedFamilySymbol;
    public FamilySymbol SelectedFamilySymbol
    {
      get { return _selectedFamilySymbol; }
      set
      {
        _selectedFamilySymbol = value;
        OnPropertyChanged(nameof(_selectedFamilySymbol));
      }
    }
    
    private ObservableCollection<Family> _families = new ObservableCollection<Family>();
    public ObservableCollection<Family> Families
    {
      get { return _families; }
      set
      {
        _families = value;
        OnPropertyChanged(nameof(Families));
      }
    }
    
    private ObservableCollection<FamilySymbol> _familyTypes = new ObservableCollection<FamilySymbol>();
    public ObservableCollection<FamilySymbol> FamilyTypes
    {
      get { return _familyTypes; }
      set
      {
        _familyTypes = value;
        OnPropertyChanged(nameof(FamilyTypes));
      }
    }
    
    // private ObservableCollection<FamilySymbol> _families = new ObservableCollection<FamilySymbol>();
    // public ObservableCollection<FamilySymbol> Families
    // {
    //   get { return _families; }
    //   set
    //   {
    //     _families = value;
    //     OnPropertyChanged(nameof(Families));
    //   }
    // }
    
    public FamilyTypeFilteringViewModel(Document doc)
    {
      var categoryService = new CategoryService(doc) ;
      var allCategories = categoryService.GetAllCategories();
      foreach (var cat in allCategories)
      {
        Categories.Add(cat);
      }
      
      _familyService = new FamilyService(doc);
      _familyTypeService = new FamilyTypeService(doc);
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
    
    private void UpdateFamilyTypes()
    {
      FamilyTypes.Clear();
      if (SelectedFamily != null)
      {
        var familyTypesForSelectedFamily = _familyTypeService.GetFamiliesForCategory(SelectedFamily);
        foreach (var familyType in familyTypesForSelectedFamily)
        {
          FamilyTypes.Add(familyType);
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