namespace Client
{
    partial class TianQi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TianQi));
            this.Wt = new System.Windows.Forms.Panel();
            this.Tq = new Client.TextBox_tm();
            this.Wt.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wt
            // 
            this.Wt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Wt.BackgroundImage")));
            this.Wt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Wt.Controls.Add(this.Tq);
            this.Wt.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Wt.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Wt.Location = new System.Drawing.Point(1, 2);
            this.Wt.Name = "Wt";
            this.Wt.Size = new System.Drawing.Size(361, 274);
            this.Wt.TabIndex = 46;
            this.Wt.Paint += new System.Windows.Forms.PaintEventHandler(this.Wt_Paint);
            // 
            // Tq
            // 
            this.Tq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tq.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tq.ForeColor = System.Drawing.Color.DimGray;
            this.Tq.Location = new System.Drawing.Point(36, 38);
            this.Tq.Multiline = true;
            this.Tq.Name = "Tq";
            this.Tq.ReadOnly = true;
            this.Tq.Size = new System.Drawing.Size(265, 175);
            this.Tq.TabIndex = 0;
            // 
            // TianQi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(360, 277);
            this.Controls.Add(this.Wt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TianQi";
            this.Text = "TianQi";
            this.Load += new System.EventHandler(this.TianQi_Load);
            this.Wt.ResumeLayout(false);
            this.Wt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Wt;
        private TextBox_tm Tq;
    }
}