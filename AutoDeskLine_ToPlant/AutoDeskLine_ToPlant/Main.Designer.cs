namespace AutoDeskLine_ToPlant
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.CreateTrack = new System.Windows.Forms.Button();
            this.CreateFence = new System.Windows.Forms.Button();
            this.BollToAix = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateTrack
            // 
            this.CreateTrack.Location = new System.Drawing.Point(5, 12);
            this.CreateTrack.Name = "CreateTrack";
            this.CreateTrack.Size = new System.Drawing.Size(121, 48);
            this.CreateTrack.TabIndex = 0;
            this.CreateTrack.Text = "路径创建";
            this.CreateTrack.UseVisualStyleBackColor = true;
            this.CreateTrack.Click += new System.EventHandler(this.CreateTrack_Click);
            // 
            // CreateFence
            // 
            this.CreateFence.Location = new System.Drawing.Point(132, 12);
            this.CreateFence.Name = "CreateFence";
            this.CreateFence.Size = new System.Drawing.Size(121, 48);
            this.CreateFence.TabIndex = 0;
            this.CreateFence.Text = "围栏创建";
            this.CreateFence.UseVisualStyleBackColor = true;
            this.CreateFence.Click += new System.EventHandler(this.CreateFence_Click);
            // 
            // BollToAix
            // 
            this.BollToAix.Location = new System.Drawing.Point(259, 12);
            this.BollToAix.Name = "BollToAix";
            this.BollToAix.Size = new System.Drawing.Size(121, 48);
            this.BollToAix.TabIndex = 0;
            this.BollToAix.Text = "球弧转坐标";
            this.BollToAix.UseVisualStyleBackColor = true;
            this.BollToAix.Click += new System.EventHandler(this.BollToAix_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(389, 76);
            this.Controls.Add(this.BollToAix);
            this.Controls.Add(this.CreateFence);
            this.Controls.Add(this.CreateTrack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(288, 115);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主入口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateTrack;
        private System.Windows.Forms.Button CreateFence;
        private System.Windows.Forms.Button BollToAix;
    }
}