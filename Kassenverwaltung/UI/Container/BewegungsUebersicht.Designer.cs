namespace Kassenverwaltung.UI.Container
{
   partial class BewegungsUebersicht
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
         splitContainer1 = new SplitContainer();
         groupBox1 = new GroupBox();
         groupBox2 = new GroupBox();
         bewegungsListe = new BewegungsListe();
         ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
         splitContainer1.Panel1.SuspendLayout();
         splitContainer1.Panel2.SuspendLayout();
         splitContainer1.SuspendLayout();
         groupBox1.SuspendLayout();
         SuspendLayout();
         // 
         // splitContainer1
         // 
         splitContainer1.Dock = DockStyle.Fill;
         splitContainer1.Location = new Point(0, 0);
         splitContainer1.Name = "splitContainer1";
         splitContainer1.Orientation = Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         splitContainer1.Panel1.Controls.Add(groupBox1);
         splitContainer1.Panel1.Padding = new Padding(3);
         // 
         // splitContainer1.Panel2
         // 
         splitContainer1.Panel2.Controls.Add(groupBox2);
         splitContainer1.Panel2.Padding = new Padding(3);
         splitContainer1.Size = new Size(463, 298);
         splitContainer1.SplitterDistance = 137;
         splitContainer1.TabIndex = 0;
         // 
         // groupBox1
         // 
         groupBox1.Controls.Add(bewegungsListe);
         groupBox1.Dock = DockStyle.Fill;
         groupBox1.Location = new Point(3, 3);
         groupBox1.Name = "groupBox1";
         groupBox1.Size = new Size(457, 131);
         groupBox1.TabIndex = 0;
         groupBox1.TabStop = false;
         groupBox1.Text = "Bewegungen";
         // 
         // groupBox2
         // 
         groupBox2.Dock = DockStyle.Fill;
         groupBox2.Location = new Point(3, 3);
         groupBox2.Name = "groupBox2";
         groupBox2.Size = new Size(457, 151);
         groupBox2.TabIndex = 0;
         groupBox2.TabStop = false;
         groupBox2.Text = "Anhänge";
         // 
         // bewegungsListe
         // 
         bewegungsListe.Dock = DockStyle.Fill;
         bewegungsListe.Location = new Point(3, 19);
         bewegungsListe.Name = "bewegungsListe";
         bewegungsListe.Size = new Size(451, 109);
         bewegungsListe.TabIndex = 0;
         // 
         // BewegungsUebersicht
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(splitContainer1);
         Name = "BewegungsUebersicht";
         Size = new Size(463, 298);
         splitContainer1.Panel1.ResumeLayout(false);
         splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
         splitContainer1.ResumeLayout(false);
         groupBox1.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private SplitContainer splitContainer1;
      private GroupBox groupBox1;
      private GroupBox groupBox2;
      private BewegungsListe bewegungsListe;
   }
}
