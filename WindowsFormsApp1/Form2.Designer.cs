namespace WindowsFormsApp1
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DobavqneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PotrebiteliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KnigiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AvtoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZaemaniqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxSelect = new System.Windows.Forms.ListBox();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.buttonDeleteRecord = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DobavqneToolStripMenuItem,
            this.PotrebiteliToolStripMenuItem,
            this.KnigiToolStripMenuItem,
            this.AvtoriToolStripMenuItem,
            this.ZaemaniqToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1163, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DobavqneToolStripMenuItem
            // 
            this.DobavqneToolStripMenuItem.Name = "DobavqneToolStripMenuItem";
            this.DobavqneToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.DobavqneToolStripMenuItem.Text = "Добавяне";
            this.DobavqneToolStripMenuItem.Click += new System.EventHandler(this.DobavqneToolStripMenuItem_Click);
            // 
            // PotrebiteliToolStripMenuItem
            // 
            this.PotrebiteliToolStripMenuItem.Name = "PotrebiteliToolStripMenuItem";
            this.PotrebiteliToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.PotrebiteliToolStripMenuItem.Text = "Потребители";
            this.PotrebiteliToolStripMenuItem.Click += new System.EventHandler(this.PotrebiteliToolStripMenuItem_Click);
            // 
            // KnigiToolStripMenuItem
            // 
            this.KnigiToolStripMenuItem.Name = "KnigiToolStripMenuItem";
            this.KnigiToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.KnigiToolStripMenuItem.Text = "Книги";
            this.KnigiToolStripMenuItem.Click += new System.EventHandler(this.KnigiToolStripMenuItem_Click);
            // 
            // AvtoriToolStripMenuItem
            // 
            this.AvtoriToolStripMenuItem.Name = "AvtoriToolStripMenuItem";
            this.AvtoriToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.AvtoriToolStripMenuItem.Text = "Автори";
            this.AvtoriToolStripMenuItem.Click += new System.EventHandler(this.AvtoriToolStripMenuItem_Click);
            // 
            // ZaemaniqToolStripMenuItem
            // 
            this.ZaemaniqToolStripMenuItem.Name = "ZaemaniqToolStripMenuItem";
            this.ZaemaniqToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.ZaemaniqToolStripMenuItem.Text = "Заемания";
            this.ZaemaniqToolStripMenuItem.Click += new System.EventHandler(this.ZaemaniqToolStripMenuItem_Click);
            // 
            // listBoxSelect
            // 
            this.listBoxSelect.FormattingEnabled = true;
            this.listBoxSelect.ItemHeight = 16;
            this.listBoxSelect.Location = new System.Drawing.Point(31, 42);
            this.listBoxSelect.Name = "listBoxSelect";
            this.listBoxSelect.Size = new System.Drawing.Size(333, 724);
            this.listBoxSelect.TabIndex = 1;
            this.listBoxSelect.SelectedIndexChanged += new System.EventHandler(this.listBoxSelect_SelectedIndexChanged);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 16;
            this.listBoxInfo.Location = new System.Drawing.Point(456, 42);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(333, 724);
            this.listBoxInfo.TabIndex = 2;
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Location = new System.Drawing.Point(859, 128);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(238, 98);
            this.buttonDeleteRecord.TabIndex = 3;
            this.buttonDeleteRecord.Text = "Изтриване";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Visible = false;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.buttonDeleteRecord_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 805);
            this.Controls.Add(this.buttonDeleteRecord);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.listBoxSelect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Библиотека";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PotrebiteliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KnigiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AvtoriToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxSelect;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.ToolStripMenuItem DobavqneToolStripMenuItem;
        private System.Windows.Forms.Button buttonDeleteRecord;
        private System.Windows.Forms.ToolStripMenuItem ZaemaniqToolStripMenuItem;
    }
}