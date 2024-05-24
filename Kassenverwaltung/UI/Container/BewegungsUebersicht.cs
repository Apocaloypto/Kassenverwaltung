﻿using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class BewegungsUebersicht : UserControl
   {
      public BewegungsUebersicht()
      {
         InitializeComponent();
      }

      public void SetCurrentDatabase(KVManager? dataManager)
      {
         bewegungsListe.SetCurrentDatabase(dataManager);
         anhangsListe1.SetCurrentDatabase(dataManager);
      }

      public void SetCurrentKonto(Konto? konto)
      {
         bewegungsListe.SetCurrentKonto(konto);
      }

      private void OnSelectedBewegungChanged(object? sender, Bewegung? selectedBewegung)
      {
         anhangsListe1.SetCurrentBewegung(selectedBewegung);
      }
   }
}
