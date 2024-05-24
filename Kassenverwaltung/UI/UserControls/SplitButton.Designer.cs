namespace Kassenverwaltung.UI.UserControls
{
   partial class SplitButton
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
         btnMain = new Button();
         btnContext = new Button();
         tableLayoutPanel1.SuspendLayout();
         SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         tableLayoutPanel1.ColumnCount = 2;
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
         tableLayoutPanel1.Controls.Add(btnMain, 0, 0);
         tableLayoutPanel1.Controls.Add(btnContext, 1, 0);
         tableLayoutPanel1.Dock = DockStyle.Fill;
         tableLayoutPanel1.Location = new Point(0, 0);
         tableLayoutPanel1.Margin = new Padding(0);
         tableLayoutPanel1.Name = "tableLayoutPanel1";
         tableLayoutPanel1.RowCount = 1;
         tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
         tableLayoutPanel1.Size = new Size(118, 31);
         tableLayoutPanel1.TabIndex = 0;
         // 
         // btnMain
         // 
         btnMain.Dock = DockStyle.Fill;
         btnMain.Location = new Point(0, 0);
         btnMain.Margin = new Padding(0);
         btnMain.Name = "btnMain";
         btnMain.Size = new Size(100, 31);
         btnMain.TabIndex = 0;
         btnMain.UseVisualStyleBackColor = true;
         btnMain.Click += OnMainButtonClicked;
         // 
         // btnContext
         // 
         btnContext.Dock = DockStyle.Fill;
         btnContext.Location = new Point(100, 0);
         btnContext.Margin = new Padding(0);
         btnContext.Name = "btnContext";
         btnContext.Size = new Size(18, 31);
         btnContext.TabIndex = 1;
         btnContext.Text = "▼";
         btnContext.UseCompatibleTextRendering = true;
         btnContext.UseVisualStyleBackColor = true;
         btnContext.Click += OnClickedContextButton;
         // 
         // SplitButton
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         Controls.Add(tableLayoutPanel1);
         Name = "SplitButton";
         Size = new Size(118, 31);
         tableLayoutPanel1.ResumeLayout(false);
         ResumeLayout(false);
      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Button btnMain;
      private Button btnContext;
   }
}
