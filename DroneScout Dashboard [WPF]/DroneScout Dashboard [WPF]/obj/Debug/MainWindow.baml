   M S B A M L   `   `   `  ����U  QDroneScout Dashboard [WPF], Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DroneScout_Dashboard__WPF_DroneScout_Dashboard__WPF_  5   	   d `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes 5   	   +    %DroneScout_Dashboard__WPF_.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:DroneScout_Dashboard__WPF_     5   	   `ThemesMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic     5   	     � Title$  DroneScout Dashboard��5	   	   $��937.435��6&   $��1595.565��67    � AllowsTransparency .  � WindowStyle$
 None=�6b    � WindowStartupLocation$ CenterScreen=�6u    � WindowState$ 	Maximized=�6�   
���   � � 	Resources 5
         CodeXButton �� 
TargetType �� Property �� Value	 J� SnapsToDevicePixels
 �� StrokeDashArray �� 
TargetType5  /Microsoft.Windows.Themes.ClassicBorderDecorator  Name   BorderBrush   BorderThickness   BorderStyle   
Background �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6$   .�5      ��  �@�FocusVisualStyle 5      �� 5      .�5      ��  � �� 5      �� 5   "   .R�5   &   �� ._�5   *   �� $��4q�64   	 . #��� ��6Z   $��1��6�   $	
 1 2R�6�   5   '   5   #   5      5      5      �� 5       � ��# � ��6+   �� 5       � ��# � ��6+   �� 5       � �� �	#000000006,   �� 5       � ��$ 3q�60   �� 5       � ��$ Center=�6;   �� 5        � ��$ Center=�69   �� 5!       � ��$ 0,0,1,1q�6(   �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%        $ ContentContainer��68   # z��6R   $ 3q�6~   $ Raised=�6�   # z��6�   	 . ._�5&      �� #��z��6/   #��z��6c   # z 6�   #��z��6�   #��z��6  ��. #	 z	 6D  #��z��6�  5'       5(      P� 5)       �@J�IsKeyboardFocused . . �5*   "   �� $ ContentContainer��6@    �@ BorderStyle$ RaisedFocused=�6^   5+      P� 5,       �@��IsDefaulted . . �5-   "   �� $ ContentContainer��6@    �@ BorderStyle$ RaisedFocused=�6^   5.      P� 5/       � �� . . �50   "   �� $ ContentContainer��6@    �@ BorderStyle$ RaisedPressed=�6^   51      P� 52       �@d�	IsChecked$
 TrueY�6H   . �53   "   �� $ ContentContainer��6@    �@ BorderStyle$ RaisedPressed=�6^   54      P� 55       � {� .  . �56   "   �� # � ��6?    � ��57      59      5;      5<      5=      .��5>      � .+�5?   
   �� $��0,96.541,9,263.269q�6   $��Right=�6-   $��1012.765��6I   .+�5@      �� -   5         ��Name$ image��5@      $��793.77��6#   $��567.625��62   �� 5A      ���	#FFF73800$��71��6)    �� Left$ 313.859��65   
 �� Top$	 155��6K   $��2.152��6\   �� 5B      ���	#FFF73800$��71��6)   $ 313.859��65   $	 155��6K   $��2.152��6\    J� RenderTransformOrigin$ 0.5,0.5&�6j   z�5C      V� 5D      .~�5E      �� �� 5F      �� 5G       �� Angle$ 90Q�6*   T� 5H      5I      5K      5L      �� 5M   
   $��0,89.39,195.121,76.151q�6   $
��Fill=�60   $��Right=�6?   $��950.444��6[   $��DroneFrame.png��6k   �� 5N   
   -   5        $ CameraPreviewImage��5N      $$��55.333,147.04,1191.232,520.395q�6,   �� 5O   
   -   5         ��Name$ Camera_Feed��5O      $��Start Live Feed��6&   $��0,527.05,153.153,0q�6@   $��76.96��6n   $	��Top=�6}   $��Right=�6�   $	��231��6�   �� 5P   
   -   5        $ Camera_Take��5P      $��TAKE SNAPSHOT��6&   $
��Left=�6>   $��50,487.694,0,0q�6Y   $	��Top=�6q   $	��345��6�   $��44.96��6�   ���	#FF63BD24$
��Bold"�6�   $��18(�6�   ���	#FF2A5D00#���   6  �� 5Q   
   -   5        $ ImageUpload��5Q      $��Upload Image(s)��6&   $
��Left=�6@   $��55.333,542.654,0,0q�6[   $	��Top=�6w   $��339.667��6�   $��45.752��6�   #���   6�   ���	#FFD33C10$
��Bold"�6�   $��16(�6�   6  �� 5R   
   $��	48,39,0,0q�6   $��Logo.png��6#   $
��Fill=�65   $
��Left=�6D   $��208.371��6_   $��62��6o   $	��Top=�6{   5T      5U      