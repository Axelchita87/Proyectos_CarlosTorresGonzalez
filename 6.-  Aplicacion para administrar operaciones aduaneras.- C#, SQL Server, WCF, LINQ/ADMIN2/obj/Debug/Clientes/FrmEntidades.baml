   M S B A M L   `   `   `  ����J  FADMIN2.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:ADMIN2.Controls;assembly=ADMIN2.ControlsADMIN2.Controls  5   	   q mSystem.Windows.Controls.Layout.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35qUclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Layout.ToolkitSystem.Windows.Controls 5   	   
 ADMIN2"   ADMIN2.Clientes.FrmEntidades   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jcontrol6clr-namespace:ADMIN2.Controls;assembly=ADMIN2.Controls     5   	   dmyUclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Layout.Toolkit     5   	   -   5          � Title$   ��5      $��272.466��6   $��528.94��6!    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�6   $��2q�62   ���#D0A82D���	#FFd6d6d6.��5
      � $��0,0,0,5q�6   .+�5   
   �� $��28��6   $	��Top=�6    $��2��68   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF7C4D09��6#    � Offset$ 0.464Q�65   � 5      $ 	#FFA87C05��6#   $ 0.916Q�65   � 5      $ 	#FF7E4F08��6#   $ 0.284Q�65   5      5      �� 5   
      labe_cabecera#���   6   $��Búsqueda de Dirección��68   $��	10,0,42,0q�6X   $��2��6k   �� 5   
   -   5        $��	btnCerrar��5        close_boton#���  69   $��	499,5,0,0q�6_   $
��Left=�6r   $	��Top=�6�    �� IsCancel .  J� RenderTransformOrigin$ 
5.423,0.69&�6�   �� 5   
   $�� ��6   ���#D0A82D$��2q�63   $��	6,30,0,30q�6G   $
��Left=�6Z   $	��509��6u   .��5      �� $��0,0,-2,0q�6   .+�5      � -   5        	 �Name$	 GridBotones��5   $   $	��183��6   
 � ColumnDefinitions
 5      �� 5      $	��44* �6+   .+�5      �� -   5         ��Name$
 lblr��5   h   $
��Auto��5       $
��Auto��6.   $
��Left=�6;   $	��Top=�6V     estilo_labels#���  5      $��11,3,0,0q�6;   $��Entidad Federativa:��6M   6h   �� 5      -   5         ��Name$ 	TxtEstado��5      $��	125,3,0,0q�61   $��1��6E   $
��Left=�5      $	��Top=�6.     TextBoxBaseControlTemplate#��[ 5       $	��364��5!      $��22��6   �� 5"      -   5        $ lblsub��5#   ^   $
��Auto��5"       $��74��6.   $
��Left=�69   $	��Top=�6T   #���  5#      $��	11,69,0,0q�6;   $��Colonia:��6N   6^   �� 5%      -   5         ��Name$ 	BtnEstado��5%   E   $��16��6   $
��Left=�6*   $	��Top=�6X   $��16��6p     buscar2#���  6{   $��	468,5,0,0q�6�    � Cursor$
 Hand��5&       � ToolTip$3 -Clic para buscar en las Entidades Federarivas��6"   $ 29.451,0.877&�6m   �� 5'      -   5        $ lblsub_Copy��5(   `   $
��Auto��5'       $��74��6.   $
��Left=�69   $	��Top=�6T   #���  5(      $��	11,34,0,0q�6;   $��
Municipio:��6N   6`   $   ADMIN2.Controls.NumericTextBox  5)      -	   5          Name$ TxtCP��5)   -    �� 	MaxLength$ 4��6<   {�.  $
��Left=�5*       �� TextWrapping$
 Wrap=�6.   $	��Top=�6B   $��58��5+      $��125,101,0,0q�6   $��22��63   #��[ 5,   -   $��4��6d   �� 5-      -
   5        $ lblsub_Copy1��5.   e   $
��Auto��5-       $��93��6.   $
��Left=�69   $	��Top=�6T   #���  5.      $��
11,103,0,0q�6;   $��Código Postal:��6O   6e   �� 5/      -   5        $ 
TxtColonia��5/      $��
125,69,0,0q�62   $��3��6G   $
��Left=�50      $	��Top=�61   {�.  #��[ 51      $	��364��52      $��22��6"   �� 53      -   5        $ TxtMunicipio��53      $��
125,34,0,0q�64   $��2��6I   $
��Left=�54      $	��Top=�61   {�.  #��[ 55      $	��364��56      $��22��6"   �� 57      -   5        $ BtnMunicipio��57   E   $��16��6   $
��Left=�6*   $	��Top=�6[   $��16��6s   #���  6~   $��
468,37,0,0q�6�   $
 Hand��58      $( "Clic para buscar en los Municipios��6%   $ 
0.51,0.127&�6R   6u   �� 59      -   5        $ 
BtnColinia��59   E   $��16��6   $
��Left=�6*   $	��Top=�6Y   $��16��6q   #���  6|   $��
468,72,0,0q�6�   $
 Hand��5:      $&  Clic para buscar en las Colonias��6%   $ 
0.51,0.127&�6P   6s   �� 5;      -   5         ��Name$ 	ChbAplica��5;      $��Iguala��62   $
��Left=�6D   $	��Top=�6_     CheckBoxStyle#���  6w   $ 
0.749,0.51&�6�   $��4��5<      $��28��6#   $��125,138,0,0q�6.   �� 5=      -   5        $ 	LblAplica��5>   �   $��54��5=       $��94��6,   $
��Left=�67   $	��Top=�6R   $
��Wrap=�6j   #���  5>      $��
10,129,0,0q�6>   $4��.Aplicar misma dirección para datos de envió:��6R   6�   5@      5A      5B      � 5C   
   -   5        $	 GridBotones2��5C      $
��Left=�6%   $��45��6@   $��10,227,0,-9q�6L   $	��Top=�6a   $	��505��6y   
 5D      �� 5E      $
��203* �6#   �� 5F      $	��11* �6#   �� 5G      $��8* �6#   .+�5I      �� -   5        $ 
btnAceptar��5I      $��25��6)   $ Arrow��65   $��Aceptar��5J      $��Right=�6   $	��Top=�69   $��4��6Q   $	��100��5K      $��	0,10,88,0q�6     btn_gen_naranja#���  6*   
���   �$ 	0.97,0.32&�6g   �� 5L      -   5        $ btnCancelar��5L      $��25��6*   $ Arrow��66   $��5��6E   $��Cancelar��5M      $��Right=�6!   $	��Top=�6=   $	��100��5N      #���  6   
���   �$��2��6W   $��0,10,0,0q�6k   5O      5P      5Q      