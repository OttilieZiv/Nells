   M S B A M L   `   `   `  ����D  @NailSalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NailSalon	NailSalon  5   B       NailSalon.BottleNotes   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &myclr-namespace:NailSalon     5   B   -   5          � Title$  Notes on a small bottle��5   	   $	��313��6)   $	��970��66    � 	Resources 5         NailSalon.DataSet1   dataSet1  bottleNotesViewSource �� Source �� Path �� Source��%^   &	        &	      7     5   
   6   �� 5   
    6=   �� $ BottleNotes�8   5      .��5	      �  � DataContext# [ 6    � ColumnDefinitions 5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
btnNewNote��5      $��Add new note��6#   $��3q�6:   $
��Left=�6E   6`   �� 5   
   -   5        $��btnClose��5      $��Close��6!   $��3q�61   $��Right=�6<   6X   � 5   
   -   5        $��
grdNewNote��5   V   $��1��6   $��Stretch=�6   $��Stretch=�6:    5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� -   5        $��txtNote��5      $��0��6%   $��Stretch=�65   $��70��6S   $��3q�6_    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�6   �� 5      -   5        $��btnSaveNote��5      $��1��6(   $
��Save��68   $��Stretch=�6G   $	��Top=�6e   $��3q�6}   6�   �� 5      -   5        $��btnCancelNote��5      $��1��6*   $��Cancel��6:   $��Right=�6K   $��Bottom=�6g   $��3q�6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgNotes��5      $��2��6"   
   AutoGenerateColumns
 .     EnableRowVirtualization . $��Stretch=�5      $��3q�6I      
IsReadOnly .    RowDetailsVisibilityMode$ VisibleWhenSelected=�5      $��Stretch=�6B      CanUserAddRows .     CanUserDeleteRows .  ��5   1   ��    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      -	   5        dateTextColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Date��5!   _      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� $ DateText�6m     5"      -
   5        noteTextColumn��$
 Note��5"   _   $ * 6m    6=   �� $ NoteText�6m    � ContextMenu 5$      �� 5%      -   5        $��mnuGrid��5%      .@�5&      m� -   5        $��btnEditNote��5&      $
��Edit��62   6@   5'      5)      5*      5+      