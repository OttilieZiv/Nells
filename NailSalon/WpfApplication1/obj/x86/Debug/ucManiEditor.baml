   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   7       NailSalon.ucManiEditor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &myclr-namespace:NailSalon     5   7   -   5          � 	Resources  5         NailSalon.DataSet2   dataSet2   NailSalon.DataSet1  dataSet1  manicureitemsViewSource �� Source �� Path �� Source  bottleSearchViewSource��%�   &	        &	      &	 &     7   &	 [     7    5	   
   6     5
   
   6   �� 5   
    6?   �� $ manicureitems�8   �� 5   
    6>   �� $ BottleSearch�8   5      .��5      �  � DataContext# [ 6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Name:��6   $��0��6    $��0��60   $��Right=�6=   �� 5   
   -   5        $��txtName��5      $��1��6!   $��0��61   $��2��6>   $��Stretch=�6R   �� 5    
   -   5        $��btnSave��5       $��3��6    $��0��60   $
��SAVE��6=   6L   �� 5!   
   $��Type:��6   $��0��6    $��1��60   $��Right=�6=   �� 5"   
   -   5        $��txtType��5"      $��1��6!   $��1��61   $��2��6>   $��Stretch=�6R   �� 5#   
   -   5        $��	btnCancel��5#      $��3��6"   $��1��62   $��Cancel��6?   6P   �� 5$   
   $��Notes:��6   $��0��6!   $��2��61   $��Right=�6>   �� 5%   
   -   5        $��txtNotes��5%      $��1��6"   $��2��62   $��2��6?   $��Stretch=�6S    �� 	MaxLength$	 250��6q    �� AcceptsReturn . 6�   �� 5&   
   $��Nail length:��6   $��0��6'   $��3��67   $��Right=�6D   �� 5'   
   -   5        $��	txtLength��5'      $��3��6#   $��1��60   $	��250��6@   $
��auto��6O   $��Stretch=�6\   �� 5(   
   -   5        $��cbxWorn��5(      $��Right=�6"   $
��auto��6>   $��3��6K   $��2��6X   $��?Worn it��6h   $��Center=�6{   $��RightToLeft=�6�   �� 5*   
   $��	Polishes:��6   $��0��6$   $��4��64   � 5+   
   # [ 6   $��1��6E   $��4��6U   $��2��6b   $��Stretch=�6v   $��Stretch=�6�    5,      �� 5-      $
��auto �6    �� 5.      $��* �6    .+�50      ]� $��0��6   .+�51      �� $��Search:��6   $
��Left=�6*   $
��Left=�6@   �� 52      -	   5        $��txtBottleSearch��52      $
��Left=�61   $
��Left=�6G   $	��150��6b   6n   �� 53      -
   5        $��cmbBrand��53      $
��auto��6+   $
��Left=�68   $
��Left=�6N   �� 54      -   5        $��btnCollapseSearch��54      $��^��62   $��Right=�6>   $��Right=�6U   6q   55      &   System.Windows.Controls.DataGrid  56      -   5        $��dgPickBottle��56   �   $��1��6   	   AutoGenerateColumns	 .  $��50��6@   
   EnableRowVirtualization
 .    
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .  $��Stretch=�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6*  $��Stretch=�6Y  ��6�   ��    Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      -   5        brandColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Brand��58   ]      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� $ brand�6l     59      -   5        
nameColumn��$
 Name��59   [   $
 auto 6i    6=   �� $
 name�6i     5:      -   5        descriptionColumn��$ Description��5:   i   $ * 6~    6D   �� $ description�6~   5<      5=      �� 5>   
   -   5        $��btnClearItems��5>      $��Clear��6&   $��3��66   $��5��6F   $	��Top=�6S   6k     5?   
   -   5        $��dgManiItems��5?   �   	 .  $��1��6/   $��5��6?   
 .  .  $��2��6�   $��Stretch=�6�   $ VisibleWhenSelected=�6�   $��Stretch=�6  ��6�   ��  5@        5A      -   5        brandNameColumn��$ 
Brand Name��5A   a   $
 auto 6u    6>   �� $ 	BrandName�6u     5B      -   5        bottleNameColumn��$ Bottle Name��5B   c   $
 auto 6x    6?   �� $ 
BottleName�6x     5C      -   5        usageColumn��$ Usage��5C   Y   $ * 6h    6:   �� $ Usage�6h     5D      -   5        orderColumn��$ Order��5D   Y   $ 40 6h    6:   �� $ Order�6h   5F      �� 5H   
   $��Verdict:��6   $��0��6#   $��6��63   �� 5I   
   -   5        $��
txtVerdict��5I      $��1��6$   $��6��64   $��2��6A   $	 250��6U    . $��Stretch=�6z   5J      5K      