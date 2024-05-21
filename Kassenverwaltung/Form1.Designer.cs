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
         menuStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // menuStrip1
         // 
         menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem });
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
         neuToolStripMenuItem.Size = new Size(180, 22);
         neuToolStripMenuItem.Text = "Neu";
         neuToolStripMenuItem.Click += OnMenuStrip_Neu;
         // 
         // öffnenToolStripMenuItem
         // 
         öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
         öffnenToolStripMenuItem.Size = new Size(180, 22);
         öffnenToolStripMenuItem.Text = "Öffnen";
         öffnenToolStripMenuItem.Click += OnMenuStrip_Oeffnen;
         // 
         // Form1
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(800, 450);
         Controls.Add(menuStrip1);
         Icon = (Icon)resources.GetObject("$this.Icon");
         MainMenuStrip = menuStrip1;
         Name = "Form1";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "Kassenverwaltung";
         menuStrip1.ResumeLayout(false);
         menuStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private MenuStrip menuStrip1;
      private ToolStripMenuItem dateiToolStripMenuItem;
      private ToolStripMenuItem neuToolStripMenuItem;
      private ToolStripMenuItem öffnenToolStripMenuItem;
   }
}
