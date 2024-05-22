using Kassenverwaltung.Database.Models;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Dialoge
{
   public partial class KategorienListe : Form
   {
      private readonly KVManager _kvManager;

      public bool HasChanged { get; private set; }

      public KategorienListe(KVManager kVManager)
      {
         InitializeComponent();

         _kvManager = kVManager;
      }

      private void InsertKategorie(Kategorie kategorie)
      {
         var lvi = new ListViewItem(kategorie.Name);
         lvi.Tag = kategorie;
         lstKategorien.Items.Add(lvi);
      }

      private void FillListControl()
      {
         lstKategorien.Items.Clear();

         IList<Kategorie> kategorien = _kvManager.ListKategorien();
         foreach (var kategorie in kategorien)
         {
            InsertKategorie(kategorie);
         }
      }

      private void OnAddClicked(object sender, EventArgs e)
      {

      }

      private void OnEditClicked(object sender, EventArgs e)
      {

      }

      private void OnDelClicked(object sender, EventArgs e)
      {

      }
   }
}
