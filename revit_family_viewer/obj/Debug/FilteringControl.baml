   M S B A M L   `   `   `  ����N  Jrevit_family_viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:revit_family_viewer.ViewModelrevit_family_viewer.ViewModel  5      *    $revit_family_viewer.FilteringControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      A	viewModel+clr-namespace:revit_family_viewer.ViewModel     5      .��5      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Select Family Category:��6   $��0��63   $��0,0,0,10q�6@   �� 5   
   -   5        $��cmbCategory��5      $��1��6&   $��0,0,0,10q�63    �� DisplayMemberPath$
 Name��5      ��5      �� *
Categories+ �� SelectedItem 5      �� *SelectedCategory+�� 5   
   $��Select Family Name:��6   $��2��6/   $��0,0,0,10q�6<   �� 5   
   -   5        $��cmbFamilyName��5      $��3��6(   $��0,0,0,10q�65   $
 Name��5      ��5      �� *
Families+ 5      �� *SelectedFamily+�� 5   
   $��Select Family Type Name:��6   $��4��64   $��0,0,0,10q�6A   �� 5   
   -   5        $��cmbFamilyTypeName��5      $��5��6,   $��0,0,0,10q�69   $
 Name��5      ��5      �� *FamilyTypes+ 5       �� *SelectedFamilySymbol+�� 5"   
    �� Orientation$ 
Horizontal=�6   $��6��6.   $��Right=�6;   .+�5#      �� -   5        $��	btnFilter��5#      $��Filter��6&   $	��100��67   $��0,0,10,0q�6C   6U   �� 5$      -   5        $��	btnCancel��5$      $��Cancel��6&   $	��100��67   6C   5%      5&      5'      