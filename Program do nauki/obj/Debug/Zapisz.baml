   M S B A M L   `   `   `  ����K  GProgram do nauki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Program_do_naukiProgram_do_nauki  5   	       Program_do_nauki.Zapisz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Program_do_nauki     5   	   -   5          � Title$  Zapisz��5   	   $��67.148��6   $��788.192��6(    � WindowStyle$
 None=�68    � 
ResizeMode$ NoResize=�6K   ���	#FF3C3C3C.��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��19* �6   �� 5      $	��13* �6   .+�5   
   �� -   5         ��Name$ 
btn_saveas��5      $��Zapisz jako��6%   $
��Left=�6;   $��
237,37,0,0q�6V   $	��Top=�6j   $��75��6�   $��1��6�   $��23��6�   
�������
���������5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF8B8B8B��6#    � Offset$ 0Q�65   � 5      $ Black��6#   $ 1Q�61   5      5      �� 5   
   -   5        	 ��Name$	 
tbx_saveas��5      $
��Left=�6&   $��23��6A   $��	10,37,0,0q�6M   
 �� TextWrapping$

 Wrap=�6`   $��TextBox��6t   $	��Top=�6�   $	��692��6�   $��2��6�   ���	#FF2C2C2C
�������
������� �� SelectionBrush �	#FFCDCDCD6  �� 5   
   -   5        $ btn_save��5      $��Zapisz��6#   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $	��692��6z   $��2��6�   
�������
���������5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FF8B8B8B��6#   $ 0Q�65   � 5      $ Black��6#   $ 1Q�61   5      5      �� 5   
   -   5        $ 
btn_anuluj��5      $��Anuluj��6%   $
��Left=�66   $��
237,10,0,0q�6Q   $	��Top=�6e   $��75��6}   $��1��6�   
�������
���������5       �� 5!      $ 0.5,1&�6&   $ 0.5,0&�67   .��5"      � $ 	#FF8B8B8B��6#   $ 0Q�65   � 5#      $ Black��6#   $ 1Q�61   5$      5&      5(      5)      