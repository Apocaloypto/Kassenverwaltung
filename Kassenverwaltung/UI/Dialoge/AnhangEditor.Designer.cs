namespace Kassenverwaltung.UI.Dialoge
{
   partial class AnhangEditor
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
         tbxName = new TextBox();
         tbxPfad = new TextBox();
         btnSelectPfad = new Button();
         cbxLinkOnly = new CheckBox();
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
         tableLayoutPanel1.Controls.Add(tbxName, 1, 0);
         tableLayoutPanel1.Controls.Add(tbxPfad, 1, 1);
         tableLayoutPanel1.Controls.Add(btnSelectPfad, 4, 1);
         tableLayoutPanel1.Controls.Add(cbxLinkOnly, 0, 2);
         tableLayoutPanel1.Controls.Add(btnOK, 2, 4);
         tableLayoutPanel1.Controls.Add(btnCancel, 3, 4);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 5;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(368, 154);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // label2
         // 
         label2.Dock = DockStyle.Fill;
         label2.Location = new Point(3, 30);
         label2.Name = "label2";
         label2.Size = new Size(144, 30);
         label2.TabIndex = 2;
         label2.Text = "Pfad:";
         label2.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // label1
         // 
         label1.Dock = DockStyle.Fill;
         label1.Location = new Point(3, 0);
         label1.Name = "label1";
         label1.Size = new Size(144, 30);
         label1.TabIndex = 0;
         label1.Text = "Dateiname:";
         label1.TextAlign = ContentAlignment.MiddleLeft;
         // 
         // tbxName
         // 
         tableLayoutPanel1.SetColumnSpan(tbxName, 4);
         tbxName.Dock = DockStyle.Fill;
         tbxName.Location = new Point(153, 3);
         tbxName.Name = "tbxName";
         tbxName.Size = new Size(212, 23);
         tbxName.TabIndex = 1;
         // 
         // tbxPfad
         // 
         tableLayoutPanel1.SetColumnSpan(tbxPfad, 3);
         tbxPfad.Dock = DockStyle.Fill;
         tbxPfad.Location = new Point(153, 33);
         tbxPfad.Name = "tbxPfad";
         tbxPfad.ReadOnly = true;
         tbxPfad.Size = new Size(182, 23);
         tbxPfad.TabIndex = 3;
         tbxPfad.Click += OnClickedSelectPfad;
         // 
         // btnSelectPfad
         // 
         btnSelectPfad.Dock = DockStyle.Fill;
         btnSelectPfad.Location = new Point(341, 33);
         btnSelectPfad.Name = "btnSelectPfad";
         btnSelectPfad.Size = new Size(24, 24);
         btnSelectPfad.TabIndex = 4;
         btnSelectPfad.Text = "...";
         btnSelectPfad.UseVisualStyleBackColor = true;
         btnSelectPfad.Click += OnClickedSelectPfad;
         // 
         // cbxLinkOnly
         // 
         tableLayoutPanel1.SetColumnSpan(cbxLinkOnly, 5);
         cbxLinkOnly.Dock = DockStyle.Fill;
         cbxLinkOnly.Location = new Point(3, 63);
         cbxLinkOnly.Name = "cbxLinkOnly";
         cbxLinkOnly.Size = new Size(362, 24);
         cbxLinkOnly.TabIndex = 5;
         cbxLinkOnly.Text = "Als Verknüpfung speichern";
         cbxLinkOnly.UseVisualStyleBackColor = true;
         // 
         // btnOK
         // 
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(171, 127);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 6;
         btnOK.Text = "OK";
         btnOK.UseVisualStyleBackColor = true;
         btnOK.Click += OnOK;
         // 
         // btnCancel
         // 
         tableLayoutPanel1.SetColumnSpan(btnCancel, 2);
         btnCancel.Dock = DockStyle.Fill;
         btnCancel.Location = new Point(271, 127);
         btnCancel.Name = "btnCancel";
         btnCancel.Size = new Size(94, 24);
         btnCancel.TabIndex = 7;
         btnCancel.Text = "Abbrechen";
         btnCancel.UseVisualStyleBackColor = true;
         // 
         // AnhangEditor
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         CancelButton = btnCancel;
         ClientSize = new Size(392, 178);
         Controls.Add(tableLayoutPanel1);
         MinimumSize = new Size(400, 215);
         Name = "AnhangEditor";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterParent;
         Text = "Beleg";
         tableLayoutPanel1.ResumeLayout(false);
         tableLayoutPanel1.PerformLayout();
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
      private TextBox tbxName;
      private Label label2;
      private TextBox tbxPfad;
      private Button btnSelectPfad;
      private CheckBox cbxLinkOnly;
      private Button btnOK;
      private Button btnCancel;
   }
}