   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   g       NailSalon.StashBrowser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &myclr-namespace:NailSalon     5   g   -   5          � Title$  Stash Browser��5   	   $	��363��6   $	��800��6,    � WindowState$ 	Maximized=�68    � 	Resources 5         NailSalon.DataSet1   dataSet1  bottlesViewSource �� Source �� Path �� Source  bottleSearchViewSource��%�   &	        &	      7   &	 B     7     5   
   6   �� 5   
    69   �� $ bottles�8   �� 5   
    6>   �� $ BottleSearch�8   5	      .��5
      �  � DataContext# [ 6    � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   .+�5      �� $��General:��6   $
��Left=�6'   $
��Left=�6=   $��Center=�6X   �� 5      -   5        $��	txtSearch��5      $
��Left=�6'   $	��100��6=   $
��Left=�6I   6d   �� 5      -   5        $��cmbBrand��5      $
��Left=�6'   $
��Left=�6=   $
��auto��6X   �� 5      -   5        $��	cmbDrawer��5      $
��Left=�6(   $
��Left=�6>   $
��auto��6Y   �� 5      -   5        $��cmbTag��5      $
��Left=�6%   $
��Left=�6;   $
��auto��6V   �� 5      -   5        $��
cmbCountry��5      $
��Left=�6)   $
��Left=�6?   $
��auto��6Z   �� 5      -   5        $��cmbType��5      $
��Left=�6&   $
��Left=�6<   $
��auto��6W   �� 5      -   5        $��btnUsedFilter��5   #   $	��All��6   $
��Left=�68   $
��Left=�6N   $
��auto��6i   6v   �� 5      -	   5        $��	btnSearch��5      $��Go��6&   $��30��63   $
��Left=�6>   $
��Left=�6Z   6p   �� 5      -
   5        $��txtTag��5      $��Right=�6$   $��Right=�6;   $��Center=�6W   $	��100��6r   6~   �� 5      $
��Tag:��6   $��Right=�6#   $��Right=�6:   $��Center=�6V   �� 5      -   5        $��btnBrandFancy��5      $��View brand collection��6*   $��Right=�6J   $��Right=�6a   6}   5      &   System.Windows.Controls.DataGrid  5    
   -   5        $��
dgvBottles��5       $��1��6%   $��Stretch=�62   $��Stretch=�6P   	   AutoGenerateColumns	 .  
   EnableRowVirtualization
 .    RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      CanUserAddRows .     CanUserDeleteRows .     RowBackground
 �����   
IsReadOnly . ��6�   ��    AlternatingRowBackground 5!      �� 5"       �� EndPoint$ 1,0.5&�6&    �� 
StartPoint$ 0,0.5&�67   .��5#      �  � Color$ 	#2F5592FF��6#    � Offset$ 0Q�65   � 5$      $ 	#FFB3FFFF��6#   $ 0.622Q�65   5%         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      -   5        iDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5(   S      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ ID�6_     5)      -   5        brandColumn��$ Brand��5)   Y   $	 130 6h    6:   �� $ brand�6h     5*      -   5        
nameColumn��$
 Name��5*   W   $	 170 6e    69   �� $
 name�6e     5+      -   5        swatchcoatsColumn��$ Coats��5+   e   $ 50 6t    6@   �� $ swatchcoats�6t     5,      -   5        descriptionColumn��$ Description��5,   e   $	 300 6z    6@   �� $ description�6z     5-      -   5        swatchnotesColumn��$ Swatch notes��5-   e   $ * 6{    6@   �� $ swatchnotes�6{   4  .System.Windows.Controls.DataGridCheckBoxColumn  5.      -   5        
usedColumn��$ Used?��5.   [   $ SizeToHeader 6j    6=   �� $
 used�6j     5/      -   5        drawerColumn��$ Drawer��5/   [   $	 120 6k    6;   �� $ drawer�6k    � ContextMenu 51      �� 52      -   5        $��mnuGrid��52      .@�53      m� -   5        $��btnEdit��53      $
��Edit��6D   m� 54      -   5        $��btnNotes��54      $��Notes��6/   6>   m� 55      -   5        $��btnTag��55      $��Add tag��6-   6>   m� 56      -   5        $��btnMultiTag��56      $��Add tag to multiple items��62   6U   57      59      5:      5;      