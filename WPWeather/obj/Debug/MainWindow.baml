   M S B A M L   `   `   `  ����D  @WPWeather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPWeather	WPWeather  5   	   1clr-namespace:WPWeather.ViewsWPWeather.Views  5   	   ;"clr-namespace:WPWeather.ViewModelsWPWeather.ViewModels  5	   	       WPWeather.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #localclr-namespace:WPWeather  5   	   )viewsclr-namespace:WPWeather.Views  5   	   3
viewmodels"clr-namespace:WPWeather.ViewModels  5	   	      MainWindowViewModel  � DataContext#  [  5   	    � Title$ 
MainWindow��5   	   $
��1024��6   $	��576��6)    � 	Resources 5       �� DataType,   &WPWeather.ViewModels.HomepageViewModel"   WPWeather.Views.HomepageView+   %WPWeather.ViewModels.WeatherViewModel!   WPWeather.Views.WeatherView  NoHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%�  (��       5      *, +)(�� 2     5      *, +)&	 d     �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " ��6+   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Center=�6+   $��Center=�6H    5      P� 5      	 �@J�IsMouseOver
 . 5      5       5"      5#      5$      .��5%      � ���#0d47a1 � RowDefinitions 5&   
   �� 5'      $
��0.1* �6   �� 5(      $
��0.8* �6   �� 5)      $
��0.1* �6    � ColumnDefinitions 5+   
   �� 5,      $
��0.2* �6   �� 5-      $
��0.8* �6   .+�5/   
   �� $��0��6   $��0��50      $��🔖 Bookmarks��51      $��Segoe UI Light)�52      $��20(�53      
�������$��Center=�55      $��Center=�56      �� 57   
   $��1��6   $��0��58      $��Segoe UI Light)�59      $��12(�5:      $��Stretch=�5;      $	��Top=�5<      $��Stretch=�5=      $��Stretch=�5>      
������ 
��� ���$��0q�5A      ��5B      �� *	Bookmarks+ �� SelectedItem 5C      �� *SelectedBookmark+.  (System.Windows.Interactivity.Interaction   Triggers 5D      /  )System.Windows.Interactivity.EventTrigger  5E         	EventName$ SelectedItemChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5F      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectedItemChangedCommand+5G      ��5I      �� 5J      .R�5K      �  5L      �� 5M      �� 5N      .+�5P      �� $��0��6    $��Segoe UI Light)�6I   
�������$
��Left=�6x   $��Center=�6�   ��60   �� *City+6�   �� 5Q      $��1��6!   $��20��61   $��X��6<   $��Segoe UI Light)�6H   
������ 
�������$��0q�6�   $��Right=�6�   $��Center=�6�   $��5q�6�   ��6�   �� *CmdDeleteBookmark+5R      5S      5U      �� 5V   
   $��0��6   $��0��5W      $��3��5X       �� Stretch$
 Fill=�5Y      	 �� Y1$ 1��5Z      	 �� Y2$	 100��5[      
�������$��1��5]      $��Right=�5^      5_      � 5`   
   $��1��6    5a      �� 5b      $��0.01* �6#   �� 5c      $
��0.1* �6#   �� 5d      $
��0.9* �6#   �� 5e      $
��0.1* �6#   �� 5f      $��0.15* �6#   .+�5h      �� $��1��6   $��Center=�5i      $��Center=�5j      $��City:��5k      $��Segoe UI Light)�5l      $��16(�5m      
�������5n      �� 5o      $��0��6   $��2��5p      $��Stretch=�5q      $��Center=�5r      $��Segoe UI Light)�5u       �� 
IsEditable .  5s      �� *SelectedCity+��5t      �� *	AllCities+��5w      �� 5x      .R�5y      $� 5z       5|        5}      $ SelectionChanged��6%   . 5~         60   �� *CmdChangedCity+5      5�      �� 5�      $��3��6   $	��⯐��5�      $��24(�5�      
�������
������ $��0q�5�      $��Center=�5�      $��Center=�5�      #��[ 5�      ��5�      �� *CmdLocation+�� 5�      $��4��6   $��24(�5�      
�������
������ $��0q�5�      $��Center=�5�      $��Center=�5�      #��[ 5�      ��5�      �� *BookmarkIcon+��5�      �� *CmdBookmark+5�      � 5�   
   $��1��6   $��1��5�      $��2��5�      .+�5�      �� ��6   �� *	Content+5�      �� 5�   
   $��2��6   $��0��5�      $%��Vukašin Petrović Ltd. © 2019��5�      
�������$��Segoe UI Light)�5�      $��11(�5�      $��Center=�5�      $��Center=�5�      5�      5�      