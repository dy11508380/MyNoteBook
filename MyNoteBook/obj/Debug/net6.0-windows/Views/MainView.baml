   M S B A M L   `   `   `  ����E  AMyNoteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyNoteBook.ViewsMyNoteBook.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	   ?$clr-namespace:MyNoteBook.ExtenstionsMyNoteBook.Extenstions  5   	       MyNoteBook.Views.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyNoteBook.Views     5   	   [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prsimhttp://prismlibrary.com/   5   	   _	 [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5	   	   3system&clr-namespace:System;assembly=mscorlib 	 5
   	   .ext$clr-namespace:MyNoteBook.Extenstions 	 5   	   _
 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 
 5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	   $��微软雅黑)�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � Title$ 
MainWindow��5   	   $	��768��6   $
��1280��6)    � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5      �� 5      $f	 `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $g	 apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Shadows.xaml?�6%   �� 5      $l	 fpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ToggleButton.xaml?�6%   %    5.      .��51      ) 	 #MaterialDesignThemes.Wpf.DialogHost  -   5        
  Name$
 
DialogHost��51   6      DialogTheme$ Inherit=�6       
Identifier$
 Root��52         SnackbarMessageQueue 53      ��  �� ElementName$ MainSnackbar�� �� Path$ MessageQueue�.��55   
   ) 	 #MaterialDesignThemes.Wpf.DrawerHost  -   5          Name$ drawHost��55   $      IsLeftDrawerOpen 66   �� $ MenuToggleButton��$ 	IsChecked�   LeftDrawerContent 56      ]� 57      $	��220��6   .+�59      �� $
��0,20q�6!   $	��Top=�60    �� Orientation$ Vertical=�6E   $��Center=�6\   .+�5:      �� $��50��6!   $��50��6,   $��/images/user.jpeg��68    J� Clip 5;      @� 5<   "    @� Center$ 25,25&�62    @� RadiusX$ 25Q�6A    @� RadiusY$ 25Q�6N   6]   5>      �� 5?      $
��0,10q�6$   ��62   �� *
UserName+6N   5@      �� 5B      -   5         ��Name$ menuBar��5B        MyListBoxItemStyle#��[ 6/   ��6h   �� *	MenuBases+* 
 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5C      + 
 %Microsoft.Xaml.Behaviors.EventTrigger  5D         	EventName$ SelectionChanged��6-   * 
 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5E   "   2 
 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *NavigateCommand+   CommandParameter 6\   ��  �� RelativeSource ��  �� Mode$ FindAncestor=�  �� AncestorType"  ��$ SelectedItem�5H   @   5I      ��5K      �� 5L      .R�5M   "   �� $��Center=�6-   $ 
Horizontal=�6H   
������ .+�5N   &   '	 	 !MaterialDesignThemes.Wpf.PackIcon	  $
��15,0q�6>   ! 	  Kind! 6L   �� *Icon+�� 5O   &   $
��10,0q�60   ��6>   �� *Title+6X   5P   #   5Q      5S      5T      .��5V      � " � RowDefinitions" 5W      �� 5X      $
��auto �6$   64   �� 5Y      6&   .+�5\      '
 	 !MaterialDesignThemes.Wpf.Snackbar
  -   5        # 
 Name$# snackbar��5\   *   $ K� ZIndex$$ 1��6i   % 
  MessageQueue% 6<   4 	 .MaterialDesignThemes.Wpf.MessageQueueExtension  6|   ( 	 "MaterialDesignThemes.Wpf.ColorZone  5]      -   5        &  Name$& 	ColorZone��5]   :   $��16q�6+   . 	 (MaterialDesignThemes.Wpf.ElevationAssist'   	Elevation$	' Dp4=�5^   #   $	��Top=�5_   #   (   Mode$( 
PrimaryMid=�5`   #   .��5a      ]� .+�5b      �� $ 
Horizontal=�6%   .+�5c      d� -   5        ) d�Name$) MenuToggleButton��5c   +   4  .System.Windows.Automation.AutomationProperties*   Name$* HamburgerToggleButton��5d      + d� 	IsChecked$+ FalseY�5e       ' #MaterialDesignHamburgerToggleButton#��[ 5f      �� 5h      $��24,0,0,0q�6%     MaterialDesignToolButton#��[ 5n      , � ToolTip$, Previous Item��5o      + 	 %MaterialDesignThemes.Wpf.RippleAssist-   Feedback- 5i      ��  �� *Self+$ 
Foreground�  BrushRoundConverter. �� 	Converter#. [ ��5j      �� *GoBackCommand+��5k      0 	 *MaterialDesignThemes.Wpf.PackIconExtension  /   Kind$/ 	ArrowLeft=�0   Size0 24��5m      ��  �� "  �$ (TextElement.Foreground)�5o      �� 5q      $��16,0,0,0q�6%   #��[ 5w      $, 	Next Item��5x      - 5r      ��  �� *Self+$ 
Foreground�#. [ ��5s      �� *GoForwardCommand+��5t        $/ 
ArrowRight=�0 24��5v      ��  �� "  �$ (TextElement.Foreground)�5x      �� 5z      $��16,0,0,0q�6(   $��Center=�5{      $��Center=�5|      $* 
MyNoteBook��5}      $��22(�5~      $��	记事本��5      5�      ]� 5�      $��False��6$   $��Right=�6:   .+�5�      ' 	 !MaterialDesignThemes.Wpf.PopupBox  1   ToggleContent1 5�   "   �� 5�   &   $��/images/user.jpeg��6,   $��25��6G   $��25��6R    5�   *   @� 5�   .   $ 	12.5,12.5&�6>   $
 12.5Q�6Q   $
 12.5Q�6`   5�   /   5�   '   2   PopupContent.2 5�   "   �� .+�5�   &   �� $��注销当前账户��6Q   ��6-   �� *LoginOutCommand+6d   5�   #   5�      �� 5�      -   5        3 ��Name$3 btnMin��5�   %   $	��—��66    ! MaterialDesignFlatMidBgButton#��[ 6B   6{   �� 5�      -   5        $3 btnMax��5�   &   $	��☐��66   #��[ 6B   6{   �� 5�      -	   5        $3 btnClose��5�   &   $	��✕��68   #��[ 6D   6}   5�      5�      5�      �� 5�      $��1��6!   )   #MyNoteBook.Extenstions.PrsimManager4   MainViewRegionName!  Prism.Regions.RegionManager5   
RegionName#5 Z4 6.   6�   5�      5�      5�      5�      