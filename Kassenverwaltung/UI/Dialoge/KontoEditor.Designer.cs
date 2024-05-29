namespace Kassenverwaltung.UI.Dialoge
{
   partial class KontoEditor
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
         tbxBIC = new TextBox();
         label3 = new Label();
         tbxIBAN = new TextBox();
         label2 = new Label();
         btnOK = new Button();
         btnCancel = new Button();
         label1 = new Label();
         tbxBezeichnung = new TextBox();
         moneyAnfang = new UserControls.MoneyInput();
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
         tableLayoutPanel1.Controls.Add(tbxBIC, 1, 2);
         tableLayoutPanel1.Controls.Add(label3, 0, 2);
         tableLayoutPanel1.Controls.Add(tbxIBAN, 1, 1);
         tableLayoutPanel1.Controls.Add(label2, 0, 1);
         tableLayoutPanel1.Controls.Add(btnOK, 2, 5);
         tableLayoutPanel1.Controls.Add(btnCancel, 3, 5);
         tableLayoutPanel1.Controls.Add(label1, 0, 0);
         tableLayoutPanel1.Controls.Add(tbxBezeichnung, 1, 0);
         tableLayoutPanel1.Controls.Add(moneyAnfang, 1, 3);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 6;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(366, 172);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // label4
         // 
         label4.Dock = DockStyle.Fill;
         label4.Location = new Point(3, 90);
         label4.Name = "label4";
         label4.Size = new Size(144, 30);
         label4.TabIndex = 8;
         label4.Text = "Anfangsbestand:";
         label4.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxBIC
         // 
         tableLayoutPanel1.SetColumnSpan(tbxBIC, 3);
         tbxBIC.Dock = DockStyle.Fill;
         tbxBIC.Location = new Point(153, 63);
         tbxBIC.Name = "tbxBIC";
         tbxBIC.Size = new Size(210, 23);
         tbxBIC.TabIndex = 7;
         // 
         // label3
         // 
         label3.Dock = DockStyle.Fill;
         label3.Location = new Point(3, 60);
         label3.Name = "label3";
         label3.Size = new Size(144, 30);
         label3.TabIndex = 6;
         label3.Text = "BIC:";
         label3.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxIBAN
         // 
         tableLayoutPanel1.SetColumnSpan(tbxIBAN, 3);
         tbxIBAN.Dock = DockStyle.Fill;
         tbxIBAN.Location = new Point(153, 33);
         tbxIBAN.Name = "tbxIBAN";
         tbxIBAN.Size = new Size(210, 23);
         tbxIBAN.TabIndex = 5;
         // 
         // label2
         // 
         label2.Dock = DockStyle.Fill;
         label2.Location = new Point(3, 30);
         label2.Name = "label2";
         label2.Size = new Size(144, 30);
         label2.TabIndex = 4;
         label2.Text = "IBAN:";
         label2.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // btnOK
         // 
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(169, 145);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 0;
         btnOK.Text = "OK";
         btnOK.UseVisualStyleBackColor = true;
         btnOK.Click += OnOK;
         // 
         // btnCancel
         // 
         btnCancel.Dock = DockStyle.Fill;
         btnCancel.Location = new Point(269, 145);
         btnCancel.Name = "btnCancel";
         btnCancel.Size = new Size(94, 24);
         btnCancel.TabIndex = 1;
         btnCancel.Text = "Abbrechen";
         btnCancel.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         label1.Dock = DockStyle.Fill;
         label1.Location = new Point(3, 0);
         label1.Name = "label1";
         label1.Size = new Size(144, 30);
         label1.TabIndex = 2;
         label1.Text = "Bezeichnung:";
         label1.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxBezeichnung
         // 
         tableLayoutPanel1.SetColumnSpan(tbxBezeichnung, 3);
         tbxBezeichnung.Dock = DockStyle.Fill;
         tbxBezeichnung.Location = new Point(153, 3);
         tbxBezeichnung.Name = "tbxBezeichnung";
         tbxBezeichnung.Size = new Size(210, 23);
         tbxBezeichnung.TabIndex = 3;
         // 
         // moneyAnfang
         // 
         tableLayoutPanel1.SetColumnSpan(moneyAnfang, 3);
         moneyAnfang.Dock = DockStyle.Fill;
         moneyAnfang.Location = new Point(153, 93);
         moneyAnfang.Name = "moneyAnfang";
         moneyAnfang.Size = new Size(210, 24);
         moneyAnfang.TabIndex = 9;
         moneyAnfang.Value = new decimal(new int[] { 0, 0, 0, 0 });
         // 
         // KontoEditor
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         CancelButton = btnCancel;
         ClientSize = new Size(390, 196);
         Controls.Add(tableLayoutPanel1);
         MinimumSize = new Size(400, 235);
         Name = "KontoEditor";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterParent;
         Text = "Konto";
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Button btnOK;
      private Button btnCancel;
      private Label label1;
      private TextBox tbxBezeichnung;
      private TextBox tbxBIC;
      private Label label3;
      private TextBox tbxIBAN;
      private Label label2;
      private Label label4;
      private UserControls.MoneyInput moneyAnfang;
   }
}