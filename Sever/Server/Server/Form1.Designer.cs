namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Listten = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Listten
            // 
            this.Listten.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Listten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Listten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Listten.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Listten.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Listten.Location = new System.Drawing.Point(0, 0);
            this.Listten.Name = "Listten";
            this.Listten.ReadOnly = true;
            this.Listten.Size = new System.Drawing.Size(799, 407);
            this.Listten.TabIndex = 0;
            this.Listten.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 407);
            this.Controls.Add(this.Listten);
            this.Name = "Form1";
            this.Text = "服务器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Listten;
    }
}

