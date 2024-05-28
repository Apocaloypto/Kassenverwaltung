using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class BewegungsUebersicht : UserControl
   {
      public BewegungsUebersicht()
      {
         InitializeComponent();
      }

      public void SetCurrentKassenManager(KassenManager? kassenManager)
      {
         bewegungsListe.SetCurrentKassenManager(kassenManager);
         anhangsListe1.SetCurrentKassenManager(kassenManager);
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
