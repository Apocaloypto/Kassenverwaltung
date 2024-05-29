namespace Kassenverwaltung.UI.Container
{
   partial class KontenUebersicht
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
         lstKonten = new ListView();
         colName = new ColumnHeader();
         colIban = new ColumnHeader();
         btnAdd = new Button();
         btnEdit = new Button();
         btnDel = new Button();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.ColumnCount = 4;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Controls.Add(lstKonten, 0, 0);
         tableLayoutPanel1.Controls.Add(btnAdd, 3, 1);
         tableLayoutPanel1.Controls.Add(btnEdit, 2, 1);
         tableLayoutPanel1.Controls.Add(btnDel, 1, 1);
         tableLayoutPanel1.Dock = DockStyle.Fill;
         tableLayoutPanel1.Location = new Point(0, 0);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 2;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(420, 270);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // lstKonten
         // 
         lstKonten.Columns.AddRange(new ColumnHeader[] { colName, colIban });
         tableLayoutPanel1.SetColumnSpan(lstKonten, 4);
         lstKonten.Dock = DockStyle.Fill;
         lstKonten.FullRowSelect = true;
         lstKonten.GridLines = true;
         lstKonten.Location = new Point(3, 3);
         lstKonten.Name = "lstKonten";
         lstKonten.Size = new Size(414, 234);
         lstKonten.TabIndex = 0;
         lstKonten.UseCompatibleStateImageBehavior = false;
         lstKonten.View = View.Details;
         lstKonten.SelectedIndexChanged += OnSelectedIndexChanged;
         lstKonten.DoubleClick += OnDoubleClick;
         // 
         // colName
         // 
         colName.Text = "Bezeichnung";
         // 
         // colIban
         // 
         colIban.Text = "IBAN";
         // 
         // btnAdd
         // 
         btnAdd.Dock = DockStyle.Fill;
         btnAdd.Image = Resources.btnAdd;
         btnAdd.Location = new Point(393, 243);
         btnAdd.Name = "btnAdd";
         btnAdd.Size = new Size(24, 24);
         btnAdd.TabIndex = 1;
         btnAdd.UseVisualStyleBackColor = true;
         btnAdd.Click += OnClickedAdd;
         // 
         // btnEdit
         // 
         btnEdit.Dock = DockStyle.Fill;
         btnEdit.Image = Resources.btnEdit;
         btnEdit.Location = new Point(363, 243);
         btnEdit.Name = "btnEdit";
         btnEdit.Size = new Size(24, 24);
         btnEdit.TabIndex = 2;
         btnEdit.UseVisualStyleBackColor = true;
         btnEdit.Click += OnClickedEdit;
         // 
         // btnDel
         // 
         btnDel.Dock = DockStyle.Fill;
         btnDel.Image = Resources.btnDel;
         btnDel.Location = new Point(333, 243);
         btnDel.Name = "btnDel";
         btnDel.Size = new Size(24, 24);
         btnDel.TabIndex = 3;
         btnDel.UseVisualStyleBackColor = true;
         btnDel.Click += OnClickedDel;
         // 
         // KontenUebersicht
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(tableLayoutPanel1);
         Name = "KontenUebersicht";
         Size = new Size(420, 270);
         tableLayoutPanel1.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private ListView lstKonten;
      private Button btnAdd;
      private Button btnEdit;
      private Button btnDel;
      private ColumnHeader colName;
      private ColumnHeader colIban;
   }
}
