   M S B A M L   `   `   `  ���� U  QPracenjeVozila, Version=1.0.0.0, Culture=neutral, PublicKeyToken=86b0ccbb7ac043b5G4clr-namespace:PracenjeVozila;assembly=PracenjeVozilaPracenjeVozila  C ?DesingPi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DesingPiDesingPi    DesingPi.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Dmcl4clr-namespace:PracenjeVozila;assembly=PracenjeVozila     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:DesingPi     -     � Title$  TrApp - Transport��$	��768��$
��1062��$��0q� � 	Resources    t25_DBEntitiesViewSource " t25_DBEntitiesvoziloViewSource �� Source �� Source ' #t25_DBEntitieszaposleniciViewSource * &t25_DBEntitiesPutniRadniListViewSource & "t25_DBEntitiesradni_satiViewSource  putniRadniListViewSource  godisnji_odmorViewSource  tehnicki_pregledViewSource  servisViewSource��%  &	        &	      7   &	 #     7   &	 F     7   &	 l     7   &	 �     &	 �     &	 �     &	 �     �� ��  �� *vozilo+8   ��  �� *zaposlenici+8   ��  �� *PutniRadniList+8   ��  �� *
radni_sati+8   �� �� �� �� .��� .+�� $��0��$��0��
�������$
��Left=�$
��1016�� � ShowGridLines . .+�o�  o� 
IsMainMenu . $��	10,13,0,0q�$��14(�$��25��$	��Top=�$
��Left=�$
��1024����Z� .@�m� $��_Vozila��.@�m� -   $��_Popis vozila��m� -   $��_Registracije��m� -   $��_Servisi��m� -   $��_Tehnički pregledi��m� $��_Vozači��.@�m� -   $��_Popis vozača��m� -   $��_Godišnji odmori��m� -   $��_Obračun radnih sati��m� $��_Transportni podaci��.@�m� -	   $��_Unos Putnog radnog lista��m� -
   $��_Unos zaposlenika��m� -   $��_Unos vozila��m� $��_Pomoć��.@�m� -   $��_Dokumentacija���� -    ��Name$ 	tabGlavni�� �� TabStripPlacement$
 Left=�$
��Left=�$	��673��$	��Top=�$
��1016��$��0,55,0,0q�
�������.@��� $��-2,30.963,-3.667,-30.963q�
�������
������� 	 DizajnVecegTaba#��� 	 $��0q�����  �� Orientation$ 
Horizontal=�$	��200��$��70��.+��� $��Center=�$��Segoe WP Semibold)�$��15(�$��SemiBold"�$��Stretch=��� $�Administracija vozila��.��� 
�������$��
0,-2,-21,0q�.+��� -   $ 	tabVozila��$	��689��$��Bottom=�$
��Left=�$	��806��$��	0,0,0,-18q����	#FF0C95F0$��0,1,1,1q�.@��� -   $��32��$	��Top=�
�������$��0q� 
 
DizajnTaba#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Center=�	 �� TextAlignment$	 Center=�$��Popis vozila��.��� 
 � DataContext#
 [ .+�&   System.Windows.Controls.DataGrid  -     Name$ voziloDataGrid��   RowDetailsVisibilityMode$ VisibleWhenSelected=�$��28,71,95,282q�   EnableRowVirtualization .    AutoGenerateColumns .     
IsReadOnly . ���	#FF0C95F0
���   �����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   id_voziloColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader    Header$ #��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	id_vozilo+  -   registracijaColumn��$ SizeToHeader $ Registracija��   
Foreground
 ��  � �� *registracija+  -   nazivColumn��$ SizeToHeader $ Naziv�� �� *naziv+  -   vrsta_vozila_idColumn��$ SizeToHeader $ Vrsta vozila�� �� *vrsta_vozila_id+  -   godina_proizvodnjeColumn��$ SizeToHeader $ Godina proizvodnje�� �� *godina_proizvodnje+4  .System.Windows.Controls.DataGridTemplateColumn  -   datum_registracijeColumn��$ SizeToHeader $ Datum registracije��   CellTemplate �� .R�(  "System.Windows.Controls.DatePicker     SelectedDate �� *datum_registracije+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions .   -   nosivostColumn��$ SizeToHeader $ Nosivost�� �� *
nosivost+  -   servisni_intervalColumn��$ SizeToHeader $ Servisni interval�� �� *servisni_interval+  -   pocetno_stanje_kmColumn��$ SizeToHeader $ Početno stanje km�� �� *pocetno_stanje_km+�� -    ��Name$ cmbOdabirVozila��$
��Left=�$��	28,21,0,0q�$	��Top=�$	��134�� �� SelectedIndex$ 0��.@��� -   $��
Sva vozila��$
��Left=�$	��132���� -   $��Slobodna vozila��$
��Left=�$	��132���� $��32��$��Bottom=�
�������$��10.5,0,-31,0q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Stretch=��� $�Nadolazeće registracije��.��� .+�  -   $ registracijadatagrid�� . $
��Left=�$��28,60.5,0,0q�$	��Top=�$��226.5��$	��716�� .  ���	#FF0C95F0����    -   sljedeca_registracija��$ 
Vrijedi do��   SortDirection$ 
DescendingX� �� *sljedeca_registracija+  -   
id_vozilo1��$ 	Id vozila�� �� *	id_vozilo+  -    vrsta_vozila_id1��$ Vrsta vozila�� �� *vrsta_vozila_id+  -!   registracija1��$ Registracija�� �� *registracija+  -"   
naziv1��$ Naziv�� �� *naziv+  -#   napomena��$ Napomena�� �� *
napomena+�� -$   $ cmbReg��$ 0��$
��Left=�$��	28,21,0,0q�$	��Top=�$	��134��.@��� -%   $��Tjedni prikaz��$
��Left=�$	��118���� -&   $��Mjesečni prikaz��$
��Left=�$	��118���� -'   $��Cjelokupni prikaz��$
��Left=�$	��118���� $	��ID:��$��0��$��Right=�$��0,305,703,307q�$��0��$��Center=�$��20(�$
��Bold"� J� RenderTransformOrigin$ 0.541,-0.324&�
���   ��� -(    ��Name$ id_voziloTextBox3��$
��Left=�$��30��$��100.678,309.669,0,309.331q�$��0��$��Center=�$��68��{�.  $��24(�$
��Bold"�$��0,0,0,2q����	#FF555555���� *SelectedItem.id_vozilo+ �� ElementName$ registracijadatagrid���� $��Naziv:��$��0��$
��Left=�$��232.5,314.94,0,309.66q�$��0��$��Center=�$
��Lato)��� -)   $ nazivTextBox3��$
��Left=�$��26��$��277.5,314.14,0,308.86q�$��0��$��Center=�$	��180�����	#FF777777���� *SelectedItem.naziv+$ registracijadatagrid���� $��Vrsta vozila:��$��0��$
��Left=�$��488,314,0,309.04q�$��0��$��Center=�$
��Lato)��� $��Registracija:��$��0��$
��Left=�$��199.5,361.165,0,261.874q�$��0��$��Center=�$
��Lato)��� -*   $ registracijaTextBox3��$
��Left=�$��24��$��277.5,362,0,262.52q�$��0��$��Center=�$	��180�����	#FF777777���� *SelectedItem.registracija+$ registracijadatagrid��� -+     �Name$  grid41��#
 [ $
��Left=�$��488,358.185,0,0q�$	��Top=�$	��256��! � ColumnDefinitions! �� $
��Auto ��� $
��Auto �" � RowDefinitions" �� $
��Auto �.+��� $��Datum registracije:��$��0��$
��Left=�$��0,3.78q�$��0��$��Center=�$��115.43��$
��Lato)�$��2��  -,   #  Name$# datumDatePicker��$��1��$
��Left=�$ ��114.943,3.98,-139.109,3.98q�$��0��$��Center=�$��139.109�����	#FF777777 �� *	pocetak+$ TwoWay=� .  . $   Text$ �� *$"SelectedItem.sljedeca_registracija+$ registracijadatagrid���� $��	Napomena:��$
��Left=�$��60,386.665,0,0q�$	��Top=�$
��Lato)��� --   $ txtNapomena��$
��Left=�$��78.667��$��65.499,412.625,0,0q�% �� TextWrapping$
% Wrap=�$	��Top=�$��392.001�����	#FF777777���� *SelectedItem.napomena+$ registracijadatagrid���� -.   & ��Name$& btnPosaljiNaRegistraciju��$��Pošalji��$
��Left=�$��510.999,416.433,0,0q�$	��Top=�$��80��$��23��  DizajnGumba#���  
�������$
��Lato)��� -/   $& btnIspisRegistracija��$��Ispis��$
��Left=�$��655.333,416.433,0,0q�$	��Top=�$��75��$��30.96��  	GumbIspis#���  ���	#FF0C95F0�� -0   $& btnObrisiRegistraciju��$��Obriši��$
��Left=�$��510.999,464.292,0,0q�$	��Top=�$��80��$��23��#���  
��������� -1   $ txtIdTehnickog��$
��Left=�$��23��$��
669,10,0,0q�$
% Wrap=�$	��Top=�$	��120��$y�Hidden=��� -2   $ cmbVrstaVozilaReg��$
��Left=�$��610,314,0,0q�$	��Top=�$	��120���� -3   $��32��$��Bottom=�
�������$��39.5,0,-51,0q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Stretch=��� $�Nadolazeći servisi��.��� .+�  -4   $ vozilaservisdatagrid��$
��Left=�$��	30,38,0,0q�$	��Top=�$	��248��$	��700�� .  ����    -5   	id_vozilo��$ #�� �� *	id_vozilo+  -6   registracija��$ Registracija�� �� *registracija+  -7   	naziv��$ Naziv�� �� *naziv+  -8   servisni_interval��$ Servisni interval�� �� *servisni_interval+  -9   pocetno_stanje_km��$ Početna kilometraža�� �� *pocetno_stanje_km+  -:   stanje_na_zadnjem_servisu��$ Stanje na zadnjem servisu�� �� *stanje_na_zadnjem_servisu+  -;   trenutno_stanje_km��$ Trenutno stanje�� �� *trenutno_stanje_km+  -<   
razlika_km��$ 
Razlika km�� �� *
razlika_km+  -=   	datum��$ Datum�� �� *datum_servisa+�� $	��ID:��$��0��$��Right=�$��0,309.18,733,303.22q�$��0��$��Center=�$��20(�$
��Bold"�$ 0.541,-0.324&��� ->   $ id_voziloTextBox4��$
��Left=�$��30��$��72,315.98,0,303.02q�$��0��$��Center=�$��68��{�.  $��24(�$
��Bold"�$��0,0,0,2q����	#FF777777���� *SelectedItem.id_vozilo+$ vozilaservisdatagrid���� $��Naziv:��$��0��$
��Left=�$��162.306,321.98,0,301.06q�$��0��$��Center=��� -?   $ nazivTextBox4��$
��Left=�$��26��$��209.307,321.96,0,301.04q�$��0��$��Center=�$��142.693�����	#FF777777���� *SelectedItem.naziv+$ vozilaservisdatagrid���� $��Razlika km:��$��0��$
��Left=�$��477,459.02,0,164.02q�$��0��$��Center=��� -@   $ id_vrsta_vozilaTextBox4��$
��Left=�$��26��$��550,459,0,164q�$��0��$��Center=�$	��180�����	#FF777777���� *SelectedItem.razlika_km+$ vozilaservisdatagrid���� $��Registracija:��$��0��$
��Left=�$��374.07,321.02,0,302.02q�$��0��$��Center=�$��73.93���� -A   $ registracijaTextBox4��$
��Left=�$��24��$��453,321.98,0,303.02q�$��0��$��Center=�$	��150�����	#FF777777���� *SelectedItem.registracija+$ vozilaservisdatagrid���� $��Servisni interval:��$
��Left=�$��
72,367,0,0q�$	��Top=�$��99.527���� -B   $ txtServisniInterval��$
��Left=�$��23��$��172,368,0,0q�$
% Wrap=�$	��Top=�$	��180�����	#FF777777���� * SelectedItem.servisni_interval+$ vozilaservisdatagrid���� $#��Stanje km na zadnjem servisu:��$
��Left=�$��377,368,0,0q�$	��Top=�$	��168���� -C   $ txtStanjeNaZadnjemServisu��$
��Left=�$��23��$��550,368,0,0q�$
% Wrap=�$	��Top=�$	��180�����	#FF777777���� *(&SelectedItem.stanje_na_zadnjem_servisu+$ vozilaservisdatagrid���� $��Trenutno stanje km:��$
��Left=�$��427,411.04,0,0q�$	��Top=�$	��118���� -D   $ txtTrenutnoStanje��$
��Left=�$��23��$��550,414.04,0,0q�$
% Wrap=�$	��Top=�$	��180�����	#FF777777���� *!SelectedItem.trenutno_stanje_km+$ vozilaservisdatagrid���� -E   $& btnPosaljiNaServis��$��Pošalji��$
��Left=�$��649,509,0,0q�$	��Top=�$��81��$��23��#���  
�������� -F   $  grid42��#
 [ $
��Left=�$��
30,496,0,0q�$	��Top=�$��67��$	��338��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Opis:��$��1��$
��Left=�$��46,-95.98,-9,104.136q�$��0��$��Center=�$��42.775��$��27.844���� -G   $ opisTextBox��$
��Left=�$��106.187��$��46,-69.187,-297.225,-1q�$��0��$��Center=�$	��331��$��1�����	#FF777777���� *opis+$ TwoWay=� .  . � -H   $  grid43��#
 [ $
��Left=�$��619.36,299.98,0,0q�$	��Top=�$��49��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Datum:��$��0��$
��Left=�$��3,-2,0,8q�$��0��$��Center=�  -I   $# datumDatePicker1��$
��Left=�$��9,21.96,0,-14q�$��0��$��Center=�$��2��$ �� *SelectedItem.datum_servisa+$ vozilaservisdatagrid�� �� *datum+$ TwoWay=� .  . �� -J   $& btnIspisServisa��$��Ispis��$
��Left=�$��437,501.123,0,0q�$	��Top=�$��75��#���  �� -K   $ txtIdServisa��$
��Left=�$��23��$��
619,10,0,0q�$
% Wrap=�$	��Top=�$	��120��$y�Hidden=��� -L   $& btnObrišiServis��$��Obriši��$
��Left=�$��539,509,0,0q�$	��Top=�$��75��#���  
��������� $��-2,30,-4.5,-31.333q�
�������
�������  DizajnVecegTaba2#���  ���� $ 
Horizontal=�$	��200��$��70��.+��� $��Center=�$��Segoe WP Semibold)�$��15(�$��SemiBold"�$��Stretch=��� $�Administracija vozača��.��� 
�������$��
0,-2,-34,0q�.+��� -M   $ 	tabVozaci��$	��684��$��Bottom=�$
��Left=�$	��806��$��	0,0,0,-13q����	#FF0C95F0$��0,1,1,1q�.@��� -N   $��32��$	��Top=�
�������$��0q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Center=�$	 Center=�$��Popis vozača��.��� #
 [ .+�  -O   $ zaposleniciDataGrid�� .   . $��28,71,29,242q�$ VisibleWhenSelected=� . ����    -P   id_zaposleniciColumn��$ #��$ SizeToHeader  �� *id_zaposlenici+  -Q   prezimeColumn��$ Prezime��$ 70  �� *	prezime+  -R   	imeColumn��$	 Ime��$ 70  �� *ime+  -S   adresaColumn��$ Adresa��$	 130  �� *adresa+  -T   	oibColumn��$	 OIB��$	 100  �� *oib+  -U   
iBANColumn��$
 IBAN��$	 100  �� *IBAN+  -V   korisnicko_imeColumn��$ Korisnicko ime��$ SizeToHeader  �� *korisnicko_ime+  -W   telefonColumn��$ Telefon��$ SizeToHeader  �� *	telefon+  -X   datum_rodjenjaColumn��$ Datum rođenja��$ SizeToHeader  �� .R�   �� *datum_rodjenja+$ TwoWay=� .  .   -Y   datum_zaposlenjaColumn��$ Datum zaposlenja��$ SizeToHeader  �� .R�   �� *datum_zaposlenja+$ TwoWay=� .  . �� -Z   $ cmbOdabirVozaca��$
��Left=�$��	28,21,0,0q�$	��Top=�$	��134��$ 0��.@��� -[   $��Svi vozači��$
��Left=�$	��132���� -\   $��Slobodni vozači��$
��Left=�$	��132���� $��32��$��Bottom=�
�������$��10.333,0,-18.5,0q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Stretch=��� $"�Planiranje godišnjih odmora��.��� .+�  -]   $ datagridGodisnjiOdmor�� . $
��Left=�$��38,281.96,0,0q�$	��Top=�$��237.519��$	��694�� .  ����    -^   id_godisnjeg_odmora��$ #�� �� *id_godisnjeg_odmora+  -_   pocetak_godisnjeg��$ Početak��$ 
DescendingX� �� *pocetak_godisnjeg+  -`   kraj_godisnjeg��$
 Kraj�� �� *kraj_godisnjeg+  -a   id_zaposlenici��$ Id zaposlenika�� �� *id_zaposlenici+  -b   prezime��$ Prezime�� �� *	prezime+  -c   ime��$	 Ime�� �� *ime+  -d   telefon��$ Telefon�� �� *	telefon+  -e   
adresa��$ Adresa�� �� *adresa+�� -f   $ cmbOdmor��$ 0��$
��Left=�$��
44,230,0,0q�$	��Top=�$	��135��.@��� -g   $��Danas��$
��Left=�$	��118���� -h   $��Ovaj tjedan��$
��Left=�$	��118���� -i   $��Ovaj mjesec��$
��Left=�$	��118��(� $
��Left=�$��236.481��$��461,26.479,0,0q�$	��Top=�$	��297��.��&   System.Windows.Controls.Calendar  -j   '  Name$' calGodisnji��$��165.333��$��199.907������ ( �� EndPoint$( 0.5,1&�) �� 
StartPoint$) 0.5,0&�.��� * � Color$* 	#FFA3AEB9��+ � Offset$+ 0Q�� $* 	#FF8399A9��$+ 0.375Q�� $* 	#FF3679AC��$+ 1Q�� -k   $  grid35��#
 [ $
��Left=�$��	65,30,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $	��ID:��$��0��$
��Left=�$��-32.504,3.2,0,3.2q�$��0��$��Center=�$��20(�$
��Bold"��� -l   $ id_godinjeg_odmoraTextBox��$
��Left=�$��40��$��10,0,0,3q�$��0��$��Center=�$��68��{�.  $��24(�$
��Bold"�$��0,0,0,2q�$��2������ *" SelectedItem.id_godisnjeg_odmora+$ datagridGodisnjiOdmor��� -m   $  grid36��#
 [ $
��Left=�$��
65,154,0,0q�$	��Top=�{�.  ! �� $
��Auto ��� $
��Auto �" �� $
��Auto �� -n   $  grid37��#
 [ $
��Left=�$��
44,159,0,0q�$	��Top=�$	��180��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��	Početak:��$��0��$
��Left=�$	��0,3q�$��0��$��Center=�$��57.307��  -o   $# pocetakDatePicker1��$��1��$
��Left=�$��3,3.98,-12,3.98q�$��0��$��Center=�$��106.64��$ �� * SelectedItem.pocetak_godisnjeg+$ datagridGodisnjiOdmor��� -p   $  grid38��#
 [ $
��Left=�$��
38,102,0,0q�$	��Top=�$��296.57��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Zaposlenik:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -q   $ cmbZaposleniciCombo��$
��Left=�$��
73,3,-92,0q�$	��Top=�$	��214��$��2���� -r   $& btnPosaljiGodisnji��$��Pošalji��$
��Left=�$��220,230,0,0q�$	��Top=�$��89��$��23��#���  
�������� -s   $  grid44��#
 [ $
��Left=�$��248,159,0,0q�$	��Top=�$	��159��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Kraj:��$��0��$
��Left=�$��3q�$��0��$��Center=�  -t   $# krajDatePicker1��$��1��$
��Left=�$��3,3.98,-12.613,3.98q�$��0��$��Center=�$��117.253��$ �� *SelectedItem.kraj_godisnjeg+$ datagridGodisnjiOdmor���� -u   $& btnObrisiGodisnjiOdmor��$��Obriši��$
��Left=�$��332,232,0,0q�$	��Top=�$��75���� $��32��$��Bottom=�
�������$��27.5,0,-41.5,0q�
�������#��� 
 ���� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Stretch=��� $$�Mjesečni obračun radnih sati����� .+��� $��Unesi cijenu satnice:��$
��Left=�$��	40,54,0,0q�$	��Top=��� -v   $ txtCijenaSatnice��$
��Left=�$��23��$��
159,57,0,0q�$
% Wrap=�$	��Top=�$	��120��  -w   $ satnicaDataGrid��$
��Left=�$��
40,164,0,0q�$	��Top=�$	��248��$	��700�� .  ����    -x   id_zaposleniciColumn5��$ #��$ SizeToHeader  �� *id_zaposlenici+  -y   prezimeColumn5��$ Prezime��$ 70  �� *	prezime+  -z   
imeColumn5��$	 Ime��$ 70  �� *ime+  -{   adresaColumn5��$ Adresa��$	 130  �� *adresa+  -|   iBANColumn5��$
 IBAN��$	 100  �� *IBAN+  -}   	zbrojSati��$ 
Zbroj sati��$ SizeToHeader  �� *	suma_sati+  -~   satnicaIzracunata��$ Izračunata satnica��$ SizeToHeader  �� *izracunataSatnica+�� -   $& btnIzračunajSatnicu��$��
Izračunaj��$
��Left=�$��159,116,0,0q�$	��Top=�$��75���� $"��-2.001,31.334,-1.999,-30.662q�
�������
�������#���  ���� $ 
Horizontal=�$	��200��$��70��.+��� $��Center=�$��Segoe WP Semibold)�$��15(�$��SemiBold"�$��Stretch=�$��0,25.025q��� $�Transportni podaci��.��� 
�������$��
0,-2,-34,0q�.+��� -�   $ tabTransportniPodaci��$	��682��$��Bottom=�$
��Left=�$��820.333��$��0,-2.168,0,-10.832q�$��0,1,1,1q����	#FF0C95F0$ 0.5,0.5&�.@��� $��32��$	��Top=�
�������$��0q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Center=�$	 Center=�$��Unos putnog radnog lista��.��� -�   $  proba��.+�� -�   $  grid23��#
 [ $
��Left=�$��	48,41,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $	��ID:��$��0��$
��Left=�$��-32.504,-4.8,0,11.2q�$��0��$��Center=�$��20(�$
��Bold"��� -�   $# id_putnog_radnog_listaTextBox��$
��Left=�$��40��$��
10,-8,0,11q�$��0��$��Center=�$��68��{�. $��24(�$
��Bold"�$��0,0,0,2q�, �� 
IsReadOnly, . $��2�����	#FF777777���� *id_putnog_radnog_lista+$ TwoWay=� .  . � -�   $  grid24��#
 [ $
��Left=�$��
41,127,0,0q�$	��Top=�$	��220��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Vozilo:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ voziloTextBox��$��1��$
��Left=�$��23��$��3,4.48,-21,4.48q�$��0��$��Center=�$	��160�����	#FF777777� -�   $  grid25��#
 [ $
��Left=�$��216.303,50.59,0,0q�$	��Top=�$��236.197��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Kreira:��$��0��$
��Left=�$��-4,4,0,2q�$��0��$��Center=��� -�   $ cmbPTRSlobodniZaposlenici��$��1��$
��Left=�$��
3,4,-191,0q�$	��Top=�$	��193��$��26��� -�   $  grid26��#
 [ $
��Left=�$��368.02,344,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Kilometraža:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ kilometrazaTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��160�����	#FF777777� -�   $  grid27��#
 [ $
��Left=�$��515,155,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �� -�   $  grid28��#
 [ $
��Left=�$��
85,247,0,0q�$	��Top=�$	��168��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �� -�   $  grid29��#
 [ $
��Left=�$��352,282,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Mjesto istovara:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ mjesto_istovaraTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��160�����	#FF777777���� *mjesto_istovara+$ TwoWay=� .  . � -�   $  grid30��#
 [ $
��Left=�$��353,237,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Mjesto utovara:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ mjesto_utovaraTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��160�����	#FF777777���� *mjesto_utovara+$ TwoWay=� .  . �� -�   $��Odaberi...
��$
��Left=�$��266,131.041,0,0q�$	��Top=�$��88��$��23��  DizajnGumba2#���  ���	#FF0C95F0
�������� -�   $  grid32��#
 [ $
��Left=�$��389,127,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��	Vozač 1:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ zaposlenikTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��160�����	#FF777777� -�   $  grid31��#
 [ $
��Left=�$��389,172,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��	Vozač 2:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ zaposlenikTextBox1��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��160�����	#FF777777�� -�   $& btnOdaberiVozaca1��$��
Odaberi...��$
��Left=�$��624,131.041,0,0q�$	��Top=�$��88��$��23��#���  
��������� -�   $& btnOdaberiVozaca2��$��
Odaberi...��$
��Left=�$��624.917,176.041,0,0q�$	��Top=�$��88��$��23��#���  
��������� -�   $& btnIspis��$��Ispis��$
��Left=�$��
636,51,0,0q�$	��Top=�$��75��$��33��#���  �� -�   $& 
btnPregled��$��Pregled��$
��Left=�$��515,53.874,0,0q�$	��Top=�$��81��$��23��#���  
��������� -�   $& btnSpremiPTR��$��Spremi��$��Right=�$��0,0,322,206q�$��Bottom=�$��80��$��23��#���  
��������� -�   $& btnIzmijeniPTR��$��Izmijeni��$��Right=�$��0,0,205,206q�$��Bottom=�$��80��$��23��#���  
�������� -�   $  grid33��#
 [ $
��Left=�$��44,284.05,0,0q�$	��Top=�$	��209��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Kraj:��$��0��$
��Left=�$��3q�$��0��$��Center=�  -�   $# krajDatePicker��$��1��$
��Left=�$��
10,4,-34,4q�$��0��$��Center=�$	��138�� �� *kraj+$ TwoWay=� .  . � -�   $  grid34��#
 [ $
��Left=�$��31,239.05,0,0q�$	��Top=�$	��222��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��	Početak:��$��0��$
��Left=�$��3q�$��0��$��Center=�  -�   $# pocetakDatePicker��$��1��$
��Left=�$��3,3.98,-32,3.98q�$��0��$��Center=�$��136.64�� �� *	pocetak+$ TwoWay=� .  . � -�   $  grid39��#
 [ $
��Left=�$��51,170.99,0,0q�$	��Top=�$	��210��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Teret:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ teretTextBox��$
��Left=�$��24��$��
43,4,-38,4q�$��0��$��Center=�$	��160��$��2�����	#FF777777���� *teret+$ TwoWay=� .  . � -�   $  grid40��#
 [ $
��Left=�$��31.98,333.917,0,0q�$	��Top=�$	��115��$��322.02��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��	Napomene:��$��1��$
��Left=�$��3,1,0,10q�$��0��$��Center=�$��78.447���� -�   $ napomeneTextBox��$��1��$
��Left=�$��78.02��$��3,26.96,-187.02,-68.02q�$��0��$��Center=�$��309.02�����	#FF777777���� *
napomene+$ TwoWay=� .  . �� -�   $& btnObrisiPTR��$��Obriši��$
��Left=�$��632,412.917,0,0q�$	��Top=�$��80��$��23��#���  
��������� -�   - ��Name$- 
tabVozila1��$��32.083��$��Bottom=�
�������$��13,0,-19.666,-0.083q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Stretch=��� $�Unos vozila��.��� #
 [ .+�� -�   $  grid1��#
 [ $
��Left=�$��	20,26,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $	��ID:��$��0��$��Right=�$��0,3,3,3q�$��0��$��Center=�$��20(�$
��Bold"��� -�   $ id_voziloTextBox��$��1��$
��Left=�$��30��$��0,5,0,8q�$��0��$��Center=�$��68��{�.  $��24(�$
��Bold"�$��0,0,0,2q����� *SelectedItem.id_vozilo+$ voziloDataGrid1��� -�   $  grid2��#
 [ $
��Left=�$��	30,89,0,0q�$	��Top=�! �� $��77.333 ��� $��1.667 ��� $
��Auto �" �� $
��Auto �.+��� $��Registracija:��$��0��$
��Left=�$��3,3,0,3q�$��0��$��Center=��� -�   $ registracijaTextBox��$��2��$
��Left=�$��24��$��3,4,0,4q�$��0��$��Center=�$	��150�����	#FF777777���� *SelectedItem.registracija+$ voziloDataGrid1��� -�   $  grid3��#
 [ $
��Left=�$��274.78,89,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Naziv:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ nazivTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��150�����	#FF777777���� *SelectedItem.naziv+$ voziloDataGrid1��� -�   $  grid4��#
 [ $
��Left=�$��493.573,89.04,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Godina proizvodnje:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ godina_proizvodnjeTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��120�����	#FF777777���� *!SelectedItem.godina_proizvodnje+$ voziloDataGrid1��� -�   $  grid5��#
 [ $
��Left=�$��379,209,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Početno stanje km:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -�   $ pocetno_stanje_kmTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��130�����	#FF777777���� * SelectedItem.pocetno_stanje_km+$ voziloDataGrid1��� -�   $  grid6��#
 [ $
��Left=�$��
39,209,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $ ��Datum zadnje registracije:��$��0��$
��Left=�$��3q�$��0��$��Center=�  -�   $"# datum_registracijeDatePicker��$��1��$
��Left=�$��3q�$��0��$��Center=�$	��120�� �� *!SelectedItem.datum_registracije+$ voziloDataGrid1��� -�   $  grid7��#
 [ $
��Left=�$��283,147,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��	Nosivost:��$��0��$
��Left=�$	��0,3q�$��0��$��Center=��� -�   $ nosivostTextBox��$��1��$
��Left=�$��24��$��6,4,0,4q�$��0��$��Center=�$	��128�����	#FF777777���� *SelectedItem.nosivost+$ voziloDataGrid1��� -�   $  grid8��#
 [ $
��Left=�$��497.873,144,0,0q�$	��Top=�$��244.127��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Servisni interval:��$��0��$
��Left=�$��3,6,0,0q�$��0��$��Center=��� -�   $ servisni_intervalTextBox��$��1��$
��Left=�$��22��$��	3,7,-20,3q�$��0��$��Center=�$	��140�����	#FF777777���� * SelectedItem.servisni_interval+$ voziloDataGrid1��� -�   $  grid9��#
 [ $
��Left=�$��
39,192,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $��17 ��� $��15 ��� $
��Left=�$��28��$��
29,119,0,0q�$	��Top=�$	��719�����	#FF0C95F0  -�   $ voziloDataGrid1�� .   . $��29,313,53,117q�$ VisibleWhenSelected=� . ����    -�   id_voziloColumn1��$ SizeToHeader $ #�� �� *	id_vozilo+  -�   registracijaColumn1��$ SizeToHeader $ Registracija�� �� *registracija+  -�   nazivColumn1��$ SizeToHeader $ Naziv�� �� *naziv+  -�   vrsta_vozila_idColumn1��$ SizeToHeader $ Vrsta vozila�� �� *vrsta_vozila_id+  -�   godina_proizvodnjeColumn1��$ SizeToHeader $ Godina proizvodnje�� �� *godina_proizvodnje+  -�   datum_registracijeColumn1��$ SizeToHeader $ Datum registracije�� �� .R�   �� *datum_registracije+$ TwoWay=� .  .   -�   nosivostColumn1��$ SizeToHeader $ Nosivost�� �� *
nosivost+  -�   servisni_intervalColumn1��$ SizeToHeader $ Servisni interval�� �� *servisni_interval+  -�   pocetno_stanje_kmColumn1��$ SizeToHeader $ Početno stanje km�� �� *pocetno_stanje_km+�� -�   $& btnDodajVozilo��$��Dodaj��$
��Left=�$��471,270,0,0q�$	��Top=�$��75��#���  
��������� -�   $& btnIzmjeniVozilo��$��Izmjeni��$
��Left=�$��570,270,0,0q�$	��Top=�$��75��#���  
��������� -�   $& btnObrisiVozilo��$��Obriši��$
��Left=�$��667,270,0,0q�$	��Top=�$��75��#���  
�������� -�   $  grid10��$
��Left=�$��
30,147,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Vrsta vozila:��$��0��$
��Left=�$��3q�$��0��$��Center=��� $
��Left=�$��28��$��
29,176,0,0q�$	��Top=�$	��719�����	#FF0C95F0�� -�   $ cmbVrstaVozila��$
��Left=�$��114,154,0,0q�$	��Top=�$	��120���� -�   $- tabZaposlenici��$��32��$��Bottom=�
�������$��31.333,0,-50,0.045q�#��� 
 
����������� $��Center=�$��Segoe WP Semibold)�$��13(�$��Normal"�$��Stretch=��� $�Unos zaposlenika��.��� #
 [ .+�� -�   $  grid11��#
 [ $
��Left=�$��	34,24,0,0q�$	��Top=�$��49��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $	��ID:��$��0��$��Right=�$��0,3,3,3q�$��0��$��Center=�$��20(�$
��Bold"��� -�   $ id_zaposleniciTextBox��$��1��$
��Left=�$��30��$��0,5,0,8q�$��0��$��Center=�$��68��{�.  $��24(�$
��Bold"�$��0,0,0,2q����� *SelectedItem.id_zaposlenici+$ zaposleniciDataGrid1��  -�   $ zaposleniciDataGrid1�� .   . $��2,360,18,86q�$ VisibleWhenSelected=� . ����    -�   id_zaposleniciColumn1��$ #��$ SizeToHeader  �� *id_zaposlenici+  -�   prezimeColumn1��$ Prezime��$ 80  �� *	prezime+  -�   
imeColumn1��$	 Ime��$ 70  �� *ime+  -�   ulogaColumn��$ Uloga��$ 70  �� *uloga+  -�   telefonColumn1��$ Telefon��$ 70  �� *	telefon+  -�   adresaColumn1��$ Adresa��$ 70  �� *adresa+  -�   
oibColumn1��$	 OIB��$ 60  �� *oib+  -�   iBANColumn1��$
 IBAN��$ 60  �� *IBAN+  -�   korisnicko_imeColumn1��$ Korisničko ime��$ SizeToHeader  �� *korisnicko_ime+  -�   datum_rodjenjaColumn1��$ Datum rođenja��$ SizeToHeader  �� .R�   �� *datum_rodjenja+$ TwoWay=� .  .   -�   datum_zaposlenjaColumn1��$ Datum zaposlenja��$ SizeToHeader  �� .R�   �� *datum_zaposlenja+$ TwoWay=� .  . � -�   $  grid12��$
��Left=�$��	44,85,0,0q�$	��Top=�$	��231��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Prezime:��$��0��$
��Left=�$	��0,3q�$��0��$��Center=�$��58���� -�   $ prezimeTextBox��$��1��$
��Left=�$��23��$��5,4.48,-10,4.48q�$��0��$��Center=�$	��160�����	#FF777777���� *SelectedItem.prezime+$ zaposleniciDataGrid1��� -�   $  grid13��$
��Left=�$��310,85.04,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $
��Ime:��$��0��$
��Left=�$��	-16,3,0,3q�$��0��$��Center=�$��51���� -�   $ 
imeTextBox��$
��Left=�$��23��$��25,4.48,0,4.48q�$��0��$��Center=�$	��160��$��2�����	#FF777777���� *SelectedItem.ime+$ zaposleniciDataGrid1��� -�   $  grid14��$
��Left=�$��548,85.04,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Uloga:��$��0��$
��Left=�$��3q�$��0��$��Center=�� -�   $  grid15��$
��Left=�$��
68,141,0,0q�$	��Top=�$	��187��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Telefon:��$��0��$
��Left=�$��-21,3.02,0,3.02q�$��0��$��Center=�$��74���� -�   $ telefonTextBox��$
��Left=�$��24��$��
41,4,-19,4q�$��0��$��Center=�$	��156��$��2�����	#FF777777���� *SelectedItem.telefon+$ zaposleniciDataGrid1��� -�   $  grid16��$
��Left=�$��285,141,0,0q�$	��Top=�$	��350��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Adresa:��$��0��$
��Left=�$��0,3.02q�$��0��$��Center=�$��52.057���� -�   $ adresaTextBox��$��1��$
��Left=�$��24��$��0,4,-138.943,4q�$��0��$��Center=�$��284.943�����	#FF777777���� *SelectedItem.adresa+$ zaposleniciDataGrid1��� -�   $  grid17��$
��Left=�$��
44,258,0,0q�$	��Top=�$��225.41��! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $
��OIB:��$��0��$
��Left=�$��-4,3,0,3q�$��0��$��Center=�$��42���� -�   $ 
oibTextBox��$��1��$
��Left=�$��24��$��	0,4,-35,4q�$��0��$��Center=�$	��180�����	#FF777777���� *SelectedItem.oib+$ zaposleniciDataGrid1��� -�   $  grid18��$
��Left=�$��522,197,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��IBAN:��$��0��$
��Left=�$��	-10,3,0,3q�$��0��$��Center=�$��52���� -�   $ iBANTextBox��$
��Left=�$��24��$��38,4,0,4q�$��0��$��Center=�$	��160��$��2�����	#FF777777���� *SelectedItem.IBAN+$ zaposleniciDataGrid1��� -�   $  grid19��$
��Left=�$��
34,198,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Korisničko ime:��$��0��$
��Left=�$��3,3,0,3q�$��0��$��Center=��� -�   $ korisnicko_imeTextBox��$
��Left=�$��24��$��
92,4,-19,4q�$��0��$��Center=�$	��139��$��2�����	#FF777777���� *SelectedItem.korisnicko_ime+$ zaposleniciDataGrid1��� -�   $  grid22��$
��Left=�$��281,198,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Lozinka:��$��0��$
��Left=�$��3q�$��0��$��Center=�G� 2!PasswordBoxAssistant.BindPasswordtrue     s"PasswordBoxAssistant.BoundPasswordD{ElementName=zaposleniciDataGrid1, Path=SelectedItem.korisnicko_ime}     -�   . G�Name$. lozinkaPasswordBox��/ G� PasswordChar$/ *��$
��Left=�$��23��$��55.473,4.48,0,4.48q�$��0��$��Center=�$	��160��$��2�����	#FF777777� -�   $  grid20��$
��Left=�$��274.41,258,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Datum rođenja:��$��0��$
��Left=�$��3q�$��0��$��Center=�  -�   $# datum_rodjenjaDatePicker��$��1��$
��Left=�$��3q�$��0��$��Center=� �� *SelectedItem.datum_rodjenja+$ zaposleniciDataGrid1��� -�   $  grid21��$
��Left=�$��505,258,0,0q�$	��Top=�! �� $
��Auto ��� $
��Auto �" �� $
��Auto �.+��� $��Datum zaposlenja:��$��0��$
��Left=�$��3q�$��0��$��Center=�  -�   $ # datum_zaposlenjaDatePicker��$��1��$
��Left=�$��3q�$��0��$��Center=� �� *SelectedItem.datum_rodjenja+$ zaposleniciDataGrid1���� -�   $��Dodaj��$
��Left=�$��450,314.091,0,0q�$	��Top=�$��75��#���  
��������� -�   $��Izmjeni��$
��Left=�$��560,314.091,0,0q�$	��Top=�$��75��#���  
��������� -�   $��Obriši��$
��Left=�$��667,314.091,0,0q�$	��Top=�$��75��#���  
��������� $
��Left=�$��18��$��
44,119,0,0q�$	��Top=�$	��698�����	#FF0C95F0�� $
��Left=�$��15��$��
44,177,0,0q�$	��Top=�$	��698�����	#FF0C95F0�� $
��Left=�$��19��$��
44,234,0,0q�$	��Top=�$	��698�����	#FF0C95F0�� -�   $ cmbUloga��$
��Left=�$��
600,92,0,0q�$	��Top=�$	��120���� $"��-2.001,31.489,-0.999,-32.822q�
�������#���  
����������� $ 
Horizontal=�$	��200��$��70��.+��� $��Center=�$��Segoe WP Semibold)�$��15(�$��SemiBold"�$��Stretch=��� $�Praćenje vozila��.��� 
�������$��
0,-2,-34,0q�.+��� -�   $ tabPracenjeVozila��$	��643��$��Bottom=�$
��Left=�$��836.333��$��	-16,0,0,0q����	#FF0C95F0$��0,1,0,0q�  dizajnPracenja#���  .@�7	  1System.Windows.Forms.Integration.WindowsFormsHost	  $
��Left=�$	��629��$	��Top=�$	��833��$��13.333,0,-24,0q�0 	  Child.0  
   PracenjeVozila.frmPracenje
  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control1   Name$1 mc���� 
�������
�������$��200.5,80.875,819,641.125q�