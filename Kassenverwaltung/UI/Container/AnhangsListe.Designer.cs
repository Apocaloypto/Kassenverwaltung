namespace Kassenverwaltung.UI.Container
{
   partial class AnhangsListe
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
         components = new System.ComponentModel.Container();
         tableLayoutPanel1 = new TableLayoutPanel();
         btnDel = new Button();
         btnMod = new Button();
         btnAdd = new Button();
         lstAnhaenge = new ListView();
         colDateiname = new ColumnHeader();
         colPfad = new ColumnHeader();
         colDateityp = new ColumnHeader();
         btnDetails = new Button();
         btnExport = new Button();
         buttonToolTips = new ToolTip(components);
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.ColumnCount = 6;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Controls.Add(btnDel, 1, 1);
         tableLayoutPanel1.Controls.Add(btnMod, 2, 1);
         tableLayoutPanel1.Controls.Add(btnAdd, 5, 1);
         tableLayoutPanel1.Controls.Add(lstAnhaenge, 0, 0);
         tableLayoutPanel1.Controls.Add(btnDetails, 4, 1);
         tableLayoutPanel1.Controls.Add(btnExport, 3, 1);
         tableLayoutPanel1.Dock = DockStyle.Fill;
         tableLayoutPanel1.Location = new Point(0, 0);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 2;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
         tableLayoutPanel1.Size = new Size(391, 266);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // btnDel
         // 
         btnDel.Dock = DockStyle.Fill;
         btnDel.Image = Resources.btnDel;
         btnDel.Location = new Point(244, 239);
         btnDel.Name = "btnDel";
         btnDel.Size = new Size(24, 24);
         btnDel.TabIndex = 0;
         btnDel.UseVisualStyleBackColor = true;
         btnDel.Click += OnClickedDel;
         // 
         // btnMod
         // 
         btnMod.Dock = DockStyle.Fill;
         btnMod.Image = Resources.btnEdit;
         btnMod.Location = new Point(274, 239);
         btnMod.Name = "btnMod";
         btnMod.Size = new Size(24, 24);
         btnMod.TabIndex = 1;
         btnMod.UseVisualStyleBackColor = true;
         btnMod.Click += OnClickedEdit;
         // 
         // btnAdd
         // 
         btnAdd.Dock = DockStyle.Fill;
         btnAdd.Image = Resources.btnAdd;
         btnAdd.Location = new Point(364, 239);
         btnAdd.Name = "btnAdd";
         btnAdd.Size = new Size(24, 24);
         btnAdd.TabIndex = 2;
         btnAdd.UseVisualStyleBackColor = true;
         btnAdd.Click += OnClickedAdd;
         // 
         // lstAnhaenge
         // 
         lstAnhaenge.Columns.AddRange(new ColumnHeader[] { colDateiname, colPfad, colDateityp });
         tableLayoutPanel1.SetColumnSpan(lstAnhaenge, 6);
         lstAnhaenge.Dock = DockStyle.Fill;
         lstAnhaenge.FullRowSelect = true;
         lstAnhaenge.Location = new Point(3, 3);
         lstAnhaenge.Name = "lstAnhaenge";
         lstAnhaenge.Size = new Size(385, 230);
         lstAnhaenge.TabIndex = 3;
         lstAnhaenge.UseCompatibleStateImageBehavior = false;
         lstAnhaenge.View = View.Details;
         lstAnhaenge.SelectedIndexChanged += OnSelectedIndexChanged;
         lstAnhaenge.DoubleClick += OnDoubleClick;
         // 
         // colDateiname
         // 
         colDateiname.Text = "Dateiname";
         // 
         // colPfad
         // 
         colPfad.Text = "Dateipfad";
         // 
         // colDateityp
         // 
         colDateityp.Text = "Dateityp";
         // 
         // btnDetails
         // 
         btnDetails.Dock = DockStyle.Fill;
         btnDetails.Image = Resources.btnDetails;
         btnDetails.Location = new Point(334, 239);
         btnDetails.Name = "btnDetails";
         btnDetails.Size = new Size(24, 24);
         btnDetails.TabIndex = 4;
         btnDetails.UseVisualStyleBackColor = true;
         btnDetails.Click += OnClickedDetails;
         // 
         // btnExport
         // 
         btnExport.Dock = DockStyle.Fill;
         btnExport.Image = Resources.btnExport;
         btnExport.Location = new Point(304, 239);
         btnExport.Name = "btnExport";
         btnExport.Size = new Size(24, 24);
         btnExport.TabIndex = 5;
         btnExport.UseVisualStyleBackColor = true;
         btnExport.Click += OnClickedExport;
         // 
         // AnhangsListe
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(tableLayoutPanel1);
         Name = "AnhangsListe";
         Size = new Size(391, 266);
         tableLayoutPanel1.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Button btnDel;
      private Button btnMod;
      private Button btnAdd;
      private ListView lstAnhaenge;
      private ColumnHeader colDateiname;
      private ColumnHeader colDateityp;
      private Button btnDetails;
      private ColumnHeader colPfad;
      private Button btnExport;
      private ToolTip buttonToolTips;
   }
}
