namespace Kassenverwaltung
{
   partial class Form1
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
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
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         menuStrip1 = new MenuStrip();
         dateiToolStripMenuItem = new ToolStripMenuItem();
         neuToolStripMenuItem = new ToolStripMenuItem();
         öffnenToolStripMenuItem = new ToolStripMenuItem();
         stammdatenToolStripMenuItem = new ToolStripMenuItem();
         kategorienToolStripMenuItem = new ToolStripMenuItem();
         importToolStripMenuItem = new ToolStripMenuItem();
         stammdatenimportToolStripMenuItem = new ToolStripMenuItem();
         splitContainer1 = new SplitContainer();
         groupBox1 = new GroupBox();
         kontenUebersicht = new UI.Container.KontenUebersicht();
         bewegungsUebersicht = new UI.Container.BewegungsUebersicht();
         toolStripSeparator1 = new ToolStripSeparator();
         bewegungsdatenimportToolStripMenuItem = new ToolStripMenuItem();
         menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
         splitContainer1.Panel1.SuspendLayout();
         splitContainer1.Panel2.SuspendLayout();
         splitContainer1.SuspendLayout();
         groupBox1.SuspendLayout();
         SuspendLayout();
         // 
         // menuStrip1
         // 
         menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, stammdatenToolStripMenuItem, importToolStripMenuItem });
         menuStrip1.Location = new Point(0, 0);
         menuStrip1.Name = "menuStrip1";
         menuStrip1.Size = new Size(800, 24);
         menuStrip1.TabIndex = 0;
         menuStrip1.Text = "menuStrip1";
         // 
         // dateiToolStripMenuItem
         // 
         dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { neuToolStripMenuItem, öffnenToolStripMenuItem });
         dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
         dateiToolStripMenuItem.Size = new Size(46, 20);
         dateiToolStripMenuItem.Text = "Datei";
         // 
         // neuToolStripMenuItem
         // 
         neuToolStripMenuItem.Name = "neuToolStripMenuItem";
         neuToolStripMenuItem.Size = new Size(111, 22);
         neuToolStripMenuItem.Text = "Neu";
         neuToolStripMenuItem.Click += OnMenuStrip_Neu;
         // 
         // öffnenToolStripMenuItem
         // 
         öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
         öffnenToolStripMenuItem.Size = new Size(111, 22);
         öffnenToolStripMenuItem.Text = "Öffnen";
         öffnenToolStripMenuItem.Click += OnMenuStrip_Oeffnen;
         // 
         // stammdatenToolStripMenuItem
         // 
         stammdatenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kategorienToolStripMenuItem });
         stammdatenToolStripMenuItem.Name = "stammdatenToolStripMenuItem";
         stammdatenToolStripMenuItem.Size = new Size(87, 20);
         stammdatenToolStripMenuItem.Text = "Stammdaten";
         // 
         // kategorienToolStripMenuItem
         // 
         kategorienToolStripMenuItem.Name = "kategorienToolStripMenuItem";
         kategorienToolStripMenuItem.Size = new Size(131, 22);
         kategorienToolStripMenuItem.Text = "Kategorien";
         kategorienToolStripMenuItem.Click += OnKategorienClicked;
         // 
         // importToolStripMenuItem
         // 
         importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stammdatenimportToolStripMenuItem, toolStripSeparator1, bewegungsdatenimportToolStripMenuItem });
         importToolStripMenuItem.Name = "importToolStripMenuItem";
         importToolStripMenuItem.Size = new Size(55, 20);
         importToolStripMenuItem.Text = "Import";
         // 
         // stammdatenimportToolStripMenuItem
         // 
         stammdatenimportToolStripMenuItem.Name = "stammdatenimportToolStripMenuItem";
         stammdatenimportToolStripMenuItem.Size = new Size(201, 22);
         stammdatenimportToolStripMenuItem.Text = "Stammdatenimport";
         stammdatenimportToolStripMenuItem.Click += OnMenuItem_Stammdatenimport;
         // 
         // splitContainer1
         // 
         splitContainer1.Dock = DockStyle.Fill;
         splitContainer1.Location = new Point(0, 24);
         splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         splitContainer1.Panel1.Controls.Add(groupBox1);
         splitContainer1.Panel1.Padding = new Padding(3);
         // 
         // splitContainer1.Panel2
         // 
         splitContainer1.Panel2.Controls.Add(bewegungsUebersicht);
         splitContainer1.Panel2.Padding = new Padding(3);
         splitContainer1.Size = new Size(800, 426);
         splitContainer1.SplitterDistance = 266;
         splitContainer1.TabIndex = 1;
         // 
         // groupBox1
         // 
         groupBox1.Controls.Add(kontenUebersicht);
         groupBox1.Dock = DockStyle.Fill;
         groupBox1.Location = new Point(3, 3);
         groupBox1.Name = "groupBox1";
         groupBox1.Size = new Size(260, 420);
         groupBox1.TabIndex = 0;
         groupBox1.TabStop = false;
         groupBox1.Text = "Konten";
         // 
         // kontenUebersicht
         // 
         kontenUebersicht.Dock = DockStyle.Fill;
         kontenUebersicht.Location = new Point(3, 19);
         kontenUebersicht.Name = "kontenUebersicht";
         kontenUebersicht.Size = new Size(254, 398);
         kontenUebersicht.TabIndex = 0;
         kontenUebersicht.SelectedKontoChanged += OnSelectedKontoChanged;
         // 
         // bewegungsUebersicht
         // 
         bewegungsUebersicht.Dock = DockStyle.Fill;
         bewegungsUebersicht.Location = new Point(3, 3);
         bewegungsUebersicht.Name = "bewegungsUebersicht";
         bewegungsUebersicht.Size = new Size(524, 420);
         bewegungsUebersicht.TabIndex = 0;
         // 
         // toolStripSeparator1
         // 
         toolStripSeparator1.Name = "toolStripSeparator1";
         toolStripSeparator1.Size = new Size(198, 6);
         // 
         // bewegungsdatenimportToolStripMenuItem
         // 
         bewegungsdatenimportToolStripMenuItem.Name = "bewegungsdatenimportToolStripMenuItem";
         bewegungsdatenimportToolStripMenuItem.Size = new Size(201, 22);
         bewegungsdatenimportToolStripMenuItem.Text = "Bewegungsdatenimport";
         bewegungsdatenimportToolStripMenuItem.Click += OnMenuItem_BewegungsImport;
         // 
         // Form1
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(800, 450);
         Controls.Add(splitContainer1);
         Controls.Add(menuStrip1);
         Icon = (Icon)resources.GetObject("$this.Icon");
         MainMenuStrip = menuStrip1;
         Name = "Form1";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "Kassenverwaltung";
         menuStrip1.ResumeLayout(false);
         menuStrip1.PerformLayout();
         splitContainer1.Panel1.ResumeLayout(false);
         splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
         splitContainer1.ResumeLayout(false);
         groupBox1.ResumeLayout(false);
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private MenuStrip menuStrip1;
      private ToolStripMenuItem dateiToolStripMenuItem;
      private ToolStripMenuItem neuToolStripMenuItem;
      private ToolStripMenuItem öffnenToolStripMenuItem;
      private SplitContainer splitContainer1;
      private GroupBox groupBox1;
      private UI.Container.KontenUebersicht kontenUebersicht;
      private UI.Container.BewegungsUebersicht bewegungsUebersicht;
      private ToolStripMenuItem stammdatenToolStripMenuItem;
      private ToolStripMenuItem kategorienToolStripMenuItem;
      private ToolStripMenuItem importToolStripMenuItem;
      private ToolStripMenuItem stammdatenimportToolStripMenuItem;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripMenuItem bewegungsdatenimportToolStripMenuItem;
   }
}
