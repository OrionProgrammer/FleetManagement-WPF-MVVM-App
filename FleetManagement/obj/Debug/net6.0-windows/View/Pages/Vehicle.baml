   M S B A M L   `   `   `  ����J  FFleetManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FleetManagement.View.PagesFleetManagement.View.Pages  5      (    "FleetManagement.View.Pages.Vehicle   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:FleetManagement.View.Pages     5        N� Title$  Vehicle��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Vehicle Form��6   $��10q�6)   .��5      � $��1��6    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       '�� M     �� 5      " ��6   .�5      ��  � ��$ 0,0,0,4q�63   5      �� 5      " ��6   .�5      ��  � ��$ 0,0,0,4q�63   5      5       5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5       $
��auto �6$    � ColumnDefinitions 5"      �� 5#      $��50 �6'   �� 5$      $	��300 �6'   .+�5(      �� $
��Make��6   $
��auto��6(   $
��auto��65   $��14(�6C    �� Padding$ 
0, 4, 0, 0q�6Q   $��1��6f   $��0��6s   �� 5)      -   5         ��Name$ txtMake��5)      $	��200��6+   $��25��67   $��14(�6C   $��
2, 2, 0, 0q�6Q   $��1��6f   $��1��6s   �� 5,      $��Model��6   $
��auto��6)   $
��auto��66   $��14(�6D   $ 
0, 4, 0, 0q�6R   $��2��6g   $��0��6t   �� 5-      -   5        $ txtModel��5-      $	��200��6,   $��25��68   $��14(�6D   $��
2, 2, 0, 0q�6R   $��2��6g   $��1��6t   �� 50      $��Status��6   $
��auto��6*   $
��auto��67   $��14(�6E   $ 
0, 4, 0, 0q�6S   $��3��6h   $��0��6u   �� 51      -   5        	 ��Name$	 Status��51      $
��auto��6+   $	��200��69   $��14(�6E   $��3��6S   $��1��6`   .@�52      �� -   5        $��Select��52   #   
 �� 
IsSelected$

 True��61   $��
Select One��6C   �� 53      -   5        $
��Road��53   #   $��On the Road��6/   �� 54      -   5        $��Service��54   #   $��
In Service��62   �� 55      -   5        $��Garage��55   #   $��Garage��61   56      �� 58      -   5         ��Name$ btnSave��58      $��-101, 6, 0, 0q�6*   
����  �
�������$	��100��5:      $��30��6!   $��15(�6-   $
��Save��6;   $��4��5;      $��1��6"   5<      5=      5?      5@      