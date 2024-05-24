namespace Kassenverwaltung.UI.Container
{
   partial class BewegungsListe
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         tableLayoutPanel1 = new TableLayoutPanel();
         lstBewegungen = new ListView();
         colLfdNr = new ColumnHeader();
         colDatum = new ColumnHeader();
         colVerwendung = new ColumnHeader();
         colBetrag = new ColumnHeader();
         label1 = new Label();
         tbxKontostand = new TextBox();
         btnEdit = new Button();
         btnDel = new Button();
         splAdd = new UserControls.SplitButton();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.ColumnCount = 6;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
         tableLayoutPanel1.Controls.Add(lstBewegungen, 0, 0);
         tableLayoutPanel1.Controls.Add(label1, 0, 1);
         tableLayoutPanel1.Controls.Add(tbxKontostand, 1, 1);
         tableLayoutPanel1.Controls.Add(btnEdit, 4, 1);
         tableLayoutPanel1.Controls.Add(btnDel, 3, 1);
         tableLayoutPanel1.Controls.Add(splAdd, 5, 1);
         tableLayoutPanel1.Dock = DockStyle.Fill;
         tableLayoutPanel1.Location = new Point(0, 0);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 2;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(480, 302);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // lstBewegungen
         // 
         lstBewegungen.Columns.AddRange(new ColumnHeader[] { colLfdNr, colDatum, colVerwendung, colBetrag });
         tableLayoutPanel1.SetColumnSpan(lstBewegungen, 6);
         lstBewegungen.Dock = DockStyle.Fill;
         lstBewegungen.FullRowSelect = true;
         lstBewegungen.Location = new Point(3, 3);
         lstBewegungen.Name = "lstBewegungen";
         lstBewegungen.Size = new Size(474, 266);
         lstBewegungen.TabIndex = 0;
         lstBewegungen.UseCompatibleStateImageBehavior = false;
         lstBewegungen.View = View.Details;
         lstBewegungen.SelectedIndexChanged += OnSelectedIndexChanged;
         lstBewegungen.DoubleClick += OnDoubleClick;
         // 
         // colLfdNr
         // 
         colLfdNr.Text = "Lfd. Nr.";
         // 
         // colDatum
         // 
         colDatum.Text = "Datum";
         // 
         // colVerwendung
         // 
         colVerwendung.Text = "Verwendungszweck";
         // 
         // colBetrag
         // 
         colBetrag.Text = "Betrag";
         // 
         // label1
         // 
         label1.Dock = DockStyle.Fill;
         label1.Location = new Point(3, 272);
         label1.Name = "label1";
         label1.Size = new Size(94, 30);
         label1.TabIndex = 1;
         label1.Text = "Kontostand:";
         label1.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxKontostand
         // 
         tbxKontostand.Dock = DockStyle.Fill;
         tbxKontostand.Location = new Point(103, 275);
         tbxKontostand.Name = "tbxKontostand";
         tbxKontostand.ReadOnly = true;
         tbxKontostand.Size = new Size(94, 23);
         tbxKontostand.TabIndex = 2;
         tbxKontostand.TextAlign = HorizontalAlignment.Right;
         // 
         // btnEdit
         // 
         btnEdit.Dock = DockStyle.Fill;
         btnEdit.Image = Resources.btnEdit;
         btnEdit.Location = new Point(403, 275);
         btnEdit.Name = "btnEdit";
         btnEdit.Size = new Size(24, 24);
         btnEdit.TabIndex = 4;
         btnEdit.UseVisualStyleBackColor = true;
         btnEdit.Click += OnBtnClickedEdit;
         // 
         // btnDel
         // 
         btnDel.Dock = DockStyle.Fill;
         btnDel.Image = Resources.btnDel;
         btnDel.Location = new Point(373, 275);
         btnDel.Name = "btnDel";
         btnDel.Size = new Size(24, 24);
         btnDel.TabIndex = 5;
         btnDel.UseVisualStyleBackColor = true;
         btnDel.Click += OnBtnClickedDel;
         // 
         // splAdd
         // 
         splAdd.Dock = DockStyle.Fill;
         splAdd.Image = Resources.btnAdd;
         splAdd.Location = new Point(433, 275);
         splAdd.Name = "splAdd";
         splAdd.Size = new Size(44, 24);
         splAdd.TabIndex = 6;
         splAdd.MainButtonClick += OnMainButtonClicked;
         // 
         // BewegungsListe
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(tableLayoutPanel1);
         Name = "BewegungsListe";
         Size = new Size(480, 302);
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private ListView lstBewegungen;
      private ColumnHeader colLfdNr;
      private ColumnHeader colDatum;
      private ColumnHeader colVerwendung;
      private ColumnHeader colBetrag;
      private Label label1;
      private TextBox tbxKontostand;
      private Button btnEdit;
      private Button btnDel;
      private UserControls.SplitButton splAdd;
   }
}
