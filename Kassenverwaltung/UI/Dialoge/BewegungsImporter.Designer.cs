namespace Kassenverwaltung.UI.Dialoge
{
   partial class BewegungsImporter
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
         label2 = new Label();
         label1 = new Label();
         tbxPath = new TextBox();
         btnSelectPath = new Button();
         cbxFormat = new ComboBox();
         btnOK = new Button();
         btnCancel = new Button();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         tableLayoutPanel1.ColumnCount = 5;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Controls.Add(label2, 0, 1);
         tableLayoutPanel1.Controls.Add(label1, 0, 0);
         tableLayoutPanel1.Controls.Add(tbxPath, 1, 0);
         tableLayoutPanel1.Controls.Add(btnSelectPath, 4, 0);
         tableLayoutPanel1.Controls.Add(cbxFormat, 1, 1);
         tableLayoutPanel1.Controls.Add(btnOK, 2, 3);
         tableLayoutPanel1.Controls.Add(btnCancel, 3, 3);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 4;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(375, 107);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // label2
         // 
         label2.Dock = DockStyle.Fill;
         label2.Location = new Point(3, 30);
         label2.Name = "label2";
         label2.Size = new Size(144, 30);
         label2.TabIndex = 3;
         label2.Text = "Format:";
         label2.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // label1
         // 
         label1.Dock = DockStyle.Fill;
         label1.Location = new Point(3, 0);
         label1.Name = "label1";
         label1.Size = new Size(144, 30);
         label1.TabIndex = 0;
         label1.Text = "Datei:";
         label1.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxPath
         // 
         tableLayoutPanel1.SetColumnSpan(tbxPath, 3);
         tbxPath.Dock = DockStyle.Fill;
         tbxPath.Location = new Point(153, 3);
         tbxPath.Name = "tbxPath";
         tbxPath.ReadOnly = true;
         tbxPath.Size = new Size(189, 23);
         tbxPath.TabIndex = 1;
         tbxPath.Click += OnSelectPath;
         // 
         // btnSelectPath
         // 
         btnSelectPath.Dock = DockStyle.Fill;
         btnSelectPath.Location = new Point(348, 3);
         btnSelectPath.Name = "btnSelectPath";
         btnSelectPath.Size = new Size(24, 24);
         btnSelectPath.TabIndex = 2;
         btnSelectPath.Text = "...";
         btnSelectPath.UseVisualStyleBackColor = true;
         btnSelectPath.Click += OnSelectPath;
         // 
         // cbxFormat
         // 
         tableLayoutPanel1.SetColumnSpan(cbxFormat, 4);
         cbxFormat.Dock = DockStyle.Fill;
         cbxFormat.DropDownStyle = ComboBoxStyle.DropDownList;
         cbxFormat.FormattingEnabled = true;
         cbxFormat.Location = new Point(153, 33);
         cbxFormat.Name = "cbxFormat";
         cbxFormat.Size = new Size(219, 23);
         cbxFormat.TabIndex = 4;
         // 
         // btnOK
         // 
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(178, 80);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 5;
         btnOK.Text = "OK";
         btnOK.UseVisualStyleBackColor = true;
         btnOK.Click += OnOK;
         // 
         // btnCancel
         // 
         tableLayoutPanel1.SetColumnSpan(btnCancel, 2);
         btnCancel.Dock = DockStyle.Fill;
         btnCancel.Location = new Point(278, 80);
         btnCancel.Name = "btnCancel";
         btnCancel.Size = new Size(94, 24);
         btnCancel.TabIndex = 6;
         btnCancel.Text = "Abbrechen";
         btnCancel.UseVisualStyleBackColor = true;
         // 
         // BewegungsImporter
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         CancelButton = btnCancel;
         ClientSize = new Size(399, 131);
         Controls.Add(tableLayoutPanel1);
         MinimumSize = new Size(415, 170);
         Name = "BewegungsImporter";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterParent;
         Text = "Import von Bewegungsdaten";
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
      private TextBox tbxPath;
      private Button btnSelectPath;
      private Label label2;
      private ComboBox cbxFormat;
      private Button btnOK;
      private Button btnCancel;
   }
}