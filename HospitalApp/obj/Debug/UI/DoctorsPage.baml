   M S B A M L   `   `   `  ����F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalApp.UIHospitalApp.UI  5           HospitalApp.UI.DoctorsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:HospitalApp.UI     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullB
MaterialUI1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5	         MaterialDesignBody#���   5
      $��Medium"�5      $��14(�5      .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  
�������.��5      � .+�5      �� $��Doctors:��6   $	��Top=�6,   $��30(�6D   $��20, 15,200,20q�6R   � 5      $	��Top=�6   $��Right=�6/   $��0,0,20,0q�6K   .+�5      c� $��Right=�6   
����������	#FF555555.@�5      �� -   5         � ToolTip$ 
Add doctor��5   3    � Cursor$
 Hand��6H   ���	#FF555555.��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�62   5      �� 5      �� 5      -   5        $ Find doctor��5   4   $
 Hand��6J   ���	#FF555555.��5        $ AccountSearch=�62   5      �� 5      -   5        $ Clear��5   <   $
 Hand��6L   ���	#FF555555.��5        $ Eraser=�62   5       5!      5"      �� 5%      $��	0,60,0,20q�6   $	��590��62   .��5&      ��  �� Orientation$ Vertical=�6!   $��20, 10, 0,20q�68   .+�5'      &   System.Windows.Controls.DataGrid  -   5          Name$ 
grdDoctors��5'   #      AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .  	   CanUserResizeColumns	 . 
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5)   "   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��65      MinWidth$	 100Q�6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   ��  �� Path$
 Name�  5*   "   $ Surname��65   $	 100Q�6F    6U   �� $ Surname�  5+   "   $ Specialization��65   $	 100Q�6M    6\   �� $ Specialization� � ContextMenu 5-      �� 5.   "   .@�5/   &   m� -   5        $��Remove��5/   /   $��Medium"�6T   m� 50   &   -   5        $��	Edit data��50   /   $��Medium"�6Y   51   #   53      54      55      56      57      58      59      