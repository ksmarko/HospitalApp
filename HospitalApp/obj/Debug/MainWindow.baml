   M S B A M L   `   `   `  ����F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HospitalAppHospitalApp  5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          HospitalApp.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HospitalApp     5   	   OMetroUI;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5         MaterialDesignBody#���   5	      $��Medium"�5      $��14(�5      $
��1366��5      $	��728��5        � WindowStartupLocation$  CenterOwner=�5      ���	#FF158576$��1q�5      (  "MahApps.Metro.Controls.MetroWindow   ShowIconOnTitleBar .  !   ShowSystemMenuOnRightClick .     ShowTitleBar .     	GlowBrush �	#FF34AC86 � Icon$ Media/icon.ico��5   -    � WindowState$ 	Maximized=�6C       NonActiveWindowTitleBrush 5      Z�  � TaskbarItemInfo 5      *  $System.Windows.Shell.TaskbarItemInfo  5   
   	   WindowTitleBrush	 5       �� 5!   
     
Foreground
 �� Color#
 �  6      TitleForeground 5$      �� 5%   
   #
 �  6   ��5(      �� 5)   
   #
 �  6   ��5,      �� 5-   
   $
 	#FFECECEC��6   .��50      �  � RowDefinitions 51   
   �� 52      $��40 �6   �� 53      �� 54      $��40 �6    � ColumnDefinitions 56   
   �� 57      $��50 �6   �� 58      �� 59      $��50 �6   .+�5<   
   �� $��
Loading...��6   $��Light"�6&   $��Center=�69   $��Center=�6T   $	��100(�6q   $��0��6�   $��3��6�   $��0��6�   $��3��6�   ���	#FF0066386�   �� 5>   
   $��MarkoDev Studio��5?      $��1��5@      $��	0,0,10,10q�5A      $��2��5B      $��2��5C      $��17��5D      $��Bottom=�5E      $��Right=�5F      $	��112��5G      $��Normal"�5H       � 5J   
   -   5          �Name$ 
MainPageUI��5K        � Source$ UI/MainPage.xaml?�5L      $y�Hidden=�5M      {�.  $��Center=�5O      $��0��5P      $��3��5Q      $��1��5R      $��2��5S      5U      5V      