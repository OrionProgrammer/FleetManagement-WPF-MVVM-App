   M S B A M L   `   `   `  ����P  LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl  5      J FFleetManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FleetManagement.ViewsFleetManagement.Views 5      -   'FleetManagement.Views.ManageVehicleView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      UcustomBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     5      5local#clr-namespace:FleetManagement.Views     5        N� Title$  Vehicle��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Vehicle Form��6   $��10q�6)   .��5      � $��1��6    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       '�� M     �� 5      " ��6   .�5      ��  � ��$ 0,0,0,4q�63   5      �� 5      " ��6   .�5      ��  � ��$ 0,0,0,4q�63   5      5       5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5       $
��auto �6$    � ColumnDefinitions 5"      �� 5#      $��50 �6'   �� 5$      $	��300 �6'   .+�5(      �� $
��Make��6   $
��auto��6(   $
��auto��65   $��14(�6C    �� Padding$ 
0, 4, 0, 0q�6Q   $��1��6f   $��0��6s   �� 5)      -   5         ��Name$ txtMake��5)      $	��200��5+      $��25��5,      $��14(�5-      $��
2, 2, 0, 0q�5.      $��1��5/      $��1��50      ��5*      �� *Make+	 �� UpdateSourceTrigger$	 PropertyChanged=�50      �� 53      $��Model��6   $
��auto��6)   $
��auto��66   $��14(�6D   $ 
0, 4, 0, 0q�6R   $��2��6g   $��0��6t   �� 54      -   5        $ txtModel��54      $	��200��56      $��25��57      $��14(�58      $��
2, 2, 0, 0q�59      $��2��5:      $��1��5;      ��55      �� *Model+$	 PropertyChanged=�5;      �� 5=      $��4��5>      $��1��5?      $��51, 6, 0, 0q�5@      
 �� Orientation$
 
Horizontal=�5A      .+�5B      �� $��Submit��5D      ��5C      �� *SubmitCommand+5D      �� 5E      $��10,0,0,0q�5F      $��Cancel��5H      ��5G      �� *CancelCommand+��5I      �� 5J       �� BasedOn# [B��6$   " ��6O    �� Triggers 5K   "   �� 5L   &    �� Binding 62   �� *IsSubmitting+ �� Value True6S   .a�5M   *   ��  � {�$ False��6F   5N   '   5P      5R      *   $LoadingSpinnerControl.LoadingSpinner  5S      $��10,0,0,0q�5T      $��Center=�5U         Diameter$ 25Q�5V         	Thickness$ 3Q�5X         Color
 �   �   	IsLoading 5W      �� *IsSubmitting+5Y      5Z      5\      5]      �� 5`   
   $��5��5a      $��0,20,0,0q�5b      
���  ����5d      �� *SubmitErrorMessage+y�5e      �� *HasSubmitErrorMessage+    BooleanToVisibilityConverter �� 	Converter# [  5f      5g      