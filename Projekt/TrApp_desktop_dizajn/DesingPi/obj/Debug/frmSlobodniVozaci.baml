   M S B A M L   `   `   `  ����C  ?DesingPi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DesingPiDesingPi  5   �       DesingPi.SlobodniVozaci   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   (localclr-namespace:DesingPi     6�   -   5          � Title$  Slobodni vozači��5   	   $	��363��6!   $��542.597��6.    � 	Resources 5         t25_DBEntitiesViewSource ' #t25_DBEntitieszaposleniciViewSource �� Source �� Source��%\   &	        &	      7   �� 5   
   6   �� 5   
    6K   �� *zaposlenici+8   5	      .��5
      �  � DataContext# [ 6   $��0,0,2,0q�6N   .+�5   
   �� $��Pregled slobodnih vozača��6   $
��Left=�63   $��	10,10,0,0q�6N   $	��Top=�6a   $��18(�6y   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ zaposleniciDataGrid3��5         AutoGenerateColumns .     EnableRowVirtualization . $��
43,125,0,0q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $
��Left=�6�   $��455.91��6�   $	��140��6�   $	��Top=�6�   ��6l   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        id_zaposleniciColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 #��5   f      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *id_zaposlenici+6q     5      -   5        prezimeColumn��$
 Prezime��5   X   $ SizeToHeader 6i    6<   �� *	prezime+6i     5      -   5        	imeColumn��$	
 Ime��5   P   $ SizeToHeader 6]    68   �� *ime+6]     5      -   5        telefonColumn��$
 Telefon��5   X   $ SizeToHeader 6i    6<   �� *	telefon+6i   4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        datum_zaposlenjaColumn��$
 Datum zaposlenja��5   I   $ SizeToHeader 6c      CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� *datum_zaposlenja+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5      5      5      �� 5   
   $
��Left=�6   $��	43,59,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   �� 6o    � Language$ hr-hr�6s   $�Odabran vozač:��6�   6�   �� 5   
   -   5        $��txtID��5      $
��Left=�6   $��24��6:   $��
139,51,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $��37��6�   $��0,0,0,2q�6�    J� RenderTransformOrigin$ 0.085,0.625&�6�   $��14(�6#  ��6�   ��  �� ElementName$ zaposleniciDataGrid3�� �� Path$! SelectedItem.id_zaposlenici�6#  �� 5   
   -	   5        $��Odaberi��5      $
��Left=�6#   $��
43,285,0,0q�6>   $	��Top=�6R   $��82.083��6j     DizajnGumba2#���  6�   
�������6�   5      5      