   M S B A M L   `   `   `  ���� F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalApp.UIHospitalApp.UI      HospitalApp.UI.MainPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:HospitalApp.UI     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�   MaterialDesignBody#���   $��Medium"�$��14(�$	��875��$	��675��.��� ���	#FFECECEC � ColumnDefinitions �� $��8* ��� $	��34* �.+�� -   $��grdSelectedMenuItem��
����� �$��5��$��60��$	��Top=�$
��Left=��� $��0��.+��� -   $��lstMenu��.@��� $��60��$��20,8,8,8q�.����  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  ���	#FF323232�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Home=�$��40��$��40��$��Center=�$��Center=��� $
��HOME��$��10,0,0,0q�$��Center=�$��Center=��� $��60��$��20,8,8,8q�.���� $ 
Horizontal=�.+�  ���	#FF323232$ Account=�$��40��$��40��$��Center=�$��Center=��� $��DOCTORS��$��10,0,0,0q�$��Center=�$��Center=��� $��60��$��20,8,8,8q�.���� $ 
Horizontal=�.+�  ���	#FF323232$ AccountMultiple=�$��40��$��40��$��Center=�$��Center=��� $��PATIENTS��$��10,0,0,0q�$��Center=�$��Center=�#  MaterialDesignThemes.Wpf.Card  -   $��grdMain��$��1��$��2��
�������$��	0,0,10,10q�$��Stretch=�.��� .+��� $ Vertical=�$��20, 15, 20, 20q�.+��� $��	Shedule: ��$��30(��� $ 
Horizontal=�$��	0, 10,0,0q�.+��� -   $��cboxDoctorsList��$	��300��$
��Left=�(  "System.Windows.Controls.DatePicker  -   $��dpDate��$��	20, 0,0 0q�$	��150��m� -   $��Clear��$	��120��$��Center=�$��
50, 0,0, 0q�$��Center=��� -   $
��Find��$	��120��$��
20, 0,0, 0q��� $	��480��$	��Top=�$��	0,20, 0,0q�.��&   System.Windows.Controls.DataGrid  -	     Name$ grdSchedule��   AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . 	   SelectionMode$	 Single=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Doctor��   MinWidth$	 120Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Doctor�  $
 Date��$	 100Q� �� $
 Date�  $
 Time��$	 100Q� �� $
 Time�  $ Addition��$	 175Q� �� $ Addition� � ContextMenu �� .@�m� -
   $��Remove��$��Medium"��� -   $��Add schedule��$��Bottom=�$��Right=�$��
0,0,20, 20q�$	��120�� � -     �Name$ DoctorsPageUI��  � Source$0 */HospitalApp;component/UI/DoctorsPage.xaml?�$��0, 0, 10, 10q�$y�Hidden=�{�.  $��1�� � -   $ PatientsPageUI��$1 +/HospitalApp;component/UI/PatientsPage.xaml?�$��0, 0, 10, 10q�$y�Hidden=�{�.  $��1��