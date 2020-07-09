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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CATIA_AutoHole));
            this.DrawHole_A = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HoleType = new System.Windows.Forms.GroupBox();
            this.TPTPI = new System.Windows.Forms.CheckBox();
            this.PTPTI = new System.Windows.Forms.CheckBox();
            this.PTPI = new System.Windows.Forms.CheckBox();
            this.TPTPN = new System.Windows.Forms.CheckBox();
            this.PTPTN = new System.Windows.Forms.CheckBox();
            this.PTPN = new System.Windows.Forms.CheckBox();
            this.ContinueWork = new System.Windows.Forms.CheckBox();
            this.AbortHole = new System.Windows.Forms.CheckBox();
            this.AutoBolt = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.HoleType.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawHole_A
            // 
            this.DrawHole_A.Location = new System.Drawing.Point(11, 18);
            this.DrawHole_A.Name = "DrawHole_A";
            this.DrawHole_A.Size = new System.Drawing.Size(150, 61);
            this.DrawHole_A.TabIndex = 0;
            this.DrawHole_A.Text = "执行打孔";
            this.DrawHole_A.UseVisualStyleBackColor = true;
            this.DrawHole_A.Click += new System.EventHandler(this.DrawHole_A_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "M8",
            "M10",
            "M12",
            "M6",
            "M5"});
            this.comboBox1.Location = new System.Drawing.Point(11, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // HoleType
            // 
            this.HoleType.Controls.Add(this.TPTPI);
            this.HoleType.Controls.Add(this.PTPTI);
            this.HoleType.Controls.Add(this.PTPI);
            this.HoleType.Controls.Add(this.TPTPN);
            this.HoleType.Controls.Add(this.PTPTN);
            this.HoleType.Controls.Add(this.PTPN);
            this.HoleType.Location = new System.Drawing.Point(168, 12);
            this.HoleType.Name = "HoleType";
            this.HoleType.Size = new System.Drawing.Size(415, 100);
            this.HoleType.TabIndex = 2;
            this.HoleType.TabStop = false;
            this.HoleType.Text = "类型设置";
            // 
            // TPTPI
            // 
            this.TPTPI.AutoSize = true;
            this.TPTPI.Location = new System.Drawing.Point(278, 67);
            this.TPTPI.Name = "TPTPI";
            this.TPTPI.Size = new System.Drawing.Size(120, 16);
            this.TPTPI.TabIndex = 0;
            this.TPTPI.Text = "过销过销【沉头】";
            this.TPTPI.UseVisualStyleBackColor = true;
            // 
            // PTPTI
            // 
            this.PTPTI.AutoSize = true;
            this.PTPTI.Location = new System.Drawing.Point(136, 67);
            this.PTPTI.Name = "PTPTI";
            this.PTPTI.Size = new System.Drawing.Size(120, 16);
            this.PTPTI.TabIndex = 0;
            this.PTPTI.Text = "销过销过【沉头】";
            this.PTPTI.UseVisualStyleBackColor = true;
            // 
            // PTPI
            // 
            this.PTPI.AutoSize = true;
            this.PTPI.Location = new System.Drawing.Point(6, 67);
            this.PTPI.Name = "PTPI";
            this.PTPI.Size = new System.Drawing.Size(108, 16);
            this.PTPI.TabIndex = 0;
            this.PTPI.Text = "销过销【沉头】";
            this.PTPI.UseVisualStyleBackColor = true;
            // 
            // TPTPN
            // 
            this.TPTPN.AutoSize = true;
            this.TPTPN.Location = new System.Drawing.Point(278, 29);
            this.TPTPN.Name = "TPTPN";
            this.TPTPN.Size = new System.Drawing.Size(120, 16);
            this.TPTPN.TabIndex = 0;
            this.TPTPN.Text = "过销过销【普通】";
            this.TPTPN.UseVisualStyleBackColor = true;
            // 
            // PTPTN
            // 
            this.PTPTN.AutoSize = true;
            this.PTPTN.Location = new System.Drawing.Point(136, 29);
            this.PTPTN.Name = "PTPTN";
            this.PTPTN.Size = new System.Drawing.Size(120, 16);
            this.PTPTN.TabIndex = 0;
            this.PTPTN.Text = "销过销过【普通】";
            this.PTPTN.UseVisualStyleBackColor = true;
            // 
            // PTPN
            // 
            this.PTPN.AutoSize = true;
            this.PTPN.Location = new System.Drawing.Point(6, 29);
            this.PTPN.Name = "PTPN";
            this.PTPN.Size = new System.Drawing.Size(108, 16);
            this.PTPN.TabIndex = 0;
            this.PTPN.Text = "销过销【普通】";
            this.PTPN.UseVisualStyleBackColor = true;
            // 
            // ContinueWork
            // 
            this.ContinueWork.AutoSize = true;
            this.ContinueWork.Location = new System.Drawing.Point(174, 118);
            this.ContinueWork.Name = "ContinueWork";
            this.ContinueWork.Size = new System.Drawing.Size(72, 16);
            this.ContinueWork.TabIndex = 3;
            this.ContinueWork.Text = "持续选择";
            this.ContinueWork.UseVisualStyleBackColor = true;
            // 
            // AbortHole
            // 
            this.AbortHole.AutoSize = true;
            this.AbortHole.Checked = true;
            this.AbortHole.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AbortHole.Location = new System.Drawing.Point(304, 118);
            this.AbortHole.Name = "AbortHole";
            this.AbortHole.Size = new System.Drawing.Size(84, 16);
            this.AbortHole.TabIndex = 3;
            this.AbortHole.Text = "关联孔连打";
            this.AbortHole.UseVisualStyleBackColor = true;
            // 
            // AutoBolt
            // 
            this.AutoBolt.AutoSize = true;
            this.AutoBolt.Location = new System.Drawing.Point(446, 118);
            this.AutoBolt.Name = "AutoBolt";
            this.AutoBolt.Size = new System.Drawing.Size(96, 16);
            this.AutoBolt.TabIndex = 3;
            this.AutoBolt.Text = "自动螺栓垫片";
            this.AutoBolt.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CATIA_AutoHole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 161);
            this.Controls.Add(this.AutoBolt);
            this.Controls.Add(this.AbortHole);
            this.Controls.Add(this.ContinueWork);
            this.Controls.Add(this.HoleType);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DrawHole_A);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(620, 200);
            this.MinimumSize = new System.Drawing.Size(620, 200);
            this.Name = "CATIA_AutoHole";
            this.Text = "CATIA_AutoHole";
            this.HoleType.ResumeLayout(false);
            this.HoleType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DrawHole_A;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox HoleType;
        private System.Windows.Forms.CheckBox PTPI;
        private System.Windows.Forms.CheckBox PTPN;
        private System.Windows.Forms.CheckBox TPTPI;
        private System.Windows.Forms.CheckBox PTPTI;
        private System.Windows.Forms.CheckBox TPTPN;
        private System.Windows.Forms.CheckBox PTPTN;
        private System.Windows.Forms.CheckBox ContinueWork;
        private System.Windows.Forms.CheckBox AbortHole;
        private System.Windows.Forms.CheckBox AutoBolt;
        private System.Windows.Forms.Timer timer;
    }
}