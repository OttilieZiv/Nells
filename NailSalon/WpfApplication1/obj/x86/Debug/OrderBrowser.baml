   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   8   ?$clr-namespace:NailSalon.UsercontrolsNailSalon.Usercontrols  6�       NailSalon.OrderBrowser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &myclr-namespace:NailSalon     5   8   4my1$clr-namespace:NailSalon.Usercontrols     6�   -   5          � Title$  Order Browser��5   	   $	��356��6   $	��648��6,    � WindowState$ 	Maximized=�6r    � 	Resources 5         NailSalon.DataSet1   dataSet1  orderedViewSource �� Source �� Path �� Source  onOrderViewSource��%�   &	        &	      7   &	 B     7     5   
   6   �� 5   
    69   �� $ ordered�8   �� 5   
    69   �� $ OnOrder�8   5	      .��5
      � -   5        $��grid1��5
       � DataContext# [ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5        $��btnNew��5      $��0��6   $��0��6/   $��Add new��6<   $��3q�6N   $
��Left=�6Y   6t   � 5   
   -   5        $��grid2��5      $��1��6   $y�Visible=�6)    5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5!      �� $��0��6   $��0��6$   $��Brand:��61   $��Right=�6B   �� 5"      $��0��6   $��1��6$   $��Name:��61   $��Right=�6A   �� 5#      $��0��6   $��2��6$   $��Description:��61   $��Right=�6H   �� 5$      $��0��6   $��3��6$   $��Date ordered:��61   $��Right=�6I   �� 5%      $��0��6   $��4��6$   $��Notes:��61   $��Right=�6B   �� 5'      -   5        $��txtName��5'   Q   $��1��6   $��1��6&   $��Stretch=�63   $��Stretch=�6`   $��3q�6|   $��1��6�   �� 5(      -   5        $��txtDesc��5(   Q   $��1��6   $��2��6&   $��Stretch=�63   $��Stretch=�6`   $��3q�6|   $��2��6�   (  "System.Windows.Controls.DatePicker  5)      -   5        $��dtpOrd��5)      $��1��6'   $��3��67   $��Stretch=�6D   $��Stretch=�6b   $��3q�6~   $��3��6�   �� 5*      -   5        $��txtNotes��5*   Q   $��1��6   $��4��6&   $��Stretch=�63   $��Stretch=�6a   $��3q�6~   $��4��6�   	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�6�   �� 5+      -	   5        $��btnSave��5+      $��2��6$   $��1��64   $
��SAVE��6A   $��3q�6P   $��7��6q   �� 5,      -
   5        $��	btnCancel��5,      $��2��6&   $��2��66   $��Cancel��6C   $��3q�6T   $��8��6w   1   +NailSalon.Usercontrols.ucBrandPickerWithAdd  5-      -   5          Name$ ucBrandPickerWithAdd1��5-   b   $��1��6'   $��0��67   $��stretch=�6D   $	��Top=�6�   5.      &   System.Windows.Controls.DataGrid  5/   
   -   5        $��	dgOrdered��5/      $��2��6$   $��Stretch=�61   $��Stretch=�6O      AutoGenerateColumns .     EnableRowVirtualization . $��3q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . ��6�   ��    AlternatingRowBackground 50      �� 51       �� EndPoint$ 1,0.5&�6&    �� 
StartPoint$ 0,0.5&�67   .��52      �  � Color$ 	#220069FF��6#    � Offset$ 0Q�65   � 53      $ 	#89BCFFA6��6#   $ 0.738Q�65   54         Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      -   5        brandColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Brand��57   Y      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� $ brand�6h     58      -   5        nameColumn1��$
 Name��58   X   $	 170 6f    6:   �� $
 name�6f     59      -   5        descriptionColumn1��$ Description��59   f   $	 300 6{    6A   �� $ description�6{     5:      -   5        notesColumn1��$ Notes��5:   Z   $ * 6i    6;   �� $ notes�6i   4	  .System.Windows.Controls.DataGridTemplateColumn	  5;      -   5        dateorderedColumn��$ Date ordered��5;   D   $	 100 6Z      
IsReadOnly .  	  CellTemplate 5<      �� 5=      .R�5>        {�.     SelectedDate 6)   �� $ dateordered� �� Mode$ TwoWay=� �� ValidatesOnExceptions .   �� NotifyOnValidationError  . 6�   5?      5A      ! � ContextMenu! 5C      �� 5D      -   5        $��cmnuGrid��5D      .@�5E      m� -   5        $��btnTransfer��5E      $��Transfer to inventory��62   6Q   5F      5H      5I      5J      