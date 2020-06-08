﻿namespace AutoDeskLine_ToPlant
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
            this.InsGun = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.ReadCoord = new System.Windows.Forms.Button();
            this.ClearAllData = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.PointToCoord = new System.Windows.Forms.Button();
            this.ReadAixPoint = new System.Windows.Forms.Button();
            this.Creat3dPoint = new System.Windows.Forms.Button();
            this.Creat3dBall = new System.Windows.Forms.Button();
            this.BallRadio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RepeatCheck = new System.Windows.Forms.CheckBox();
            this.IgRepeat = new System.Windows.Forms.CheckBox();
            this.ByExcel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TryRead
            // 
            this.TryRead.Location = new System.Drawing.Point(599, 345);
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
            this.KeepName.Location = new System.Drawing.Point(6, 397);
            this.KeepName.Name = "KeepName";
            this.KeepName.Size = new System.Drawing.Size(72, 16);
            this.KeepName.TabIndex = 1;
            this.KeepName.Text = "保留名称";
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
            this.BollToPoint.Location = new System.Drawing.Point(170, 345);
            this.BollToPoint.Name = "BollToPoint";
            this.BollToPoint.Size = new System.Drawing.Size(118, 44);
            this.BollToPoint.TabIndex = 2;
            this.BollToPoint.Text = "球生成点";
            this.BollToPoint.UseVisualStyleBackColor = true;
            this.BollToPoint.Click += new System.EventHandler(this.BollToPoint_Click);
            // 
            // InsGun
            // 
            this.InsGun.Location = new System.Drawing.Point(456, 345);
            this.InsGun.Name = "InsGun";
            this.InsGun.Size = new System.Drawing.Size(118, 44);
            this.InsGun.TabIndex = 2;
            this.InsGun.Text = "插入焊钳";
            this.InsGun.UseVisualStyleBackColor = true;
            this.InsGun.Click += new System.EventHandler(this.InsGun_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(12, 23);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGrid.Size = new System.Drawing.Size(852, 304);
            this.DataGrid.TabIndex = 3;
            // 
            // ReadCoord
            // 
            this.ReadCoord.Location = new System.Drawing.Point(170, 394);
            this.ReadCoord.Name = "ReadCoord";
            this.ReadCoord.Size = new System.Drawing.Size(118, 44);
            this.ReadCoord.TabIndex = 2;
            this.ReadCoord.Text = "求解任意坐标";
            this.ReadCoord.UseVisualStyleBackColor = true;
            this.ReadCoord.Click += new System.EventHandler(this.ReadCoord_Click);
            // 
            // ClearAllData
            // 
            this.ClearAllData.Location = new System.Drawing.Point(313, 345);
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
            // PointToCoord
            // 
            this.PointToCoord.Location = new System.Drawing.Point(12, 345);
            this.PointToCoord.Name = "PointToCoord";
            this.PointToCoord.Size = new System.Drawing.Size(118, 44);
            this.PointToCoord.TabIndex = 2;
            this.PointToCoord.Text = "求解点坐标";
            this.PointToCoord.UseVisualStyleBackColor = true;
            this.PointToCoord.Click += new System.EventHandler(this.PointToCoord_Click);
            // 
            // ReadAixPoint
            // 
            this.ReadAixPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ReadAixPoint.Location = new System.Drawing.Point(313, 394);
            this.ReadAixPoint.Name = "ReadAixPoint";
            this.ReadAixPoint.Size = new System.Drawing.Size(118, 44);
            this.ReadAixPoint.TabIndex = 2;
            this.ReadAixPoint.Text = "坐标导入";
            this.ReadAixPoint.UseVisualStyleBackColor = false;
            this.ReadAixPoint.Click += new System.EventHandler(this.Aix_To_Ball_Click);
            // 
            // Creat3dPoint
            // 
            this.Creat3dPoint.Location = new System.Drawing.Point(456, 394);
            this.Creat3dPoint.Name = "Creat3dPoint";
            this.Creat3dPoint.Size = new System.Drawing.Size(118, 44);
            this.Creat3dPoint.TabIndex = 2;
            this.Creat3dPoint.Text = "生成3D点";
            this.Creat3dPoint.UseVisualStyleBackColor = true;
            this.Creat3dPoint.Click += new System.EventHandler(this.Creat3dPoint_Click);
            // 
            // Creat3dBall
            // 
            this.Creat3dBall.Location = new System.Drawing.Point(599, 395);
            this.Creat3dBall.Name = "Creat3dBall";
            this.Creat3dBall.Size = new System.Drawing.Size(118, 44);
            this.Creat3dBall.TabIndex = 2;
            this.Creat3dBall.Text = "生成3D球";
            this.Creat3dBall.UseVisualStyleBackColor = true;
            this.Creat3dBall.Click += new System.EventHandler(this.Creat3dBall_Click);
            // 
            // BallRadio
            // 
            this.BallRadio.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BallRadio.Location = new System.Drawing.Point(781, 403);
            this.BallRadio.Name = "BallRadio";
            this.BallRadio.Size = new System.Drawing.Size(77, 26);
            this.BallRadio.TabIndex = 4;
            this.BallRadio.Text = "6";
            this.BallRadio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "球半径";
            // 
            // RepeatCheck
            // 
            this.RepeatCheck.AutoSize = true;
            this.RepeatCheck.Checked = true;
            this.RepeatCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RepeatCheck.Location = new System.Drawing.Point(6, 420);
            this.RepeatCheck.Name = "RepeatCheck";
            this.RepeatCheck.Size = new System.Drawing.Size(72, 16);
            this.RepeatCheck.TabIndex = 1;
            this.RepeatCheck.Text = "重复检查";
            this.RepeatCheck.UseVisualStyleBackColor = true;
            // 
            // IgRepeat
            // 
            this.IgRepeat.AutoSize = true;
            this.IgRepeat.Checked = true;
            this.IgRepeat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgRepeat.Location = new System.Drawing.Point(86, 420);
            this.IgRepeat.Name = "IgRepeat";
            this.IgRepeat.Size = new System.Drawing.Size(72, 16);
            this.IgRepeat.TabIndex = 1;
            this.IgRepeat.Text = "过滤重复";
            this.IgRepeat.UseVisualStyleBackColor = true;
            // 
            // ByExcel
            // 
            this.ByExcel.AutoSize = true;
            this.ByExcel.Checked = true;
            this.ByExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ByExcel.Location = new System.Drawing.Point(86, 398);
            this.ByExcel.Name = "ByExcel";
            this.ByExcel.Size = new System.Drawing.Size(66, 16);
            this.ByExcel.TabIndex = 1;
            this.ByExcel.Text = "ByExcel";
            this.ByExcel.UseVisualStyleBackColor = true;
            // 
            // CatiaQuickTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(880, 440);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BallRadio);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.Creat3dBall);
            this.Controls.Add(this.Creat3dPoint);
            this.Controls.Add(this.InsGun);
            this.Controls.Add(this.PointToCoord);
            this.Controls.Add(this.ReadAixPoint);
            this.Controls.Add(this.ReadCoord);
            this.Controls.Add(this.ClearAllData);
            this.Controls.Add(this.BollToPoint);
            this.Controls.Add(this.OutToEXcel);
            this.Controls.Add(this.ByExcel);
            this.Controls.Add(this.IgRepeat);
            this.Controls.Add(this.RepeatCheck);
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
        private System.Windows.Forms.Button InsGun;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button ReadCoord;
        private System.Windows.Forms.Button ClearAllData;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button PointToCoord;
        private System.Windows.Forms.Button ReadAixPoint;
        private System.Windows.Forms.Button Creat3dPoint;
        private System.Windows.Forms.Button Creat3dBall;
        private System.Windows.Forms.TextBox BallRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RepeatCheck;
        private System.Windows.Forms.CheckBox IgRepeat;
        private System.Windows.Forms.CheckBox ByExcel;
    }
}