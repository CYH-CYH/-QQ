namespace Client
{
    partial class Y
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Y));
            this.firstErrow = new System.Windows.Forms.Panel();
            this.errorPsw = new System.Windows.Forms.Panel();
            this.gu = new System.Windows.Forms.Button();
            this.findPsw = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inputY = new System.Windows.Forms.RichTextBox();
            this.picY = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.firstErrow.SuspendLayout();
            this.errorPsw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picY)).BeginInit();
            this.SuspendLayout();
            // 
            // firstErrow
            // 
            this.firstErrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("firstErrow.BackgroundImage")));
            this.firstErrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.firstErrow.Controls.Add(this.errorPsw);
            this.firstErrow.Controls.Add(this.button1);
            this.firstErrow.Controls.Add(this.inputY);
            this.firstErrow.Controls.Add(this.picY);
            this.firstErrow.Location = new System.Drawing.Point(0, 81);
            this.firstErrow.Name = "firstErrow";
            this.firstErrow.Size = new System.Drawing.Size(427, 305);
            this.firstErrow.TabIndex = 3;
            // 
            // errorPsw
            // 
            this.errorPsw.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("errorPsw.BackgroundImage")));
            this.errorPsw.Controls.Add(this.gu);
            this.errorPsw.Controls.Add(this.findPsw);
            this.errorPsw.Location = new System.Drawing.Point(-2, 3);
            this.errorPsw.Name = "errorPsw";
            this.errorPsw.Size = new System.Drawing.Size(426, 301);
            this.errorPsw.TabIndex = 14;
            this.errorPsw.Visible = false;
            // 
            // gu
            // 
            this.gu.BackColor = System.Drawing.Color.Transparent;
            this.gu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gu.FlatAppearance.BorderSize = 0;
            this.gu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.gu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gu.Location = new System.Drawing.Point(337, 253);
            this.gu.Name = "gu";
            this.gu.Size = new System.Drawing.Size(81, 25);
            this.gu.TabIndex = 1;
            this.gu.UseVisualStyleBackColor = false;
            this.gu.Click += new System.EventHandler(this.gu_Click);
            // 
            // findPsw
            // 
            this.findPsw.BackColor = System.Drawing.Color.Transparent;
            this.findPsw.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.findPsw.FlatAppearance.BorderSize = 0;
            this.findPsw.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.findPsw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.findPsw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findPsw.Location = new System.Drawing.Point(251, 254);
            this.findPsw.Name = "findPsw";
            this.findPsw.Size = new System.Drawing.Size(85, 25);
            this.findPsw.TabIndex = 0;
            this.findPsw.UseVisualStyleBackColor = false;
            this.findPsw.Click += new System.EventHandler(this.findPsw_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(339, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputY
            // 
            this.inputY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputY.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputY.Location = new System.Drawing.Point(99, 124);
            this.inputY.MaxLength = 4;
            this.inputY.Name = "inputY";
            this.inputY.Size = new System.Drawing.Size(98, 32);
            this.inputY.TabIndex = 1;
            this.inputY.Text = "";
            this.inputY.TextChanged += new System.EventHandler(this.inputY_TextChanged);
            // 
            // picY
            // 
            this.picY.BackColor = System.Drawing.Color.White;
            this.picY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picY.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.picY.Location = new System.Drawing.Point(224, 127);
            this.picY.Name = "picY";
            this.picY.Size = new System.Drawing.Size(85, 29);
            this.picY.TabIndex = 0;
            this.picY.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Y
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Client.Properties.Resources._2020060500000001;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(424, 387);
            this.Controls.Add(this.firstErrow);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Brown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Y";
            this.Text = "Y";
            this.Load += new System.EventHandler(this.Y_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Y_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Y_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Y_MouseUp);
            this.firstErrow.ResumeLayout(false);
            this.errorPsw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel firstErrow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox inputY;
        private System.Windows.Forms.PictureBox picY;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel errorPsw;
        private System.Windows.Forms.Button gu;
        private System.Windows.Forms.Button findPsw;
    }
}