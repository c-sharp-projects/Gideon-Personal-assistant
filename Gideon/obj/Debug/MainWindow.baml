   M S B A M L   `   `   `  ����A  =Gideon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GideonGideon  5   	       Gideon.GideonBase   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FWpfAnimatedGif, Version=1.4.17.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	    localclr-namespace:Gideon  5   	   -   5          � Title$  Gideon��5	   	   $	��450��6   $	��800��6%   
���   � � WindowStyle$
 None=�6D    � 
ResizeMode$ NoResize=�6W    � WindowStartupLocation$ CenterScreen=�6m    � WindowState$ 	Maximized=�6�   .��5
      � 
���   �.+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��1.5* �6#   �� 5      $��* �6#   .+�5      � $��0��6    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      � -   5        $��WeatherForecastGrid��5       � ToolTip$ Weather��62   $��0��6D   $��4,4,4,4q�6Q   ��5      �� 5       �� EndPoint$ 0.5,1&�6.   	 �� 
StartPoint$	 0.5,0&�6?   .��5      � 
 � Color$
 Black��6+    � Offset$ 0Q�69   � 5       $
 	#FF007ACC��6+   $ 1Q�6=   5!      .+�5%      �� -   5        $��	Weatherlb��5%      
 J� Uid$ 	Weatherlb��6/   $��Stretch=�6?    �� SelectionMode$ Multiple=�6�   ��5&      �� 5'      $ 0.5,1&�62   $	 0.5,0&�6C   .��5(   "   � $
 Black��6/   $ 0Q�6=   � 5)   "   $
 	#FF2A2B2B��6/   $ 1Q�6A   5*      ��5-      �� 5.      .R�5/   "   A�  A� Rows$ 1��6.   50      ��52      �� 53      .R�54   "   �  55   &   �� 56   *   $
��Auto �68   �� 57   *   $��3* �68   �� 58   *   $
��Auto �68   .+�5<   &   � $��0��6+   $
��Left=�68   $	��Top=�6S   .+�5=   *   �� $��Tempus Sans ITC)�6M   $��20(�6j   
���������61   �� *Status+6x   5>   '   � 5@   &   $��1��6+    5A   *   �� 5B   .   $��2* �6?   �� 5C   .   $��* �6?   .+�5F   *   � $��0��6/   .+�5G   .   �� $��Tempus Sans ITC)�6V   $��72(�6s   
���������65   �� *Temperature+6�   5H   +   � 5J   *   $��1��6/   .+�5K   .   �� $
��Left=�6Q   $��50��6l   $��50��6w   ��64   �� *	ImageData+6w   5L   +   5M   '   � 5O   &   $��2��6+   .+�5P   *   �� $��Tempus Sans ITC)�6K   $��24(�6h   
���������61   �� *City+6v   5Q   '   5S   #   5T      5V      5X      � 5Z      -   5        $��NewsGrid��5Z      $
 News��6'   $��1��66   $��4,4,4,4q�6C   ��5[      �� 5\      $ 0.5,1&�6.   $	 0.5,0&�6?   .��5]      � $
 Black��6+   $ 0Q�69   � 5^      $
 	#FF2C2D2D��6+   $ 1Q�6=   5_      .+�5b      �� -   5        $��Newslb��5b      $ Newslb��6,   $��Stretch=�69   $ Single=�6�   ��5i      �� 5j      $ 0.5,1&�62   $	 0.5,0&�6C   .��5k   "   � $
 Black��6/   $ 0Q�6=   � 5l   "   $
 	#FFDEDEDE��6/   $ 1Q�6A   5m      ��5p      �� 5q      .R�5r   "   A� $ 1��6.   5s      ��5u      �� 5v      .R�5w   "   � $	��300��6'   $	��240��63   .+�5z   &   � $��Center=�6,   .+�5{   *   �� ��60   �� *Image+5|   '   5~   #   5      5�      5�      � 5�      -   5        $��GalleryGrid��5�      $ Gallery��6*   $��2��6<   $��4,4,4,4q�6I   .+�5�      �� -   5        $��GalleryButton��5�      $ GalleryButton��62   ��5�      �� 5�       �� ImageSource 6)   �� *	ImageName+5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $��* �6$   �� 5�      $��4* �6$   �� 5�      $��* �6$   .+�5�      � -   5        $��mediaplayergrid��5�      $ Music��6/   $��0��6?   $��4,4,4,4q�6L   ��5�      �� 5�      $ 0.5,1&�6.   $	 0.5,0&�6?   .��5�      � $
 Black��6+   $ 0Q�69   � 5�      $
 	#FF2D2E2E��6+   $ 1Q�6=   5�       5�      �� 5�      $
��auto �6(   �� 5�      $
��auto �6(   .+�5�      � $��0��6   .+�5�      �� $��Music��6    $��Center=�61   $��24(�6N   $��Tempus Sans ITC)�6\   $
��Bold"�6y   ���	#FFFF85006�   5�      � 5�      $��1��6   .+�5�      �� -	   5        $��songTB��5�   $   $��Center=�6M   $��20(�6j   $��Tempus Sans ITC)�6x   $
��Wrap=�6�   $
��Bold"�6�   
��� � ���62   �� *
SongName+6�   5�      5�      � 5�      -
   5        $��cmd_btns_grid��5�      $��1��6,   ��5�      �� 5�      $ 0.5,1&�6.    � MappingMode$ RelativeToBoundingBox=�6?   $	 0.5,0&�6c   .��5�      � $
 Black��6+   $ 0Q�69   � 5�      $
 	#FFDEDEDE��6+   $ 1Q�6=   5�      .+�5�      � -   5        $��btn_grid��5�       5�      �� 5�      $��* �6/   �� 5�      $��3* �6/   �� 5�      $��* �6/   .+�5�      � $��0��6    5�      �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   .+�5�      � $��0��6#   .+�5�   "   �� -   5        $��	GoogleBtn��5�   )   $ 	GoogleBtn��6:   $	��110��6J   $	��110��6W   $��0q�6�   $ Google��6�   ��5�   &   �� 5�   *    65   �� *	GoogleImg+5�   #   5�      � 5�      $��1��6#   .+�5�   "   �� -   5        $��GmailBtn��5�   )   $ GmailBtn��69   $	��110��6H   $	��110��6U   $��0q�6�   $ Gmail��6�   ��5�   &   �� 5�   *    65   �� *
GmailImg+5�   #   5�      � 5�      $��2��6#   .+�5�   "   �� -   5        $��DriveBtn��5�   )   $ DrieBtn��69   $	��110��6G   $	��110��6T   $��0q�6�   $ Google Drive��6�   ��5�   &   �� 5�   *    65   �� *
DriveImg+5�   #   5�      � 5�      $��3��6#   .+�5�   "   �� -   5        $��InstaBtn��5�   )   $ InstaBtn��69   $	��110��6H   $	��110��6U   $��0q�6�   $ 	Instagram��6�   ��5�   &   �� 5�   *    65   �� *
InstaImg+5�   #   5�      5�      � 5     $��1��6    5     �� 5  "   $��* �60   �� 5  "   $��3* �60   �� 5  "   $��* �60   .+�5     � $��1��6#   .+�5  "   �� ��6(   �� *
FlashImg+5     5     � 5     $��2��6    5     �� 5  "   $��* �60   �� 5  "   $��* �60   �� 5  "   $��* �60   �� 5  "   $��* �60   .+�5     � $��0��6#   .+�5   "   �� -   5        $��
YoutubeBtn��5   )   $ 
YoutubeBtn��6;   $	��110��6L   $	��110��6Y   $��0q�6�   $ Youtube��6�   ��5!  &   �� 5"  *    65   �� *
YoutubeImg+5$  #   5%     � 5(     $��1��6#   .+�5)  "   �� -   5        $��FacebookBtn��5)  )   $ FacebookBtn��6<   $	��110��6N   $	��110��6[   $��0q�6�   $ Facebook��6�   ��5*  &   �� 5+  *    65   �� *FacebookImg+5-  #   5.     � 51     $��2��6#   .+�52  "   �� -   5        $��	GithubBtn��52  )   $ 	GithubBtn��6:   $	��110��6J   $	��110��6W   $��0q�6�   $ Github��6�   ��53  &   �� 54  *    65   �� *
GihubImg+56  #   57     � 59     $��3��6#   .+�5:  "   �� -   5        $��MicBtn��5:  )   $ MicBtn��67   $	��110��6D   $	��110��6Q   $��0q�6~   $	 Mic��6�   ��5;  &   �� 5<  *    65   �� *MicImg+5>  #   5?     5A     5B     � 5D     -   5        $��cmd_list_grid��5D     $y�Hidden=�60    5E     �� 5F     $
��auto �6,   �� 5G     $��* �6,   .+�5J     � $��0��6   $��Center=�6,   .+�5K     �� $��Command List��6%   $��Tempus Sans ITC)�6=   $��30(�6Z   
�������6h   5L     � 5N     $��1��6   .+�5O     �� -   5        $��cmdlist��5O  &    �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�6G   $��Tempus Sans ITC)�6[   $��24(�6x   $��0q�6�   
�������.��6�   ��5P  "   �� 5Q  &   $ 0.5,1&�6:   $	 0.5,0&�6K   .��5R  *   � $
 Black��67   $ 0Q�6E   � 5S  *   $
 	#FF1E1F1E��67   $ 1Q�6I   5T  '   .��5U  6   5V     5W     5X     5[     � 5]     -   5        $��
PcInfoGrid��5]     $��2��6)   $��4,4,4,4q�66   ��5^     �� 5_     $ 0.5,1&�6.   $	 0.5,0&�6?   .��5`     � $
 Black��6+   $ 0Q�69   � 5a     $
 	#FF2B2C2C��6+   $ 1Q�6=   5b     .+�5e     � $��Center=�6   $��Center=�68   .+�5f     �� -   5        $��
PcInfoText��5f  $   $
��Wrap=�6N   $��Tempus Sans ITC)�6c   $��20(�6�   ���	#FFFF8500��67   �� *info+6�   5g     5j     5l     � 5n     $��2��6    5o     �� 5p     $��1* �6$   �� 5q     $��4* �6$   �� 5r     $��4* �6$   .+�5w     � -   5        $��DateTimeGrid��5w     $��0��6+   $��4,4,4,4q�68   ��5x     �� 5y     $ 0.5,1&�6.   $	 0.5,0&�6?   .��5z     � $
 Black��6+   $ 0Q�69   � 5{     $
 	#FF2F2F2F��6+   $ 1Q�6=   5|      5~     �� 5     $��* �6(   �� 5�     $��* �6(   .+�5�     � $��0��6   $��0,0,10,0q�6(   .+�5�     �� -   5         ��Name$ clock��5�      $	��Top=�61   
�������$��22(�6\   $
��Bold"�6j   $��Right=�6|   $��Tempus Sans ITC)�6�   5�     � 5�     $��1��6   $��0,0,10,0q�6(   .+�5�     �� -   5        $
 date��5�      $��Right=�6/   $��Bottom=�6L   
�������$��24(�6z   $
��Bold"�6�   $��Tempus Sans ITC)�6�   5�     5�     � 5�     -   5         �Name$ remainder_grid��5�     $y�Hidden=�6/   $��1��6C   $��4,4,4,4q�6Q   ��5�     �� 5�     $ 0.5,1&�6.   $	 0.5,0&�6?   .��5�     � $
 Black��6+   $ 0Q�69   � 5�     $
 	#FF303030��6+   $ 1Q�6=   5�      5�     �� 5�     $��* �6(   �� 5�     $��* �6(   �� 5�     $��* �6(   �� 5�     $��* �6(   .+�5�     � $��0��6   $	��Top=�6(   $��Center=�6@   $��0,5,0,0q�6]   .+�5�     �� $��	Remainder��6    $��24(�65   $��Tempus Sans ITC)�6C   $
��Bold"�6`   ���	#FFFF85006r   5�     � 5�     $��1��6   $��Center=�6(    5�     �� 5�     $
��auto �6/   �� 5�     $
��auto �6/   �� 5�     $
��auto �6/   .+�5�     � $��0��6    5�     �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   .+�5�     � $��0��6#   .+�5�  "   �� -   5         ��Name$ dateButtonUp��5�  )   $ dateButtonUp��6?   $�� ��6R   $��16��6_   $��16��6j    J� RenderTransformOrigin$ 	2.375,0.5&�6v   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     � 5�     $��1��6#   .+�5�  "   �� -   5         ��Name$ textboxDate��5�  *   $ TextboxDate_GotFocus��6?   $��42��6Z   $
 Wrap=�6f   $��24��6z   $��60��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�65   . .��6�  ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5�  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5�  .   $
 White��6;   5�  +   .��5�  :   ��5�  &   �� 5�  *    �� Color$ White��6:    �� Opacity$ 0Q�6H   .��5�  :   5�  #   5�     � 5�     $��2��6#   .+�5�  "   �� -   5        $ dateButtonDown��5�  )   $ dateButtonDown��6A   $�� ��6V   $��16��6b   $��16��6m   $ 	2.375,0.5&�6y   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     5�     � 5�     $��1��6    5�     �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   .+�5�     � $��0��6#   .+�5�  "   �� -   5        $ monthButtonUp��5�  )   $ monthButtonUp��6@   $�� ��6T   $��16��6a   $��16��6l   $ 	2.375,0.5&�6x   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     � 5�     $��1��6#   .+�5�  "   �� -    5        $ textboxMonth��5�  *   $ TextboxMonth_GotFocus��6@   $��42��6\   $
 Wrap=�6h   $��	September��6|   $	��120��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�6>   . .��6�  ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5�  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5�  .   $
 White��6;   5�  +   .��5�  :   ��5�  &   �� 5�  *   $ White��6:   $ 0Q�6H   .��5�  :   5�  #   5�     � 5�     $��2��6#   .+�5�  "   �� -!   5        $ monthButtonDown��5�  )   $ monthButtonDown��6B   $�� ��6Y   $��16��6e   $��16��6p   $ 	2.375,0.5&�6|   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5      5     � 5     $��2��6    5     �� 5  "   $
��auto �60   �� 5  "   $
��auto �60   �� 5	  "   $
��auto �60   .+�5     � $��0��6#   .+�5  "   �� -"   5        $ yearButtonUp��5  )   $ yearButtonUp��6?   $�� ��6R   $��16��6^   $��16��6i   $ 	2.375,0.5&�6u   ��5  &   �� 5  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5  .   � $
 Black��6;   $ 0Q�6I   � 5  .   $
 White��6;   $ 1Q�6I   5  +   5  #   5     � 5     $��1��6#   .+�5  "   �� -#   5        $ textboxYear��5  *   $ TextboxYear_GotFocus��6?   $��42��6Z   $
 Wrap=�6f   $
��2018��6z   $��60��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�67   . .��6�  ��5  &   �� 5  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5  .   $
 White��6;   5  +   .��5  :   ��5   &   �� 5!  *   $ White��6:   $ 0Q�6H   .��5"  :   5#  #   5$     � 5&     $��2��6#   .+�5'  "   �� -$   5        $ yearButtonDown��5'  )   $ yearButtonDown��6A   $�� ��6V   $��16��6b   $��16��6m   $ 	2.375,0.5&�6y   ��5(  &   �� 5)  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5*  .   � $
 Black��6;   $ 0Q�6I   � 5+  .   $
 White��6;   $ 1Q�6I   5,  +   5/  #   50     51     52     � 54     $��2��6   $
��Left=�6(   .+�55     �� -%   5        $��remainderNote��55  "   $��49��68   $
 Wrap=�6D   $
��Note��6X   $	��234��6d   $��0q�6p   $��16(�6�   $��Tempus Sans ITC)�6�   $
��Bold"�6�   ���	#FFFDC567.��6�   ��56     �� 57  "   $ White��62   $ 0Q�6@   .��58  2   59     5:     � 5<     $��3��6   $��Center=�6(   .+�5=     �� -&   5        $	��Set��5=  !   $	 SET��6,   $	��SET��66   $��80��6D   $
��Bold"�6O   $��Tempus Sans ITC)�6a   $��16(�6~   $��0q�6�   
���������5?     �� 5@  "   $	 0,1&�66   $ 0Q�6E   $		 0,0&�6Q   .��5A  &   � $
 	#FFF3F3F3��63   $ 0Q�6E   � 5B  &   $
 	#FFEBEBEB��63   $	 0.5Q�6E   � 5C  &   $
 	#FFDDDDDD��63   $	 0.5Q�6E   � 5D  &   $
 	#FFCDCDCD��63   $ 1Q�6E   5E  #   5G     5H     5L     � 5Q     -'   5        $ alaram_grid��5Q     $��1��6,   $��4,4,4,4q�6:   ��5R     �� 5T     $ 0.5,1&�6.   $	 0.5,0&�6?   .��5U     � $
 Black��6+   $ 0Q�69   � 5V     $
 	#FF303030��6+   $ 1Q�6=   5W      5Z     �� 5[     $��* �6(   �� 5\     $��* �6(   �� 5]     $��* �6(   �� 5^     $��* �6(   .+�5a     � $��0��6   $	��Top=�6(   $��Center=�6@   $��0,5,0,0q�6]   .+�5b     �� $��Alarm��6    $��24(�61   $��Tempus Sans ITC)�6?   $
��Bold"�6\   ���	#FFFF85006n   5c     � 5e     $��1��6   $��Center=�6(    5f     �� 5g     $
��auto �6/   �� 5h     $
��auto �6/   �� 5i     $
��auto �6/   �� 5j     $
��auto �6/   .+�5m     � $��0��6    5n     �� 5o  "   $
��auto �60   �� 5p  "   $
��auto �60   �� 5q  "   $
��auto �60   .+�5t     � $��0��6#   .+�5u  "   �� -(   5        $ hourButtonUp��5u  )   $ hourButtonUp��6?   $�� ��6R   $��16��6_   $��16��6j   $ 	2.375,0.5&�6v   ��5v  &   �� 5w  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5x  .   � $
 Black��6;   $ 0Q�6I   � 5y  .   $
 White��6;   $ 1Q�6I   5z  +   5|  #   5}     � 5     $��1��6#   .+�5�  "   �� -)   5        $ textboxHour��5�  *   $ TextboxDate_GotFocus��6?   $��42��6Z   $
 Wrap=�6f   $��24��6z   $��60��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�65   . .��6�  ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5�  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5�  .   $
 White��6;   5�  +   .��5�  :   ��5�  &   �� 5�  *   $ White��6:   $ 0Q�6H   .��5�  :   5�  #   5�     � 5�     $��2��6#   .+�5�  "   �� -*   5        $ hourButtonDown��5�  )   $ hourButtonDown��6A   $�� ��6V   $��16��6b   $��16��6m   $ 	2.375,0.5&�6y   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     5�     � 5�     $��1��6    5�     �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   .+�5�     � $��0��6#   .+�5�  "   �� -+   5        $ minuteButtonUp��5�  )   $ minuteButtonUp��6A   $�� ��6V   $��16��6c   $��16��6n   $ 	2.375,0.5&�6z   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     � 5�     $��1��6#   .+�5�  "   �� -,   5        $ textboxMinute��5�  *   $ TextboxDate_GotFocus��6A   $��42��6\   $
 Wrap=�6h   $��	September��6|   $	��120��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�6>   . .��6�  ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5�  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5�  .   $
 White��6;   5�  +   .��5�  :   ��5�  &   �� 5�  *   $ White��6:   $ 0Q�6H   .��5�  :   5�  #   5�     � 5�     $��2��6#   .+�5�  "   �� --   5        $ minuteButtonDown��5�  )   $ minuteButtonDown��6C   $�� ��6[   $��16��6g   $��16��6r   $ 	2.375,0.5&�6~   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     5�     � 5�     $��2��6    5�     �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   .+�5�     � $��0��6#   .+�5�  "   �� -.   5        $ secondButtonUp��5�  )   $ secondButtonUp��6A   $�� ��6V   $��16��6b   $��16��6m   $ 	2.375,0.5&�6y   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     � 5�     $��1��6#   .+�5�  "   �� -/   5        $ textboxSecond��5�  *   $ TextboxDate_GotFocus��6A   $��42��6\   $
 Wrap=�6h   $
��2018��6|   $��60��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�69   . .��6�  ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5�  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5�  .   $
 White��6;   5�  +   .��5�  :   ��5�  &   �� 5�  *   $ White��6:   $ 0Q�6H   .��5�  :   5�  #   5�     � 5�     $��2��6#   .+�5�  "   �� -0   5        $ secondButtonDown��5�  )   $ secondButtonDown��6C   $�� ��6Z   $��16��6f   $��16��6q   $ 	2.375,0.5&�6}   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5�  .   � $
 Black��6;   $ 0Q�6I   � 5�  .   $
 White��6;   $ 1Q�6I   5�  +   5�  #   5�     5�     � 5�     $��3��6    5�     �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   �� 5�  "   $
��auto �60   .+�5     � $��0��6#   .+�5  "   �� -1   5        $ meridateButtonUp��5  )   $ meridateButtonUp��6C   $�� ��6Z   $��16��6f   $��16��6q   $ 	2.375,0.5&�6}   ��5  &   �� 5  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5  .   � $
 Black��6;   $ 0Q�6I   � 5  .   $
 White��6;   $ 1Q�6I   5  +   5
  #   5     � 5     $��1��6#   .+�5  "   �� -2   5        $ textboxMeridate��5  *   $ TextboxYear_GotFocus��6C   $��42��6^   $
 Wrap=�6j   $
��2018��6~   $��60��6�   $��22(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   $��Center=�6�   $��Center=�6�   $ 	1.38,0.44&�6  $��0q�6;   . .��6�  ��5  &   �� 5  *   $ 0.5,1&�6>   $ RelativeToBoundingBox=�6O   $	 0.5,0&�6s   .��5  .   � $
 	#FFFDB640��6;   $ 0.986Q�6M   � 5  .   $
 White��6;   5  +   .��5  :   ��5  &   �� 5  *   $ White��6:   $ 0Q�6H   .��5  :   5  #   5     � 5     $��2��6#   .+�5  "   �� -3   5        $ meridateButtonDown��5  )   $ meridateButtonDown��6E   $�� ��6^   $��16��6j   $��16��6u   $ 	2.375,0.5&�6�   ��5  &   �� 5  *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5  .   � $
 Black��6;   $ 0Q�6I   � 5   .   $
 White��6;   $ 1Q�6I   5!  +   5$  #   5%     5&     5(     � 5*     $��2��6   $
��Left=�6(   .+�5+     �� -4   5        $��
AlaramNote��5+  "   $��49��64   $
 Wrap=�6@   $
��Note��6T   $	��234��6`   $��0q�6l   $��16(�6�   $��Tempus Sans ITC)�6�   $
��Bold"�6�   ���	#FFFDC567.��6�   ��5,     �� 5-  "   $ White��62   $ 0Q�6@   .��5.  2   5/     50     � 52     $��3��6   $��Center=�6(   .+�53     �� -5   5        $��alaramSubmit��53  !   $ SetAlarm��65   $	��SET��6D   $��80��6R   $
��Bold"�6]   $��Tempus Sans ITC)�6o   $��16(�6�   $��0q�6�   
���������55     �� 56  "   $	 0,1&�66   $ 0Q�6E   $		 0,0&�6Q   .��57  &   � $
 	#FFF3F3F3��63   $ 0Q�6E   � 58  &   $
 	#FFEBEBEB��63   $	 0.5Q�6E   � 59  &   $
 	#FFDDDDDD��63   $	 0.5Q�6E   � 5:  &   $
 	#FFCDCDCD��63   $ 1Q�6E   5;  #   5=     5>     5B     � 5F     -6   5        $��
QuotesGrid��5F     $��2��6)   $ Motivational Quotes��67   $��4,4,4,4q�6U   ��5G     �� 5H     $ 0.5,1&�6.   $	 0.5,0&�6?   .��5I     � $
 Black��6+   $ 0Q�69   � 5J     $
 	#FF2D2E2E��6+   $ 1Q�6=   5K     .+�5M     �  5N     �� 5O     $
��auto �6,   �� 5P     $��* �6,   .+�5S     � $��0��6   $��Center=�6,   $��Center=�6I   .+�5T     �� $
��Wrap=�6(   $��Quotes��6<   $��30(�6K   $��Tempus Sans ITC)�6Y   ���	#FFFF8500
���   �6�   5U     � 5W     $��1��6   $��Center=�6,   $��Center=�6I   .+�5X     �� -7   5        $��Quote��5X  (   $
��Wrap=�66   $��30(�6c   $��Tempus Sans ITC)�6q   
����� ���6J   �� *Quotes+6�   5Y     5Z     5\     5^     5`     5b     5c     