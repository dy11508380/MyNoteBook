   M S B A M L   `   `   `  ����  
MyNoteBook*    $MyNoteBook.Views.Dialogs.AddToDoView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��450��5       $	��280��6,   .��5      �   � RowDefinitions  5	   
   �� 5
      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   ��  �� Padding$ 20,10q�6   $��添加待办��6$   $
��Bold"�60   $��20(�6B   6R   ]� 5   
   $��1��6   $��False��6!   .+�5      �� $��20,10q�6   $	��Top=�6(    �� Orientation$ 
Horizontal=�6=   .+�5      �� $��状态:��6   $��Center=�6'   6D   �� 5      $��10,0,0,0q�6B    �� SelectedIndex 6   �� *Model.Status+.@�5      �� .��6#   待办6'   �� 5      .��6#   	已完成6(   5      5      �� 5      $
��20,0q�63   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要��6A   $	��Top=�6^   ��6   �� *Model.Title+6u   �� 5      $
��20,0q�66   $	��100��6D    �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�5      $ 请输入待办内容��5      $	��Top=�63   ��5      �� *Model.Content+5   J   5       �� 5#   
   $��10q�6   $ 
Horizontal=�6!   $��2��6:   $��Right=�6G   .+�5$      �� $��取消��6   $��0,0,10,0q�6D       MaterialDesignOutlinedButton#��[  6V   ��6"   �� *CancelCommand+6�   �� 5%      $��确定��6   ��6"   �� *SaveCommand+6D   5&      5'      5(      