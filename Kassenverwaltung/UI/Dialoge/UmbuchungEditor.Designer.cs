namespace Kassenverwaltung.UI.Dialoge
{
   partial class UmbuchungEditor
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
         label4 = new Label();
         label3 = new Label();
         label2 = new Label();
         label1 = new Label();
         cbxKonto = new ComboBox();
         dtpDatum = new DateTimePicker();
         monBetrag = new UserControls.MoneyInput();
         tbxVerwendung = new TextBox();
         btnOK = new Button();
         btnCancel = new Button();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         tableLayoutPanel1.ColumnCount = 4;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.Controls.Add(label4, 0, 3);
         tableLayoutPanel1.Controls.Add(label3, 0, 2);
         tableLayoutPanel1.Controls.Add(label2, 0, 1);
         tableLayoutPanel1.Controls.Add(label1, 0, 0);
         tableLayoutPanel1.Controls.Add(cbxKonto, 1, 0);
         tableLayoutPanel1.Controls.Add(dtpDatum, 1, 1);
         tableLayoutPanel1.Controls.Add(monBetrag, 1, 2);
         tableLayoutPanel1.Controls.Add(tbxVerwendung, 1, 3);
         tableLayoutPanel1.Controls.Add(btnOK, 2, 5);
         tableLayoutPanel1.Controls.Add(btnCancel, 3, 5);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 6;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(375, 297);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // label4
         // 
         label4.Dock = DockStyle.Fill;
         label4.Location = new Point(3, 90);
         label4.Name = "label4";
         label4.Size = new Size(144, 30);
         label4.TabIndex = 6;
         label4.Text = "Verwendung:";
         label4.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // label3
         // 
         label3.Dock = DockStyle.Fill;
         label3.Location = new Point(3, 60);
         label3.Name = "label3";
         label3.Size = new Size(144, 30);
         label3.TabIndex = 4;
         label3.Text = "Betrag:";
         label3.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // label2
         // 
         label2.Dock = DockStyle.Fill;
         label2.Location = new Point(3, 30);
         label2.Name = "label2";
         label2.Size = new Size(144, 30);
         label2.TabIndex = 2;
         label2.Text = "Datum:";
         label2.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // label1
         // 
         label1.Dock = DockStyle.Fill;
         label1.Location = new Point(3, 0);
         label1.Name = "label1";
         label1.Size = new Size(144, 30);
         label1.TabIndex = 0;
         label1.Text = "Konto:";
         label1.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // cbxKonto
         // 
         tableLayoutPanel1.SetColumnSpan(cbxKonto, 3);
         cbxKonto.Dock = DockStyle.Fill;
         cbxKonto.DropDownStyle = ComboBoxStyle.DropDownList;
         cbxKonto.FormattingEnabled = true;
         cbxKonto.Location = new Point(153, 3);
         cbxKonto.Name = "cbxKonto";
         cbxKonto.Size = new Size(219, 23);
         cbxKonto.TabIndex = 1;
         // 
         // dtpDatum
         // 
         tableLayoutPanel1.SetColumnSpan(dtpDatum, 3);
         dtpDatum.Dock = DockStyle.Fill;
         dtpDatum.Format = DateTimePickerFormat.Short;
         dtpDatum.Location = new Point(153, 33);
         dtpDatum.Name = "dtpDatum";
         dtpDatum.Size = new Size(219, 23);
         dtpDatum.TabIndex = 3;
         // 
         // monBetrag
         // 
         tableLayoutPanel1.SetColumnSpan(monBetrag, 3);
         monBetrag.Dock = DockStyle.Fill;
         monBetrag.Location = new Point(153, 63);
         monBetrag.Name = "monBetrag";
         monBetrag.Size = new Size(219, 24);
         monBetrag.TabIndex = 5;
         monBetrag.Value = new decimal(new int[] { 0, 0, 0, 0 });
         // 
         // tbxVerwendung
         // 
         tableLayoutPanel1.SetColumnSpan(tbxVerwendung, 3);
         tbxVerwendung.Dock = DockStyle.Fill;
         tbxVerwendung.Location = new Point(153, 93);
         tbxVerwendung.Multiline = true;
         tbxVerwendung.Name = "tbxVerwendung";
         tableLayoutPanel1.SetRowSpan(tbxVerwendung, 2);
         tbxVerwendung.Size = new Size(219, 171);
         tbxVerwendung.TabIndex = 7;
         // 
         // btnOK
         // 
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(178, 270);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 8;
         btnOK.Text = "OK";
         btnOK.UseVisualStyleBackColor = true;
         btnOK.Click += OnOK;
         // 
         // btnCancel
         // 
         btnCancel.Dock = DockStyle.Fill;
         btnCancel.Location = new Point(278, 270);
         btnCancel.Name = "btnCancel";
         btnCancel.Size = new Size(94, 24);
         btnCancel.TabIndex = 9;
         btnCancel.Text = "Abbrechen";
         btnCancel.UseVisualStyleBackColor = true;
         // 
         // UmbuchungEditor
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         CancelButton = btnCancel;
         ClientSize = new Size(399, 321);
         Controls.Add(tableLayoutPanel1);
         Name = "UmbuchungEditor";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterParent;
         Text = "Umbuchung";
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
      private ComboBox cbxKonto;
      private Label label2;
      private DateTimePicker dtpDatum;
      private Label label3;
      private UserControls.MoneyInput monBetrag;
      private Label label4;
      private TextBox tbxVerwendung;
      private Button btnOK;
      private Button btnCancel;
   }
}