   M S B A M L   `   `   `  ����F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalApp.UIHospitalApp.UI  5   	   !    HospitalApp.UI.SearchWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HospitalApp.UI     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Find doctor��5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5	   	      MaterialDesignBody#���   5
      $��Medium"�5      $��14(�5      $	��385��5      $	��400��6    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�61   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��40, 10, 40, 0q�6,   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6"   $	��100��61   $	��100��6>   $��Center=�6J   �� 5      $
��Name��6   $��	20,5,20,0q�6$   �� 5      -   5        $��txtName��5      $��	20,5,20,0q�6%   �� 5      $��Surname��6   $��	20,5,20,0q�6'   �� 5      -   5        $��
txtSurname��5      $��	20,5,20,0q�6(   �� 5      -   5        $��lblSpec��5      $��Specialization��6'   $��	20,5,20,0q�6=   �� 5      -   5        $��txtSpec��5      $��
20,10,20,0q�6%   5      �� 5   
   -   5        $��
btnFindDoc��5      $
��Find��6#   $��100,0,100,30q�6E   $��Bottom=�6[   $y�Visible=�6v   �� 5   
   -   5        $��
btnFindPat��5      $
��Find��6#   $��100,0,100,30q�6F   $��Bottom=�6\   $y�Hidden=�6w   5      5      