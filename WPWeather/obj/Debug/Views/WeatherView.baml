   M S B A M L   `   `   `  ����D  @WPWeather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPWeather.ViewsWPWeather.Views  5      ;"clr-namespace:WPWeather.ViewModelsWPWeather.ViewModels  5      !    WPWeather.Views.WeatherView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPWeather.Views     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      3
viewmodels"clr-namespace:WPWeather.ViewModels  5         WeatherViewModel  � DataContext#  [  5      .��5      � $��50, 0, 50, 0q�6    � RowDefinitions 5   
   �� 5      $��0.45* �6   �� 5      $
��0.1* �6   �� 5      $��0.45* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   (� $��0��6   $��0��5      $��2��5      $��10q�5      $
��Left=�5      .��5         WPWeather.Views.DayView    6   �� *SelectedDayViewModel+5      (� 5<   
   $��0��6   $��2��5=      $��3��5>      $��10q�5?       (� Stretch$ Uniform=�5@      $	��Top=�5A      $��Right=�5B      .��5C          WPWeather.Views.HourlyView    6   �� *SelectedHourlyViewModel+5D      �� 5E   
   $��1��6   $��0��5F      $��5��5G      $��Following 5 days:��5H      $��Segoe UI Light)�5I      $��16(�5J      
�������$��Stretch=�5L      $��Center=�5M      $��
0, 1, 0, 0q�5N      
�������5O      (� 5P   
   $��2��6   $��0��5Q      $��10q�5R      .  (System.Windows.Interactivity.Interaction   Triggers 5S      /  )System.Windows.Interactivity.EventTrigger  5T         	EventName$ MouseLeftButtonUp��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5U      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *
ClickOnDay+   CommandParameter 6K   �� 	 �� ElementName$
	 Day1��
 �� Path$
 DataContext�5V      .��5X        -   5          Name$
 Day1��5X        6*   �� *DayViewModels[0]+5Y      (� 5Z   
   $��2��6   $��1��5[      $��10q�5\       5]        5^      $ MouseLeftButtonUp��6!   . 5_         6,   �� *
ClickOnDay+ 6K   �� $
	 Day2��$
 DataContext�5`      .��5b        -   5        $
 Day2��5b        6*   �� *DayViewModels[1]+5c      (� 5d   
   $��2��6   $��2��5e      $��10q�5f       5g        5h      $ MouseLeftButtonUp��6!   . 5i         6,   �� *
ClickOnDay+ 6K   �� $
	 Day3��$
 DataContext�5j      .��5l        -   5        $
 Day3��5l        6*   �� *DayViewModels[2]+5m      (� 5n   
   $��2��6   $��3��5o      $��10q�5p       5q        5r      $ MouseLeftButtonUp��6!   . 5s         6,   �� *
ClickOnDay+ 6K   �� $
	 Day4��$
 DataContext�5t      .��5v        -   5        $
 Day4��5v        6*   �� *DayViewModels[3]+5w      (� 5x   
   $��2��6   $��4��5y      $��10q�5z       5{        5|      $ MouseLeftButtonUp��6!   . 5}         6,   �� *
ClickOnDay+ 6K   �� $
	 Day5��$
 DataContext�5~      .��5�        -   5        $
 Day5��5�        6*   �� *DayViewModels[4]+5�      5�      5�      