   M S B A M L   `   `   `  ���� F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalApp.UIHospitalApp.UI       HospitalApp.UI.DoctorsPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:HospitalApp.UI     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�   MaterialDesignBody#���   $��Medium"�$��14(�.��� .+�#  MaterialDesignThemes.Wpf.Card  
�������.��� .+��� $��Doctors:��$	��Top=�$��30(�$��20, 15,200,20q�� $	��Top=�$��Right=�$��0,0,20,0q�.+�c� $��Right=�
����������	#FF555555.@��� -    � ToolTip$ 
Add doctor�� � Cursor$
 Hand�����	#FF555555.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=��� �� -   $ Find doctor��$
 Hand�����	#FF555555.��  $ AccountSearch=��� -   $ Clear��$
 Hand�����	#FF555555.��  $ Eraser=��� $��	0,60,0,20q�$	��590��.����  �� Orientation$ Vertical=�$��20, 10, 0,20q�.+�&   System.Windows.Controls.DataGrid  -     Name$ 
grdDoctors��   AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .  	   CanUserResizeColumns	 . 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   MinWidth$	 100Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$
 Name�  $ Surname��$	 100Q� �� $ Surname�  $ Specialization��$	 100Q� �� $ Specialization� � ContextMenu �� .@�m� -   $��Remove��$��Medium"�m� -   $��	Edit data��$��Medium"�