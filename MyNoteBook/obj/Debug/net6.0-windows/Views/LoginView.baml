   M S B A M L   `   `   `  ����E  AMyNoteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyNoteBook.ViewsMyNoteBook.Views  5      ?$clr-namespace:MyNoteBook.ExtenstionsMyNoteBook.Extenstions  5	           MyNoteBook.Views.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MyNoteBook.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prsimhttp://prismlibrary.com/   5      1pass$clr-namespace:MyNoteBook.Extenstions   5	      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5
      $	��600��5      $	��350��6   #  Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value$	 600��6&   64   �� 5       � ��$	 350��6'   65   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   6G   �� 5       �@�
ResizeMode$ NoResize=�6+   6>   �� 5       �@ WindowStartupLocation$ CenterScreen=�6C   6Z   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   6.   �� 5      6!   .+�5   
   �� $��/images/login.jpg��6   $��50q�6+   69   '  !MaterialDesignThemes.Wpf.Snackbar  5   
   -   5          Name$ LogsnakeBar��5       K� ZIndex$ 1��6L   $��2��6]      MessageQueue 6+   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6s   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  5   
   $��1��6    �� SelectedIndex 6*   �� *SelectedIndex+.@�5       <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .��5!      ]� $��1��6   $��Center=�6,   $��15q�6G   .+�5"      �� $��欢迎使用��6    $��22(�6,   $
��Bold"�6:   $
��0,10q�6L   $	��Top=�6Z   6q   �� 5$      $
��0,10q�6   $	��Top=�6E   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 请输入账号��6Z   ��6,   �� *	Account+6w   G� 5%      $
��0,10q�6"   $	��Top=�6�   $	 请输入密码��6�   /   )MyNoteBook.Extenstions.PassWordExtensions
   PassWord
 60   �� *
Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�* 	 $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5&      -	   'MyNoteBook.Extenstions.PasswordBehavior	  5'      66   5)      �� 5+      $��Login��6@   $��登陆系统��6Y   $	��Top=�6h   $	��0,5q�6}   ��6   �� *ExecuteCommand+6�   ]� 5,      $��False��6    .+�5-      �� $��注册账号��6$      Triggers 5.      +
 	 %Microsoft.Xaml.Behaviors.EventTrigger
  5/       
  	EventName$ MouseLeftButtonDown��6-   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 50   "   2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ Go��6[      Command 68   �� *ExecuteCommand+6s   51      53      �� 54      $��忘记密码?��6$   $��Right=�61   6J   55      56      57        59      .��5:      ]� $��Center=�6   $��15q�67   .+�5;      �� $��注册账号��6    $��22(�6,   $
��Bold"�6:   $	��Top=�6L   6c   �� 5=      $
��0,10q�6?   $	��Top=�6M   $	 请输入账号��6b   ��6   �� *UserDto.Account+6   �� 5>      $
��0,10q�6@   $	��Top=�6N   $	 请输入用户名��6c   ��6   �� *UserDto.UserName+6�   G� 5?      $
��0,10q�6"   $	��Top=�6�   $	 请输入密码��6�   
 61   �� *UserDto.Password+$ TwoWay=�$ PropertyChanged=� 5@      	  5A      66   5C      G� 5D      $
��0,10q�6"   $	��Top=�6�   $	 请再次输入密码��6�   
 60   �� *UserDto.NewPassword+$ TwoWay=�$ PropertyChanged=� 5E      	  5F      66   5H      �� 5J      $��Register��6@   $��注册账号��6\   $	��Top=�6k   $	��0,5q�6�   ��6   �� *ExecuteCommand+6�   �� 5K      $��Return��6@   $��返回账号��6Z   $	��Top=�6i   $	��0,5q�6~   ��6   �� *ExecuteCommand+6�   5L      5M      5N      5O      5P      