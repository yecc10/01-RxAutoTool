namespace AutoDeskLine_ToPlant
{
    partial class CatiaQuickTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatiaQuickTool));
            this.TryRead = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SDelmia = new System.Windows.Forms.RadioButton();
            this.SCATIA = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TryRead
            // 
            this.TryRead.Location = new System.Drawing.Point(425, 205);
            this.TryRead.Name = "TryRead";
            this.TryRead.Size = new System.Drawing.Size(118, 44);
            this.TryRead.TabIndex = 0;
            this.TryRead.Text = "读取数据";
            this.TryRead.UseVisualStyleBackColor = true;
            this.TryRead.Click += new System.EventHandler(this.TryRead_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SDelmia);
            this.groupBox1.Controls.Add(this.SCATIA);
            this.groupBox1.Location = new System.Drawing.Point(12, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目标设定";
            // 
            // SDelmia
            // 
            this.SDelmia.AutoSize = true;
            this.SDelmia.Checked = true;
            this.SDelmia.Location = new System.Drawing.Point(65, 20);
            this.SDelmia.Name = "SDelmia";
            this.SDelmia.Size = new System.Drawing.Size(59, 16);
            this.SDelmia.TabIndex = 1;
            this.SDelmia.TabStop = true;
            this.SDelmia.Text = "DELMIA";
            this.SDelmia.UseVisualStyleBackColor = true;
            // 
            // SCATIA
            // 
            this.SCATIA.AutoSize = true;
            this.SCATIA.Location = new System.Drawing.Point(6, 20);
            this.SCATIA.Name = "SCATIA";
            this.SCATIA.Size = new System.Drawing.Size(53, 16);
            this.SCATIA.TabIndex = 0;
            this.SCATIA.Text = "CATIA";
            this.SCATIA.UseVisualStyleBackColor = true;
            // 
            // CatiaQuickTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(555, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TryRead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CatiaQuickTool";
            this.Text = "CatiaQuickTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CatiaQuickTool_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TryRead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SDelmia;
        private System.Windows.Forms.RadioButton SCATIA;
    }
}