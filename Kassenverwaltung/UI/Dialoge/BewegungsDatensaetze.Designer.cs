namespace Kassenverwaltung.UI.Dialoge
{
   partial class BewegungsDatensaetze
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         tableLayoutPanel1 = new TableLayoutPanel();
         lstDatensaetze = new ListView();
         colZielKonto = new ColumnHeader();
         colDatum = new ColumnHeader();
         colBetrag = new ColumnHeader();
         colHinweis = new ColumnHeader();
         btnOK = new Button();
         btnCancel = new Button();
         colVerwendung = new ColumnHeader();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         tableLayoutPanel1.ColumnCount = 3;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.Controls.Add(lstDatensaetze, 0, 0);
         tableLayoutPanel1.Controls.Add(btnOK, 1, 1);
         tableLayoutPanel1.Controls.Add(btnCancel, 2, 1);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 2;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(776, 426);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // lstDatensaetze
         // 
         lstDatensaetze.CheckBoxes = true;
         lstDatensaetze.Columns.AddRange(new ColumnHeader[] { colZielKonto, colDatum, colBetrag, colVerwendung, colHinweis });
         tableLayoutPanel1.SetColumnSpan(lstDatensaetze, 3);
         lstDatensaetze.Dock = DockStyle.Fill;
         lstDatensaetze.FullRowSelect = true;
         lstDatensaetze.GridLines = true;
         lstDatensaetze.Location = new Point(3, 3);
         lstDatensaetze.Name = "lstDatensaetze";
         lstDatensaetze.Size = new Size(770, 390);
         lstDatensaetze.TabIndex = 0;
         lstDatensaetze.UseCompatibleStateImageBehavior = false;
         lstDatensaetze.View = View.Details;
         lstDatensaetze.ItemCheck += OnItemCheck;
         lstDatensaetze.ItemChecked += OnItemChecked;
         lstDatensaetze.SelectedIndexChanged += SelectedIndexChanged;
         // 
         // colZielKonto
         // 
         colZielKonto.Text = "ZielKonto";
         // 
         // colDatum
         // 
         colDatum.Text = "Datum";
         // 
         // colBetrag
         // 
         colBetrag.Text = "Betrag";
         // 
         // colHinweis
         // 
         colHinweis.Text = "Hinweis";
         // 
         // btnOK
         // 
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(579, 399);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 1;
         btnOK.Text = "Importieren";
         btnOK.UseVisualStyleBackColor = true;
         btnOK.Click += OnOK;
         // 
         // btnCancel
         // 
         btnCancel.Dock = DockStyle.Fill;
         btnCancel.Location = new Point(679, 399);
         btnCancel.Name = "btnCancel";
         btnCancel.Size = new Size(94, 24);
         btnCancel.TabIndex = 2;
         btnCancel.Text = "Abbrechen";
         btnCancel.UseVisualStyleBackColor = true;
         // 
         // colVerwendung
         // 
         colVerwendung.Text = "Verwendungszweck";
         // 
         // BewegungsDatensaetze
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         CancelButton = btnCancel;
         ClientSize = new Size(800, 450);
         Controls.Add(tableLayoutPanel1);
         Name = "BewegungsDatensaetze";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterParent;
         Text = "Datensätze zum Import auswählen";
         tableLayoutPanel1.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private ListView lstDatensaetze;
      private Button btnOK;
      private Button btnCancel;
      private ColumnHeader colZielKonto;
      private ColumnHeader colDatum;
      private ColumnHeader colHinweis;
      private ColumnHeader colBetrag;
      private ColumnHeader colVerwendung;
   }
}