   M S B A M L   `   `   `  ����  WpfApplication1     WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Client Socket��5   	   $	��553��6   $	��357��6,    � Icon$ icon (2).ico��68   .��5      � ���	#FFD7CBFD.+�5   
   �� -   5         ��Name$ tbMsg��5      $
��Left=�6!   $	��124��6<   $��	60,83,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $:��4This message will be send to the server side socket.��6p   $	��Top=�6�   $	��222��6�   $��3q�6�   �� 5   
   -   5        $��Connect_Button��5      $��Connect to server��6'   $
��Left=�6C   $��	60,23,0,0q�6^   $	��Top=�6q   $	��120��6�   
���   �
�������6�   �� 5   
   -   5         ��Name$ tbStatus��5      $
��Left=�6&   $��
209,10,0,0q�6A   $
��Wrap=�6U   $��Not connected��6i   $	��Top=�6~   $	��132��6�   $��73��6�   �� 5	   
   -   5        $��Send_Button��5	      $��Send message��6$   $
��Left=�6;   $��
60,212,0,0q�6V   $	��Top=�6j   $	��120��6�   ���	#FFF9F9F9
���   �6�   �� 5
   
   -   5         ��Name$ Disconnect_Button��5
      $��
Disconnect��6,   $
��Left=�6A   $��
60,462,0,0q�6\   $	��Top=�6p   $	��120��6�   ���	#FFF9F9F9
���   �6�   �� 5   
   -   5        $ tbReceivedMsg��5      {�.  $
��Left=�6;   $	��124��6V   $��
60,287,0,0q�6c   $
 Wrap=�6w   $	��Top=�6�   $	��222��6�   $��3q�6�   �� 5   
   $
��Left=�6   $��	60,62,0,0q�6/   $
��Wrap=�6B   $��Message to send to server��6V   $	��Top=�6w   $	��144��6�   �� 5   
   $
��Left=�6   $��
60,266,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $	��167��6o   $��16��6{   �� 6�   $$�Message to receive from server��6�   �� 6�   �� 6�   6�   5      5      