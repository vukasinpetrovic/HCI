   M S B A M L   `   `   `  ����D  @WPWeather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPWeather.ViewsWPWeather.Views  5           WPWeather.Views.HourlyView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPWeather.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��0.2* �6   �� 5      $
��0.8* �6   .+�5   
   �� $��0��6   $��Hourly:��5      $��Segoe UI Light)�5      $��56(�5      
�������$��Right=�5      �� 5   
   $��1��6   
������ $��0q�5      $��Segoe UI Light)�5      $��36(�5      
���������5      �� *HourlyWeather+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � |� �� Value .  62   5      ��5       �� 5!      .R�5"      �  � ColumnDefinitions 5#      �� 5$      �� 5%      �� 5&      �� 5'      .+�5)      �� $��0��6    $��Segoe UI Light)�6I   
�������$
��Left=�6x   $��Center=�6�   ��60   �� *Hour+6�   �� 5*      $��1��6    $��50��6V   $��50��6a   $��25, 0, 0, 0q�6m   ��60   �� *TypeOfDayImagePath+6m   �� 5+      $��2��6    $��Segoe UI Light)�6P   
�������$
��Left=�6   $��Center=�6�   $��25, 0, 0, 0q�6�   ��60   �� *Temperature+6�   �� 5,      $��3��6    $��Segoe UI Light)�6N   
�������$
��Left=�6}   $��Center=�6�   $��25, 0, 0, 0q�6�   ��60   �� *	TypeOfDay+6�   5-      5.      50      51      52      