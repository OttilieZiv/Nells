   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NailSalon.UsercontrolsNailSalon.Usercontrols  5   {       NailSalon.EditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   3my$clr-namespace:NailSalon.Usercontrols     5   {   -   5        $��AddEditWindow��5   K     � Title$  Edit Window��6	   $	��271��6   $	��551��6*    � WindowState$ Normal=�66   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6    $��Brand:��6-   $��Right=�6>   �� 5   
   $��0��6   $��1��6    $��Name:��6-   $��Right=�6=   �� 5   
   $��0��6   $��2��6    $��Description:��6-   $��Right=�6D   �� 5   
   $��0��6   $��3��6    $��	Acquired:��6-   $��Right=�6A   �� 5   
   $��0��6   $��4��6    $��Coats on swatch:��6-   $��Right=�6H   �� 5   
   $��0��6   $��5��6    $��Swatching notes:��6-   $��Right=�6H   1   +NailSalon.Usercontrols.ucBrandPickerWithAdd  5   
   -   5          Name$ cmbBrand��5   ?   $��1��6"   $��0��62   $��Stretch=�6Q   $��Stretch=�6o   $��0��6�   �� 5   
   -   5        $��txtName��5   M   $��1��6   $��1��6"   $��Stretch=�6/   $��Stretch=�6\   $��1��6x   �� 5   
   -   5        $��txtDesc��5   M   $��1��6   $��2��6"   $��Stretch=�6/   $��Stretch=�6\   $��2��6x   �� 5   
   -   5        $��txtNotes��5   M   $��1��6   $��5��6"   $��Stretch=�6/   $��Stretch=�6]   $��8��6y    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   ]� 5   
   -   5        $��
dockPanel1��5   O   $��1��6   $��4��6$   $��Stretch=�61   $��Stretch=�6a   .+�5      �� -   5        $��txtCoats��5      $
��Left=�6&   $��40��6<   $��5��6G   �� 5      $��Drawer:��6   $
��Left=�6&   �� 5       -   5        $��	cmbDrawer��5       $
��Left=�6(   $	��100��6>   $��6��6J   �� 5!      -	   5        $��cbxUsed��5!      $��?Used it yet��6&   $��Right=�6=   $��3q�6T   $��7��6_   $��Center=�6l   $��Right=�6�   $��Right=�6�   $��RightToLeft=�6�   5"      �� 5#   
   -
   5        $��btnTags��5#      $��4��6    $��2��6-   $
��Tags��6=   6L   ]� 5$   
   $��1��6   $��3��6$   $��Stretch=�61   $��Stretch=�6O   .+�5%      �� -   5        $��cbxAcDateKnown��5%      $��3��6-   $��Known��6:   $
��Left=�6J   $
��Left=�6`   $��Center=�6{   $��LeftToRight=�6�   $��3q�6�   6�   (  "System.Windows.Controls.DatePicker  5&      -   5        $��
dpAcquired��5&      $
��Left=�6+   $
��Left=�6A   $	��150��6\   $��3q�6h   $��4��6s   5'      �� 5(   
   -   5        $��btnSave��5(      $��2��6    $��1��60   $
��SAVE��6=   $��10��6b   �� 5)   
   -   5        $��	btnCancel��5)      $��2��6"   $��2��62   $��Cancel��6?   $��11��6h   �� 5*   
   -   5        $��btnIRLNotes��5*      $��2��6$   $��5��64   $��IRL...��6A   $��Bottom=�6R   $��9��6m   6z   5,      5-      