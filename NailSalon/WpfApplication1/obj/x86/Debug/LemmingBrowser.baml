   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   :   ?$clr-namespace:NailSalon.UsercontrolsNailSalon.Usercontrols  6�       NailSalon.LemmingBrowser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &myclr-namespace:NailSalon     5   :   4my1$clr-namespace:NailSalon.Usercontrols     6�   -   5          � Title$  Lemming Browser��5   	   $	��356��6!   $	��648��6.    � WindowState$ 	Maximized=�6t    � 	Resources 5         NailSalon.DataSet2   dataSet2  lemListViewSource �� Source �� Path �� Source��%Z   &	        &	      7     5   
   6   �� 5   
    69   �� $ LemList�8   5      .��5	      � -   5        $��grid1��5	       � DataContext# [ 6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   � -   5        $��grid2��5      $��0��6   $y�Visible=�6)    5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��0��6$   $��Brand:��61   $��Right=�6B   �� 5       $��0��6   $��1��6$   $��Name:��61   $��Right=�6A   �� 5!      $��0��6   $��2��6$   $��Description:��61   $��Right=�6H   �� 5"      $��0��6   $��3��6$   $��Notes:��61   $��Right=�6B   �� 5#      $��0��6   $��4��6$   $��Lust level:��61   $��Right=�6G   1   +NailSalon.Usercontrols.ucBrandPickerWithAdd  5$      -   5        	  Name$	 cmbBrand��5$   D   $��1��6'   $��0��67   $��Stretch=�6V   $��Stretch=�6t   $��0��6�   �� 5%      -   5        $��txtName��5%   Q   $��1��6   $��1��6&   $��Stretch=�63   $��Stretch=�6`   $��3q�6|   $��1��6�   �� 5&      -   5        $��txtDesc��5&   Q   $��1��6   $��2��6&   $��Stretch=�63   $��Stretch=�6`   $��3q�6|   $��2��6�   �� 5'      -   5        $��txtNotes��5'   Q   $��1��6   $��3��6&   $��Stretch=�63   $��Stretch=�6a   $��3q�6~   $��3��6�   
 �� AcceptsReturn
 .  �� TextWrapping$
 Wrap=�6�   �� 5(      -   5        $��txtLustLevel��5(   Q   $��1��6   $��4��6&   $��Stretch=�63   $��Stretch=�6e   $��3q�6�   $��4��6�   �� 5)      -	   5        $��btnSave��5)      $��2��6$   $��1��64   $
��SAVE��6A   $��3q�6P   $��7��6q   �� 5*      -
   5        $��	btnCancel��5*      $��2��6&   $��2��66   $��Cancel��6C   $��3q�6T   $��8��6w   5,      �� 5-   
   -   5        $��cbxShowKilled��5-      $��Show dead lemmings��6(   $��1��6E   $��0��6R   $��2��6b   6�   &   System.Windows.Controls.DataGrid  5.   
   -   5        $��
dgLemmings��5.      $��2��6%   $��Stretch=�62   $��Stretch=�6P      AutoGenerateColumns .     EnableRowVirtualization . $��3q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . ��6�   ��    AlternatingRowBackground 5/      �� 50       �� EndPoint$ 1,0.5&�6&    �� 
StartPoint$ 0,0.5&�67   .��51      �  � Color$ 	#220069FF��6#    � Offset$ 0Q�65   � 52      $ 	#89BCFFA6��6#   $ 0.738Q�65   53         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      -   5        brandColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Brand��56   ]      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� $ 	BrandName�6l     57      -   5        nameColumn1��$
 Name��57   X   $	 170 6f    6:   �� $
 Name�6f     58      -   5        descriptionColumn1��$ Description��58   f   $	 300 6{    6A   �� $ Description�6{     59      -   5        lustLevelColumn��$ 
Lust Level��59   a   $ 90 6u    6>   �� $ 	LustLevel�6u     5:      -   5        notesColumn1��$ Notes��5:   Z   $ * 6i    6;   �� $ notes�6i    � ContextMenu 5<      �� 5=      -   5        $��cmnuGrid��5=      .@�5>      m� -   5        $��btnTransfer��5>      $��Transfer to inventory��62   6Q   m� 5?      -   5        $��
btnOrdered��5?      $��Ordered��61   6B   m� 5@      -   5        $��btnKill��5@      $��Killed by other means��6.   6M   5A      5C      5D      5E      