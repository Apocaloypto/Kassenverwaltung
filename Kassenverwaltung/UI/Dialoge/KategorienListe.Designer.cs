namespace Kassenverwaltung.UI.Dialoge
{
   partial class KategorienListe
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
         btnOK = new Button();
         btnAdd = new Button();
         btnMod = new Button();
         btnDel = new Button();
         lstKategorien = new ListView();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         tableLayoutPanel1.ColumnCount = 5;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
         tableLayoutPanel1.Controls.Add(btnOK, 1, 2);
         tableLayoutPanel1.Controls.Add(btnAdd, 2, 0);
         tableLayoutPanel1.Controls.Add(btnMod, 3, 0);
         tableLayoutPanel1.Controls.Add(btnDel, 4, 0);
         tableLayoutPanel1.Controls.Add(lstKategorien, 0, 1);
         tableLayoutPanel1.Location = new Point(12, 12);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 3;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(776, 426);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // btnOK
         // 
         tableLayoutPanel1.SetColumnSpan(btnOK, 4);
         btnOK.Dock = DockStyle.Fill;
         btnOK.Location = new Point(679, 399);
         btnOK.Name = "btnOK";
         btnOK.Size = new Size(94, 24);
         btnOK.TabIndex = 0;
         btnOK.Text = "OK";
         btnOK.UseVisualStyleBackColor = true;
         // 
         // btnAdd
         // 
         btnAdd.Dock = DockStyle.Fill;
         btnAdd.Image = Resources.btnAdd;
         btnAdd.Location = new Point(689, 3);
         btnAdd.Name = "btnAdd";
         btnAdd.Size = new Size(24, 24);
         btnAdd.TabIndex = 1;
         btnAdd.UseVisualStyleBackColor = true;
         btnAdd.Click += OnAddClicked;
         // 
         // btnMod
         // 
         btnMod.Dock = DockStyle.Fill;
         btnMod.Image = Resources.btnEdit;
         btnMod.Location = new Point(719, 3);
         btnMod.Name = "btnMod";
         btnMod.Size = new Size(24, 24);
         btnMod.TabIndex = 2;
         btnMod.UseVisualStyleBackColor = true;
         btnMod.Click += OnEditClicked;
         // 
         // btnDel
         // 
         btnDel.Dock = DockStyle.Fill;
         btnDel.Image = Resources.btnDel;
         btnDel.Location = new Point(749, 3);
         btnDel.Name = "btnDel";
         btnDel.Size = new Size(24, 24);
         btnDel.TabIndex = 3;
         btnDel.UseVisualStyleBackColor = true;
         btnDel.Click += OnDelClicked;
         // 
         // lstKategorien
         // 
         tableLayoutPanel1.SetColumnSpan(lstKategorien, 5);
         lstKategorien.Dock = DockStyle.Fill;
         lstKategorien.Location = new Point(3, 33);
         lstKategorien.Name = "lstKategorien";
         lstKategorien.Size = new Size(770, 360);
         lstKategorien.TabIndex = 4;
         lstKategorien.UseCompatibleStateImageBehavior = false;
         lstKategorien.View = View.List;
         // 
         // KategorienListe
         // 
         AcceptButton = btnOK;
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(800, 450);
         Controls.Add(tableLayoutPanel1);
         Name = "KategorienListe";
         ShowIcon = false;
         StartPosition = FormStartPosition.CenterParent;
         Text = "Definierte Kategorien";
         tableLayoutPanel1.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Button btnOK;
      private Button btnAdd;
      private Button btnMod;
      private Button btnDel;
      private ListView lstKategorien;
   }
}