namespace D3Sharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
        
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartD3GSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartBNetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configD3GSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(10, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 527);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "D3GS";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(6, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox1.Size = new System.Drawing.Size(770, 505);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.restartD3GSToolStripMenuItem,
            this.restartBNetToolStripMenuItem,
            this.configD3GSToolStripMenuItem,
            this.configMapsToolStripMenuItem,
            this.playMusicToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restartD3GSToolStripMenuItem
            // 
            this.restartD3GSToolStripMenuItem.Name = "restartD3GSToolStripMenuItem";
            this.restartD3GSToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.restartD3GSToolStripMenuItem.Text = "Restart D3GS";
            this.restartD3GSToolStripMenuItem.Click += new System.EventHandler(this.restartD3GSToolStripMenuItem_Click);
            // 
            // restartBNetToolStripMenuItem
            // 
            this.restartBNetToolStripMenuItem.Name = "restartBNetToolStripMenuItem";
            this.restartBNetToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.restartBNetToolStripMenuItem.Text = "Restart BNet";
            this.restartBNetToolStripMenuItem.Click += new System.EventHandler(this.restartBNetToolStripMenuItem_Click);
            // 
            // configD3GSToolStripMenuItem
            // 
            this.configD3GSToolStripMenuItem.Name = "configD3GSToolStripMenuItem";
            this.configD3GSToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.configD3GSToolStripMenuItem.Text = "Config D3GS";
            this.configD3GSToolStripMenuItem.Click += new System.EventHandler(this.configD3GSToolStripMenuItem_Click);
            // 
            // configMapsToolStripMenuItem
            // 
            this.configMapsToolStripMenuItem.Name = "configMapsToolStripMenuItem";
            this.configMapsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.configMapsToolStripMenuItem.Text = "Config Maps";
            this.configMapsToolStripMenuItem.Click += new System.EventHandler(this.configMapsToolStripMenuItem_Click);
            // 
            // playMusicToolStripMenuItem
            // 
            this.playMusicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMusicToolStripMenuItem});
            this.playMusicToolStripMenuItem.Name = "playMusicToolStripMenuItem";
            this.playMusicToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.playMusicToolStripMenuItem.Text = "Music";
            // 
            // loadMusicToolStripMenuItem
            // 
            this.loadMusicToolStripMenuItem.Name = "loadMusicToolStripMenuItem";
            this.loadMusicToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadMusicToolStripMenuItem.Text = "Load Music";
            this.loadMusicToolStripMenuItem.Click += new System.EventHandler(this.loadMusicToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 565);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(728, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(746, 565);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 589);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "D3Mighty - By God601";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem configD3GSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartD3GSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartBNetToolStripMenuItem;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ToolStripMenuItem playMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMusicToolStripMenuItem;

    }
}