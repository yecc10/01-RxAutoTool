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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatiaQuickTool));
            this.TryRead = new System.Windows.Forms.Button();
            this.KeepName = new System.Windows.Forms.CheckBox();
            this.OutToEXcel = new System.Windows.Forms.Button();
            this.BollToPoint = new System.Windows.Forms.Button();
            this.AutoHole = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.ReadCoord = new System.Windows.Forms.Button();
            this.ClearAllData = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TryRead
            // 
            this.TryRead.Location = new System.Drawing.Point(596, 345);
            this.TryRead.Name = "TryRead";
            this.TryRead.Size = new System.Drawing.Size(118, 44);
            this.TryRead.TabIndex = 0;
            this.TryRead.Text = "读取数据";
            this.TryRead.UseVisualStyleBackColor = true;
            this.TryRead.Click += new System.EventHandler(this.TryRead_Click);
            // 
            // KeepName
            // 
            this.KeepName.AutoSize = true;
            this.KeepName.Location = new System.Drawing.Point(25, 405);
            this.KeepName.Name = "KeepName";
            this.KeepName.Size = new System.Drawing.Size(96, 16);
            this.KeepName.TabIndex = 1;
            this.KeepName.Text = "保留现有名称";
            this.KeepName.UseVisualStyleBackColor = true;
            // 
            // OutToEXcel
            // 
            this.OutToEXcel.Location = new System.Drawing.Point(742, 345);
            this.OutToEXcel.Name = "OutToEXcel";
            this.OutToEXcel.Size = new System.Drawing.Size(118, 44);
            this.OutToEXcel.TabIndex = 2;
            this.OutToEXcel.Text = "导出EXCEL";
            this.OutToEXcel.UseVisualStyleBackColor = true;
            this.OutToEXcel.Click += new System.EventHandler(this.OutToEXcel_Click);
            // 
            // BollToPoint
            // 
            this.BollToPoint.Location = new System.Drawing.Point(158, 345);
            this.BollToPoint.Name = "BollToPoint";
            this.BollToPoint.Size = new System.Drawing.Size(118, 44);
            this.BollToPoint.TabIndex = 2;
            this.BollToPoint.Text = "球生成点";
            this.BollToPoint.UseVisualStyleBackColor = true;
            this.BollToPoint.Click += new System.EventHandler(this.BollToPoint_Click);
            // 
            // AutoHole
            // 
            this.AutoHole.Location = new System.Drawing.Point(450, 345);
            this.AutoHole.Name = "AutoHole";
            this.AutoHole.Size = new System.Drawing.Size(118, 44);
            this.AutoHole.TabIndex = 2;
            this.AutoHole.Text = "自动打孔";
            this.AutoHole.UseVisualStyleBackColor = true;
            this.AutoHole.Click += new System.EventHandler(this.AutoHole_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(12, 23);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.Size = new System.Drawing.Size(852, 304);
            this.DataGrid.TabIndex = 3;
            // 
            // ReadCoord
            // 
            this.ReadCoord.Location = new System.Drawing.Point(12, 345);
            this.ReadCoord.Name = "ReadCoord";
            this.ReadCoord.Size = new System.Drawing.Size(118, 44);
            this.ReadCoord.TabIndex = 2;
            this.ReadCoord.Text = "仅读坐标";
            this.ReadCoord.UseVisualStyleBackColor = true;
            this.ReadCoord.Click += new System.EventHandler(this.ReadCoord_Click);
            // 
            // ClearAllData
            // 
            this.ClearAllData.Location = new System.Drawing.Point(304, 345);
            this.ClearAllData.Name = "ClearAllData";
            this.ClearAllData.Size = new System.Drawing.Size(118, 44);
            this.ClearAllData.TabIndex = 2;
            this.ClearAllData.Text = "清空数据";
            this.ClearAllData.UseVisualStyleBackColor = true;
            this.ClearAllData.Click += new System.EventHandler(this.ClearAllData_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CatiaQuickTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(880, 440);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.AutoHole);
            this.Controls.Add(this.ReadCoord);
            this.Controls.Add(this.ClearAllData);
            this.Controls.Add(this.BollToPoint);
            this.Controls.Add(this.OutToEXcel);
            this.Controls.Add(this.KeepName);
            this.Controls.Add(this.TryRead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(896, 479);
            this.MinimumSize = new System.Drawing.Size(896, 479);
            this.Name = "CatiaQuickTool";
            this.Text = "CatiaQuickTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CatiaQuickTool_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TryRead;
        private System.Windows.Forms.CheckBox KeepName;
        private System.Windows.Forms.Button OutToEXcel;
        private System.Windows.Forms.Button BollToPoint;
        private System.Windows.Forms.Button AutoHole;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button ReadCoord;
        private System.Windows.Forms.Button ClearAllData;
        private System.Windows.Forms.Timer timer;
    }
}