   M S B A M L   `   `   `  ����G  CSmiteOverlay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SmiteOverlaySmiteOverlay  5   	       SmiteOverlay.ProfilePage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SmiteOverlay     5   	   -   5          � AllowsTransparency  .  � WindowStyle$
 None=�5   #    � Title$ 
MainWindow��5	   	   $��265.292��6   $��312.877��6-    J� Opacity$
 0.99Q�6=    � ShowInTaskbar .  � Topmost . ��5      �� 5   
    �� Opacity$	 0.2Q�6    �� Color$ Black��6(   .��5      �  � Cursor$ Arrow��6   	 � RowDefinitions	 5   
   �� 5      .+�5   
   �� -   5        
 ��Name$
 UsernameValue_Label��5      $��22��61   $��
10,10,95,0q�6=   $
��Wrap=�6Q   $	��Top=�6e    �� 
LineHeight$ 7��6}    J� RenderTransformOrigin$ 0.502,0.527&�6�   
�������$ Arrow��6�   $��Username��6�   $��16(�6�   �� 5   
   -   5         ��Name$ TotalWins_Label��5      $��Total Wins:��6)   $��33��6?   $��58,76,167,0q�6K   $	��Top=�6`   $��Center=�6x   
�������$��88��6�   $ Arrow��6�   �� 5   
   -   5        $ TotalLosses_Label��5      $��Total Losses:��6+   $��33��6C   $��58,93,154,0q�6O   $	��Top=�6d   $��Center=�6|   
�������$	��101��6�   $ Arrow��6�   �� 5   
   -   5        $ WinRatio_Label��5      $��
Win Ratio:��6(   $��33��6=   $��60,111,170,0q�6I   $	��Top=�6_   $��Center=�6w   
�������$��83��6�   $ Arrow��6�   �� 5   
   -   5        $ TotalWinsValue_Label��5      $
��Wins��6.   $��33��6=   $��161,76,72,0q�6I   $	��Top=�6^   
�������$ Arrow��6�   �� 5   
   -   5        $ TotalLossesValue_Label��5      $��Losses��60   $��33��6A   $��161,93,72,0q�6M   $	��Top=�6b   
�������$ Arrow��6�   �� 5   
   -   5        $ WinRatioValue_Label��5      $��Ratio��6-   $��33��6=   $��161,111,72,0q�6I   $	��Top=�6_   
�������$ Arrow��6�   �� 5   
   -	   5         ��Name$ 
Avatar_Img��5      $
��Left=�6$   $��65��6?   $��
235,10,0,0q�6K   $	��Top=�6_   $��68��6w   �� 5   
   -
   5        $
 UserMessageValue_Label��5      $��22��64   $��
10,28,95,0q�6@   $
��Wrap=�6T   $	��Top=�6h   $ 7��6�   $ 0.502,0.527&�6�   
�������$ Arrow��6�   $��Message��6�   �� 5   
   -   5        $ HoursPlayed_Label��5      $��Hours Played:��6+   $��33��6C   $��60,129,167,0q�6O   $	��Top=�6e   $��Center=�6}   
�������$��86��6�   $ Arrow��6�   �� 5   
   -   5        $ HoursPlayedValue_Label��5      $��Hours��60   $��33��6@   $��161,129,72,0q�6L   $	��Top=�6b   
�������$ Arrow��6�   �� 5   
   -   5        $ MasteryLevels_Label��5      $��Mastery Levels:��6-   $��33��6G   $��60,147,157,0q�6S   $	��Top=�6i   $��Center=�6�   
�������$��96��6�   $ Arrow��6�   �� 5   
   -   5        $ MasteryLevelsValue_Label��5      $��Mastery��62   $��33��6D   $��161,147,72,0q�6P   $	��Top=�6f   
�������$ Arrow��6�   �� 5   
   -   5         ��Name$ BackToMain_Button��5      $
��Back��6,   $
��Left=�6;   $��	5,241,0,0q�6V   $	��Top=�6i   $��52��6�   ���	#FF292525
�������$ Arrow��6�   �� 5    
   -   5        $ StartMatch_Button��5       $��In Game?��6,   $
��Left=�6?   $��
91,207,0,0q�6Z   $	��Top=�6n   $	��126��6�   ���	#FF292525
�������$��28��6�   $ Arrow��6�   �� 5!   
   -   5        $ InGameInfo_Label��5!      $��Press When In Game��6*   $��22��6G   $��101,180,105,0q�6S   $	��Top=�6j   $��Center=�6�   
�������$	��107��6�   $ Arrow��6�   $��10(�6�   $
��Bold"�6�   5$      5%      