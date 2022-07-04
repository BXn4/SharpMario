namespace SharpMario
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
            this.components = new System.ComponentModel.Container();
            this.checker = new System.Windows.Forms.Timer(this.components);
            this.keycheck = new System.Windows.Forms.TextBox();
            this.selected = new System.Windows.Forms.PictureBox();
            this.config = new System.Windows.Forms.PictureBox();
            this.controls = new System.Windows.Forms.PictureBox();
            this.startgame = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.PictureBox();
            this.controlsscreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.config)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startgame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlsscreen)).BeginInit();
            this.SuspendLayout();
            // 
            // checker
            // 
            this.checker.Enabled = true;
            this.checker.Tick += new System.EventHandler(this.checker_Tick);
            // 
            // keycheck
            // 
            this.keycheck.BackColor = System.Drawing.Color.Black;
            this.keycheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keycheck.Cursor = System.Windows.Forms.Cursors.Default;
            this.keycheck.ForeColor = System.Drawing.SystemColors.WindowText;
            this.keycheck.Location = new System.Drawing.Point(12, 12);
            this.keycheck.Name = "keycheck";
            this.keycheck.Size = new System.Drawing.Size(100, 13);
            this.keycheck.TabIndex = 5;
            this.keycheck.TextChanged += new System.EventHandler(this.keycheck_TextChanged);
            this.keycheck.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keycheck_KeyUp);
            // 
            // selected
            // 
            this.selected.Location = new System.Drawing.Point(243, 208);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(34, 29);
            this.selected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selected.TabIndex = 4;
            this.selected.TabStop = false;
            // 
            // config
            // 
            this.config.Location = new System.Drawing.Point(278, 335);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(235, 30);
            this.config.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.config.TabIndex = 3;
            this.config.TabStop = false;
            // 
            // controls
            // 
            this.controls.Location = new System.Drawing.Point(278, 269);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(235, 27);
            this.controls.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.controls.TabIndex = 2;
            this.controls.TabStop = false;
            // 
            // startgame
            // 
            this.startgame.Location = new System.Drawing.Point(278, 210);
            this.startgame.Name = "startgame";
            this.startgame.Size = new System.Drawing.Size(250, 30);
            this.startgame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.startgame.TabIndex = 1;
            this.startgame.TabStop = false;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(200, 55);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(390, 90);
            this.title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.title.TabIndex = 0;
            this.title.TabStop = false;
            this.title.Click += new System.EventHandler(this.spmariobros_Click);
            // 
            // controlsscreen
            // 
            this.controlsscreen.Location = new System.Drawing.Point(2, 2);
            this.controlsscreen.Name = "controlsscreen";
            this.controlsscreen.Size = new System.Drawing.Size(779, 457);
            this.controlsscreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.controlsscreen.TabIndex = 6;
            this.controlsscreen.TabStop = false;
            this.controlsscreen.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.controlsscreen);
            this.Controls.Add(this.keycheck);
            this.Controls.Add(this.selected);
            this.Controls.Add(this.config);
            this.Controls.Add(this.controls);
            this.Controls.Add(this.startgame);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpMario";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.config)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startgame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlsscreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox title;
        private System.Windows.Forms.PictureBox startgame;
        private System.Windows.Forms.PictureBox controls;
        private System.Windows.Forms.PictureBox config;
        private System.Windows.Forms.PictureBox selected;
        private System.Windows.Forms.Timer checker;
        private System.Windows.Forms.TextBox keycheck;
        private System.Windows.Forms.PictureBox controlsscreen;
    }
}

