namespace AutoDeskLine_ToPlant
{
    partial class CATIA_AutoHole
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
            this.DrawHole_A = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawHole_A
            // 
            this.DrawHole_A.Location = new System.Drawing.Point(12, 12);
            this.DrawHole_A.Name = "DrawHole_A";
            this.DrawHole_A.Size = new System.Drawing.Size(120, 35);
            this.DrawHole_A.TabIndex = 0;
            this.DrawHole_A.Text = "支撑块";
            this.DrawHole_A.UseVisualStyleBackColor = true;
            this.DrawHole_A.Click += new System.EventHandler(this.DrawHole_A_Click);
            // 
            // CATIA_AutoHole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 117);
            this.Controls.Add(this.DrawHole_A);
            this.Name = "CATIA_AutoHole";
            this.Text = "CATIA_AutoHole";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DrawHole_A;
    }
}