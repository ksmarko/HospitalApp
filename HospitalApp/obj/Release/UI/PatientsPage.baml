   M S B A M L   `   `   `  ���� F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalApp.UIHospitalApp.UI  !    HospitalApp.UI.PatientsPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:HospitalApp.UI     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�   MaterialDesignBody#���   $��Medium"�$��14(�.���  � ColumnDefinitions �� $��5* ��� $��2* �.+��� -   $��
Add record��$��1��$��Bottom=�$��Center=�$��0, 0, 0, 20q�#  MaterialDesignThemes.Wpf.Card  
�������$��0,0,0,0q�$��1��$	��670��.��� .+���  �� Orientation$ Vertical=�.+�� .+��� $��	Patients:��$��
20,40,0,10q�$
��Left=�$��20(�� $	��Top=�$��Right=�$��	20,20,0,0q�.+�c� $��Right=�
����������	#FF555555.@��� -    � ToolTip$ Remove patient�� � Cursor$
 Hand�����	#FF555555.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Delete=��� -   $ Find patient��$
 Hand�����	#FF555555.��  $ AccountSearch=��� -   $ Clear��$
 Hand�����	#FF555555.��  $ Eraser=��� -   $��lstPatients��$	��480��$��20, 10,20,0q� � ContextMenu �� .@�m� -   $��Remove���� -   $��Add patient��$	��120��$��Bottom=�$��Center=�$��0, 0, 0, 20q�  
�������$��0,0,5,0q�$��0��$	��670��.��� .+�� -	   $��grdPatientContent��.+��� $ Vertical=�.+��� $ 
Horizontal=�$��0��.+�  $ Account=�$	��100��$	��100��$��40, 30, 0,0q��� $ Vertical=�$��
30, 50,0,0q�$	��Top=�.+��� -
   $��txtName��$��34(�$��5q��� -   $��txtPhone��$��5q��� -   $��txtMail��$��5q�&   System.Windows.Controls.DataGrid  -     Name$ grdCard��$	��400��$��20,10,20,20q�   AutoGenerateColumns . 	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .    
IsReadOnly .    SelectionMode$ Single=��� -   $��
Add record��$	��120��$��0, 0, 20, 20q�$��Bottom=�$��Right=��� -   $��Enroll��$	��120��$��0, 0, 160, 20q�$��Bottom=�$��Right=��� -   $��grdEmptyContent��$ Vertical=�$��Center=�$��Center=�$y�Hidden=�.+��� $��
No content��$��40(�$��Normal"�$��Center=��� $��Please select patient��$��0, 10, 0,10q�$��Normal"�$��30(�$��Center=�  $ Glasses=�$��	0, 0, 0,0q�$	��100��$	��100��$��Center=�