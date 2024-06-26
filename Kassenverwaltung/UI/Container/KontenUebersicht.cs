﻿using Kassenverwaltung.Database.Models;
using Kassenverwaltung.UI.Dialoge;
using Kassenverwaltung.Util;

namespace Kassenverwaltung.UI.Container
{
   public partial class KontenUebersicht : UserControl
   {
      private KassenManager? _kassenManager;

      public event EventHandler<Konto?>? SelectedKontoChanged;

      public KontenUebersicht()
      {
         InitializeComponent();

         SetButtonStates();
      }

      public void SetCurrentKassenManager(KassenManager? kassenManager)
      {
         _kassenManager = kassenManager;
         FillListBox();
         SetButtonStates();
      }

      private void InsertKontoRow(Konto konto)
      {
         ListViewItem lvi = new ListViewItem(konto.Name);
         lvi.SubItems.Add(konto.IBAN);
         lvi.Tag = konto;
         lstKonten.Items.Add(lvi);
      }

      private void FillListBox()
      {
         int? currentlySelectedKonto = GetSelectedKonto()?.Id;
         lstKonten.Items.Clear();

         if (_kassenManager != null)
         {
            IList<Konto> konten = _kassenManager.ListKonten();
            foreach (var konto in konten)
            {
               InsertKontoRow(konto);
            }

            lstKonten.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstKonten.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (currentlySelectedKonto.HasValue)
            {
               lstKonten.SelectItem((Konto? k) => k?.Id == currentlySelectedKonto.Value);
            }
         }
      }

      private Konto? GetSelectedKonto()
      {
         if (lstKonten.SelectedItems.Count >= 1)
         {
            return (Konto?)lstKonten.SelectedItems[0].Tag;
         }
         else
         {
            return null;
         }
      }

      private void SetButtonStates()
      {
         bool contextValid = _kassenManager != null;
         bool kontoSelected = contextValid && (GetSelectedKonto() != null);

         btnAdd.Enabled = contextValid;
         btnEdit.Enabled = kontoSelected;
         btnDel.Enabled = kontoSelected;
      }

      private void OnClickedAdd(object sender, EventArgs e)
      {
         if (_kassenManager != null)
         {
            var neuesKonto = new Konto();
            using (var kontoEditor = new KontoEditor(neuesKonto))
            {
               if (kontoEditor.ShowDialog() == DialogResult.OK)
               {
                  _kassenManager.AddKonto(neuesKonto);
                  FillListBox();
               }
            }
         }
      }

      private void OnClickedDel(object sender, EventArgs e)
      {
         if (_kassenManager != null)
         {
            var selectedKonto = GetSelectedKonto();
            if (selectedKonto != null)
            {
               if (MessageService.ShowYesNo($"Möchten Sie das ausgewählte Konto '{selectedKonto.Name}' wirklich löschen?", "Löschen?"))
               {
                  _kassenManager.DeleteKonto(selectedKonto);
                  FillListBox();
               }
            }
         }
      }

      private void OnClickedEdit(object sender, EventArgs e)
      {
         EditSelectedKonto();
      }

      private void EditSelectedKonto()
      {
         if (_kassenManager != null)
         {
            var selectedKonto = GetSelectedKonto();
            if (selectedKonto != null)
            {
               using (var kontoEditor = new KontoEditor(selectedKonto))
               {
                  if (kontoEditor.ShowDialog() == DialogResult.OK)
                  {
                     _kassenManager.UpdateKonto(selectedKonto);
                     FillListBox();
                  }
               }
            }
         }
      }

      private void OnSelectedIndexChanged(object sender, EventArgs e)
      {
         SetButtonStates();
         SelectedKontoChanged?.Invoke(this, GetSelectedKonto());
      }

      private void OnDoubleClick(object sender, EventArgs e)
      {
         EditSelectedKonto();
      }
   }
}
