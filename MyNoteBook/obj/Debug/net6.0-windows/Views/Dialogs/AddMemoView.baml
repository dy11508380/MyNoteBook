   M S B A M L   `   `   `  ����  
MyNoteBook*    $MyNoteBook.Views.Dialogs.AddMemoView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��450��5      $	��280��6+   .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   ��  �� Padding$ 20,10q�6   $��添加备忘录��6$   $
��Bold"�61   $��20(�6C   6S   ]� 5   
   $��1��6   $��False��6!   .+�5      �� $
��20,0q�63   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入备忘概要��6A   $	��Top=�6^   ��6   �� *Model.Title+6u   �� 5      $
��20,0q�66   $	��100��6D    �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�5      $ 请输入备忘内容��5      $	��Top=�63   ��5      �� *Model.Content+5   J   5      �� 5   
   $��10q�6    �� Orientation$ 
Horizontal=�6!   $��2��6:   $��Right=�6G   .+�5      �� $��取消��68   $��0,0,10,0q�6E       MaterialDesignOutlinedButton#��[  6W   ��6   �� *CancelCommand+6�   �� 5      $��确定��65   ��6   �� *SaveCommand+6E   5       5!      5"      