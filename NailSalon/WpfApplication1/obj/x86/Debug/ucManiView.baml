   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   7       NailSalon.ucManiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &myclr-namespace:NailSalon     5   7   -   5          � 	Resources  5         NailSalon.DataSet2   dataSet2  manicureitemsViewSource �� Source �� Path �� Source��%`   &	        &	      7     5	   
   6   �� 5
   
    6?   �� $ manicureitems�8   5      .��5      �  � DataContext# [ 6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   .+�5      �� -   5        $��lblName��5      $
��Left=�6#   $
��Left=�69   $��	Mani Name��6T   $��24(�6h   �� 5      -   5        $��lblWorn��5      $��Right=�6#   $��Right=�6:   $��Center=�6V   $��Worn it?��6q   $��Italic$�6�   5      ]� 5   
   $��1��6   .+�5      �� -   5        $��lblType��5      $��
Mani type:��6#   $
��Left=�68   $
��Left=�6N   �� 5      -   5        $��	lblLength��5      $��Nail length:��6%   $
��Left=�6<   $
��Left=�6R   �� 5      -   5        $��btnPics��5      $��Pictures��6$   $��Right=�67   $��Right=�6N   6j   5      �� 5   
   -   5        $��lblNotes��5      $0��*Initial thoughts go here and could be long��6$   $��2��6V   $
��Wrap=�6c   ]� 5   
   -   5        $��	dkVerdict��5      $��3��6%   .+�5      �� $��Verdict:��6   $
��Left=�6'   $
��Left=�6=   $	��Top=�6X   �� 5       -	   5        $��
lblVerdict��5       $��9q�6*   $?��9Final verdict goes here and could be long or non existent��65   $
��Left=�6v   $
��Wrap=�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -
   5        $��dgItems��5"   �      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  	   
IsReadOnly	 . 
   EnableRowVirtualization
 . $��Stretch=�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��Stretch=�6  $��4��6!  ��6�   ��    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        brandNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
Brand Name��5$   a      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6u   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� $ 	BrandName�6u     5%      -   5        bottleNameColumn��$ Bottle Name��5%   c   $
 auto 6x    6?   �� $ 
BottleName�6x     5&      -   5        orderColumn��$ Order��5&   Y   $ SizeToHeader 6h    6:   �� $ Order�6h     5'      -   5        usageColumn��$ Usage��5'   Y   $ * 6h    6:   �� $ Usage�6h   5)      5*      5+      