   M S B A M L   `   `   `  ����F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalApp.UIHospitalApp.UI  5          HospitalApp.UI.MainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:HospitalApp.UI     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5
         MaterialDesignBody#���   5      $��Medium"�5      $��14(�5      $	��875��5      $	��675��5      .��5      � ���	#FFECECEC � ColumnDefinitions 5   
   �� 5      $��8* �6   �� 5      $	��34* �6   .+�5   
   � -   5        $��grdSelectedMenuItem��5      
����� �$��5��6<   $��60��6F   $	��Top=�6R   $
��Left=�6j   �� 5   
   $��0��6   .+�5      �� -   5        $��lstMenu��5      .@�5      �� $��60��6   $��20,8,8,8q�6*   .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  ���	#FF323232�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Home=�6E   $��40��6Q   $��40��6]   $��Center=�6h   $��Center=�6�   �� 5       $
��HOME��6$   $��10,0,0,0q�60   $��Center=�6B   $��Center=�6_   5!      5"      �� 5#      $��60��6   $��20,8,8,8q�6*   .��5$      �� $ 
Horizontal=�6!   .+�5%        ���	#FF323232$ Account=�6E   $��40��6T   $��40��6`   $��Center=�6k   $��Center=�6�   �� 5&      $��DOCTORS��6$   $��10,0,0,0q�63   $��Center=�6E   $��Center=�6b   5'      5(      �� 5)      $��60��6   $��20,8,8,8q�6*   .��5*      �� $ 
Horizontal=�6!   .+�5+        ���	#FF323232$ AccountMultiple=�6E   $��40��6\   $��40��6h   $��Center=�6s   $��Center=�6�   �� 5,      $��PATIENTS��6$   $��10,0,0,0q�64   $��Center=�6F   $��Center=�6c   5-      5.      5/      50      #  MaterialDesignThemes.Wpf.Card  53   
   -   5        $��grdMain��53      $��1��6)   $��2��69   
�������$��	0,0,10,10q�6`   $��Stretch=�6s   .��54      � .+�55      �� $ Vertical=�6   $��20, 15, 20, 20q�64   .+�56      �� $��	Shedule: ��6    $��30(�61   �� 57      $ 
Horizontal=�6!   $��	0, 10,0,0q�6:   .+�58      �� -   5        $��cboxDoctorsList��58   #   $	��300��6:   $
��Left=�6F   (  "System.Windows.Controls.DatePicker  59      -   5        $��dpDate��59   %   $��	20, 0,0 0q�63   $	��150��6F   m� 5:      -   5        $��Clear��5:   #   $	��120��62   $��Center=�6>   $��
50, 0,0, 0q�6b   $��Center=�6�   �� 5;      -   5        $
��Find��5;   !   $	��120��60   $��
20, 0,0, 0q�6<   6P   5<      �� 5=      $	��480��6#   $	��Top=�60   $��	0,20, 0,0q�6H   .��5>      &   System.Windows.Controls.DataGrid  -	   5          Name$ grdSchedule��5>   #      AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . 	   SelectionMode$	 Single=�6�   
   Columns
 5?      0  *System.Windows.Controls.DataGridTextColumn  5@   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Doctor��65      MinWidth$	 120Q�6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   ��  �� Path$ Doctor�  5A   "   $
 Date��65   $	 100Q�6C    6R   �� $
 Date�  5B   "   $
 Time��65   $	 100Q�6C    6R   �� $
 Time�  5C   "   $ Addition��65   $	 175Q�6G    6V   �� $ Addition� � ContextMenu 5E      �� 5F   "   .@�5G   &   m� -
   5        $��Remove��5G   /   $��Medium"�6V   5H   #   5J      5K      5L      �� 5M      -   5        $��Add schedule��5M      $��Bottom=�6D   $��Right=�6_   $��
0,0,20, 20q�6{   $	��120��6�   5N      5O       � 5Q   
   -   5          �Name$ DoctorsPageUI��5R        � Source$0 */HospitalApp;component/UI/DoctorsPage.xaml?�5S      $��0, 0, 10, 10q�5T      $y�Hidden=�5U      {�.  $��1��5W       � 5Y   
   -   5        $ PatientsPageUI��5Z      $1 +/HospitalApp;component/UI/PatientsPage.xaml?�5[      $��0, 0, 10, 10q�5\      $y�Hidden=�5]      {�.  $��1��5_      5`      5a      