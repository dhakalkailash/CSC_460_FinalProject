   M S B A M L   `   `   `  ����I  EProject_Second, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project_SecondProject_Second  5   	       Project_Second.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Project_Second     5   	     � Title$  
MainWindow��5   	   $��925.463��6   $��1355.303��6-   .��5	      � $��0,0,-36,-379q�6   $
��1059��6   $	��Top=�6,    � RowDefinitions 5
      �� 5      $��0* �6   �� 5       � ColumnDefinitions 5      �� 5      $��0* �6   �� 5      $��8* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $
��443* �6   �� 5      $��0* �6   �� 5      $
��873* �6   �� 5      $��2* �6   �� 5      $	��57* �6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dg��5      $
��Left=�6   $	��385��64   $��
10,201,0,0q�6A   $	��Top=�6U   $
��1292��6m   ���	#FFE6E61E$��5��6�      AutoGenerateColumns .     
IsReadOnly . $��3��6�   $��1��6
     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� *Id+61     5      $ Department ��69    6   �� *
Department+69     5      $ CourseNumber��6;    6   �� *CourseNumber+6;     5      $ 
CourseName��69    6   �� *
CourseName+69     5       $ Description��6:    6   �� *Description+6:     5!      $ Prerequisite��6;    6   �� *Prerequisite+6;     5"      $ 
Instructor��63    6   �� *Inst+63     5$      $ Status��6    5%      `� 5&         StausConverter	 `� 	Converter#	 [  6   .1�5'   	   �� 
 �� Path$
 	ClassSize�6   �� 5(   	   $
 Enrolled�6   5)   	   5+        5-      $ 	ClassSize��68    6   �� *	ClassSize+68     5/      $ Semester��67    6   �� *
Semester+67     50      $
 Year��63    6   �� *Year+63     51      $ Section��66    6   �� *	Section+66     52      $ Credit��65    6   �� *Credit+65     53      $
 Days��63    6   �� *Days+63     54      $
 Time��63    6   �� *Time+63     55      $ Location��67    6   �� *
Location+67   57        58      -   5        $
 dgin��58      $
��Left=�6   $	��255��66   $��
10,591,0,0q�6C   $	��Top=�6W   $
��1292��6o   ���	#FF1ECCE6$��5��6�   $��3��6�   $��1��6�   �� 59      -   5        $��ADD Courses
��59      $
��Left=�6+   $��
10,910,0,0q�6F   $	��Top=�6Z   $	��133��6r   $��40��6~   ���	#FFE2EC1A$��5��6�   $��1��6�   �� 5:      -   5        $��ADD INSTRUCTOR
��5:      $
��Left=�6.   $	��Top=�6I   $	��124��6a   $��189,910,0,0q�6m   $��40��6�   ���	#FF40CCEC$��5��6�    J� RenderTransformOrigin$ 1.311,0.398&�6�   $��1��6�   �� 5;      -   5         ��Name$ 	txtSearch��5;      $��7��6   $
��Left=�6/   $��65��6J   $��
10,109,0,0q�6V   $��2��6j    �� TextWrapping$
 Wrap=�6{   $	��Top=�6�   $	��254��6�   6�   �� 5<      $"��               Filter Search��6
   $��7��61   $
��Left=�6A   $��	10,27,0,0q�6\   $��2��6o   $	��Top=�6�   $	��254��6�   $��63��6�   $
��Bold"�6�   $��16(�6�   �� 5=      -   5        $��3��5=      $��DELETE��6   $��5��60   $
��Left=�6@   $��382,910,0,0q�6[   $��2��6p   $	��Top=�6�   $	��146��6�   $��40��6�   
���<��6�   5?      5@      