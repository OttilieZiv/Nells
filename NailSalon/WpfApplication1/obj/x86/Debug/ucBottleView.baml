   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   7       NailSalon.ucBottleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &myclr-namespace:NailSalon     5   7   -   5          � 	Resources  5         NailSalon.DataSet1   dataSet1  notesViewSource �� Source �� Path �� Source��%X   &	        &	      7     5	   
   6   �� 5
   
    67   �� $ notes�8   5      .��5      �  � DataContext# [ 6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lblID��5      $��
Bottle ID:��6   $��0��62   $��11(�6?   $��Italic$�6M   �� 5   
   -   5        $��	lblDrawer��5      $��Swatch stored in: ��6!   $��0��6>   $��Right=�6K   $��11(�6g   $��Italic$�6u   ]� 5   
   $��1��6   .+�5      �� -   5        $��lblBrand��5      $��Brand��6$   $��24(�64   �� 5      -   5        $��lblName��5      $��Polish Name��6#   $��24(�69   5      �� 5   
   -   5        $��lblDesc��5      $*��$Polish description gubbins goes here��6   $��2��6N   ]� 5   
   $��3��6   .+�5      �� -   5        $��lblDateBought��5      $"��Bought this one on 10/05/12 ��6)   �� 5       -   5        $��lblUsed��5       $#��and I haven't used it IRL yet��6#   5!      �� 5"   
   -	   5        $��lblSwatchNotes��5"      $2��,Swatch notes will go here, and could be long��6*   $��4��6^   $
��Wrap=�6k   �� 5#   
   $��Notes:��6   $��5��6!   �� 5$   
   -
   5        $��lblTags��5$      $��Tags:��6   $��7��6/   &   System.Windows.Controls.DataGrid  5%   
   -   5        $��dgNotes��5%   �      AutoGenerateColumns .     EnableRowVirtualization . $��6��6N   $��Stretch=�6[      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��Stretch=�6�   	   CanUserAddRows	 .  
   CanUserDeleteRows
 .  ��6y   ��    Columns 5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      -   5        noteDateColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 	Note Date��5'   A      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6T      CellTemplate 5(      �� 5)      .R�5*      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� $ NoteDate� �� Mode$ TwoWay=� �� ValidatesOnExceptions .  �� NotifyOnValidationError . 5+      5-      0  *System.Windows.Controls.DataGridTextColumn  5.      -   5        noteTextColumn��$ 	Note Text��5.   _   $ * 6r   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� $ NoteText�   ElementStyle 5/      �� 50       �� 
TargetType" ��6    .�51      ��  �� Property � �� �� Value$ WrapWithOverflow=�6=   52      54      56      57      58      