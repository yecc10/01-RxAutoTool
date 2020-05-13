﻿namespace AutoDeskLine_ToPlant
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(272, 76);
            this.Controls.Add(this.CreateFence);
            this.Controls.Add(this.CreateTrack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(288, 115);
            this.MinimumSize = new System.Drawing.Size(288, 115);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主入口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateTrack;
        private System.Windows.Forms.Button CreateFence;
    }
}