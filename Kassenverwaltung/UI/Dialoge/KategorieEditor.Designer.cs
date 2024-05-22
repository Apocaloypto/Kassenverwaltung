namespace Kassenverwaltung.UI.Dialoge
{
   partial class KategorieEditor
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
         label1 = new Label();
         tbxBezeichnung = new TextBox();
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
         tableLayoutPanel1.Controls.Add(label1, 0, 0);
         tableLayoutPanel1.Controls.Add(tbxBezeichnung, 1, 0);
         tableLayoutPanel1.Controls.Add(btnOK, 2, 2);
         tableLayoutPanel1.Controls.Add(btnCancel, 3, 2);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 3;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(359, 82);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         label1.Dock = DockStyle.Fill;
         label1.Location = new Point(3, 0);
         label1.Name = "label1";
         label1.Size = new Size(144, 30);
         label1.TabIndex = 0;
         label1.Text = "Bezeichnung:";
         label1.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxBezeichnung
         // 
         tableLayoutPanel1.SetColumnSpan(tbxBezeichnung, 3);
         tbxBezeichnung.Dock = DockStyle.Fill;
         tbxBezeichnung.Location = new Point(153, 3);
         tbxBezeichnung.Name = "tbxBezeichnung";
         tbxBezeichnung.Size = new Size(203, 23);
         tbxBezeichnung.TabIndex = 1;
         // 
         // btnOK
         // 
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(162, 55);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 2;
         btnOK.Text = "OK";
         btnOK.UseVisualStyleBackColor = true;
         btnOK.Click += OnOK;
         // 
         // btnCancel
         // 
         btnCancel.Dock = DockStyle.Fill;
         btnCancel.Location = new Point(262, 55);
         btnCancel.Name = "btnCancel";
         btnCancel.Size = new Size(94, 24);
         btnCancel.TabIndex = 3;
         btnCancel.Text = "Abbrechen";
         btnCancel.UseVisualStyleBackColor = true;
         // 
         // KategorieEditor
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         CancelButton = btnCancel;
         ClientSize = new Size(383, 106);
         Controls.Add(tableLayoutPanel1);
         Name = "KategorieEditor";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterScreen;
         Text = "Kategorie";
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
      private TextBox tbxBezeichnung;
      private Button btnOK;
      private Button btnCancel;
   }
}