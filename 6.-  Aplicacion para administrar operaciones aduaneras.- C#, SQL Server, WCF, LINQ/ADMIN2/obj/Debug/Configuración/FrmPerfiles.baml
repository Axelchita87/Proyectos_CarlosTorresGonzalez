   M S B A M L   `   `   `  ����J  FADMIN2.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:ADMIN2.Controls;assembly=ADMIN2.ControlsADMIN2.Controls  5   	   q mSystem.Windows.Controls.Layout.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35qUclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Layout.ToolkitSystem.Windows.Controls 5   	   
 ADMIN2'   !ADMIN2.Configuración.FrmPerfiles   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jcontrol6clr-namespace:ADMIN2.Controls;assembly=ADMIN2.Controls     5   	   dmyUclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Layout.Toolkit     5   	   -   5          � Title$  Permisos��5   	   $��354.5��6   $��667.662��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   $��2q�62   ���#D0A82D���	#FFd6d6d6.��5      � $��0,0,0,5q�6   .+�5	   
   �� $��28��6   $	��Top=�6    $��2��68   ��5
      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF7C4D09��6#    � Offset$ 0.464Q�65   � 5      $ 	#FFA87C05��6#   $ 0.916Q�65   � 5      $ 	#FF7E4F08��6#   $ 0.284Q�65   5      5      �� 5   
      labe_cabecera#���   6   $��Permisos��68   $��	10,0,42,0q�6K   $��2��6^   �� 5   
   -   5        $��	btnCerrar��5        close_boton#���  69   $��	635,5,0,0q�6_   $
��Left=�6r   $	��Top=�6�    �� IsCancel . 6�   �� 5   
   $�� ��6   ���#D0A82D$��2q�63   $��	6,30,0,37q�6G   $
��Left=�6Z   $	��653��6u   .��5      �� $��0,0,-2,0q�6   .+�5      � $	��281��6    � ColumnDefinitions 5      �� 5      $	��44* �6+   	 � RowDefinitions	 5      .+�5      �� -   5        
 ��Name$

 lblr��5   `   $
��Auto��5       $
��Auto��6.   $
��Left=�6;   $	��Top=�6V     estilo_labels#���  5      $��0,6,0,0q�65   $��Nombre del Perfil:��6F   $��2��6n   $y�Hidden=�5       �� 5      -   5         ��Name$ 	TxtPerfil��5      $��	109,0,0,0q�61   $y�Hidden=�6D   $
��Left=�5       $	��Top=�6(     TextBoxBaseControlTemplate#��[ 5!      
 � Tag$ Perfil��6D   $	��285��5"      $��22��6    �� 	MaxLength$ 30��6%   64   �� 5#      $
��Wrap=�6    $��0��64   $	��Top=�5$       �� TextAlignment$ Justify=�5%      #���  5&      $��0,4,0,0q�5'      $
��Left=�5(      $	��133��5)      $��Seleccione Módulos:��5*      $��16��61   R� 5+      -   5         R�Name$ TreeSita��5+      $
��Left=�61   $	��223��6L   $��0,25,0,0q�6Y   $	��Top=�6k   $	��216��6�   ���	#FFF0F1F76�   &   System.Windows.Controls.DataGrid  5,      -   5          Name$ dgrPermisos��5,      $
��Left=�64   $��
221,25,0,0q�6O   $	��Top=�6c   $	��223��5-      $	��416��6,   !   EnableColumnVirtualization .    AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�5.   ;      CanUserDeleteRows .     CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�5/   7      FrozenColumnCount$ 2��6\   ��5-   8   �� *	EntPerfil+   Columns 51      4  .System.Windows.Controls.DataGridCheckBoxColumn  52      -   5        chkCurrentchekLeer��,  &System.Windows.Controls.DataGridColumn   Header$ Solo lectura��52   Q      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6g   �� *ST_C_AP_LEER+6�     53      -   5        chkCurrentchekTotal��$ Control total��53   R    .  6i   �� *ST_C_AP_LEERYESCRIBIR+6�   0  *System.Windows.Controls.DataGridTextColumn  54      $ 
IdPantalla��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 49* 6e      
Visibility$ Hidden=�6q    6E   �� *IdPantallas+6q     55      $ Pantalla��61   $
 100* 6d    .  6C   �� *RutaPantalla+6q   58      �� 59      -	   5         ��Name$ chbxSeleccionaTodos��59      $��Todos��6<   $
��Left=�6L   $��	236,7,0,0q�6g   $	��Top=�6z   $y�Hidden=�6�   �� 5:      -
   5        $$ chbxSeleccionaTodosCotrolTotal��5:      $��Todos��6G   $
��Left=�6X   $��	306,7,0,0q�6s   $	��Top=�6�    J� RenderTransformOrigin$ -0.08,0.625&�6�   $y�Hidden=�6�   5;      5<      5=      �� 5>   
   -   5          ��Name$  btnCancelar��5>      $��25��6&   ! � Cursor$! Arrow��62   $��5��6A   $��Cancelar��5?   
   $��Right=�6   $	��Top=�69   $	��100��5@   
   $��
0,315,26,0q�6     btn_gen_naranja#���  6*   
���   �6T   �� 5A   
   -   5        $  
btnAceptar��5A      $��25��6%   $! Arrow��61   $��Aceptar��5B   
   $��Right=�6   $	��Top=�68   $��4��6P   $	��100��5C   
   $��0,315,143,0q�6   #���  6+   
���   �6U   5D      5E      