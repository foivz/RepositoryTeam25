   M S B A M L   `   `   `  ����   DesingPi#    DesingPi.frmIspisRegistracija   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$   Ispis dnevnih registracija��$	��314��$	��743��.��� .+�&   System.Windows.Controls.DataGrid  -   $��registracijadatagrid2��   
IsReadOnly . $
��Left=�$��	35,78,0,0q�$	��Top=�$	��116��$	��649��   AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   id_tehnickog_pregleda5��,  &System.Windows.Controls.DataGridColumn   Header$ #��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *id_tehnickog_pregleda+  -   sljedeca_registracija5��$ Datum��   SortDirection$ 
DescendingX� �� *sljedeca_registracija+  -   
id_vozilo5��$ 	Id vozila�� �� *	id_vozilo+  -   vrsta_vozila_id5��$ Vrsta vozila�� �� *vrsta_vozila_id+  -   registracija5��$ Registracija�� �� *registracija+  -   
naziv5��$ Naziv�� �� *naziv+  -	   napomena��$ Napomena�� �� *
napomena+�� $	��ID:��$��0��$��Right=�$��0,21,660.412,227q�$��0��$��Center=�$��20(�$
��Bold"�$��35���� -
    ��Name$ id_tehnickog_pregleda��$
��Left=�$��30��$��74.588,21,0,232q�$��0��$��Center=�$��68��{�.  $��24(�$
��Bold"�$��0,0,0,2q�����  �� ElementName$ registracijadatagrid2��	 �� Path$(	 "SelectedItem.id_tehnickog_pregleda��� -   $��Odaberi��$
��Left=�$��35,220.571,0,0q�$	��Top=�$��82.821��   DizajnGumba2#���   
��������� -   $ id_voziloTextBox3��$
��Left=�$��23��$��
541,21,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��120��$y�Hidden=����� $ registracijadatagrid2��$	 SelectedItem.id_vozilo�