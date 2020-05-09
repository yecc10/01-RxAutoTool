namespace AutoDeskLK
{
    partial class CadRead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadRead));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.KeepValue = new System.Windows.Forms.TextBox();
            this.OutToPlant = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.mIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ydata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DoubleRoadSelected = new System.Windows.Forms.RadioButton();
            this.SingeRoadSelected = new System.Windows.Forms.RadioButton();
            this.Sscale = new System.Windows.Forms.TextBox();
            this.DeleteData = new System.Windows.Forms.Button();
            this.ClearData = new System.Windows.Forms.Button();
            this.OutExcel = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.IndexValue = new System.Windows.Forms.TextBox();
            this.SY_AIX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoRead = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ManulInputPoint = new System.Windows.Forms.Button();
            this.ManulInputLine = new System.Windows.Forms.Button();
            this.SX_AIX = new System.Windows.Forms.TextBox();
            this.SetRefPoint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UWCS = new System.Windows.Forms.RadioButton();
            this.UUCS = new System.Windows.Forms.RadioButton();
            this.ApplyPlantAix = new System.Windows.Forms.CheckBox();
            this.AutoRiseIndex = new System.Windows.Forms.CheckBox();
            this.ChangeXY = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "比例";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "小数位数";
            // 
            // KeepValue
            // 
            this.KeepValue.Location = new System.Drawing.Point(219, 50);
            this.KeepValue.Name = "KeepValue";
            this.KeepValue.Size = new System.Drawing.Size(61, 21);
            this.KeepValue.TabIndex = 2;
            this.KeepValue.Text = "3";
            this.KeepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OutToPlant
            // 
            this.OutToPlant.Location = new System.Drawing.Point(657, 640);
            this.OutToPlant.Name = "OutToPlant";
            this.OutToPlant.Size = new System.Drawing.Size(90, 30);
            this.OutToPlant.TabIndex = 2;
            this.OutToPlant.Text = "输入到Plant";
            this.OutToPlant.UseVisualStyleBackColor = true;
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mIndex,
            this.Xdata,
            this.Ydata,
            this.Zdata,
            this.Range,
            this.TrackType});
            this.DataGrid.Location = new System.Drawing.Point(12, 185);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.Size = new System.Drawing.Size(747, 449);
            this.DataGrid.TabIndex = 8;
            // 
            // mIndex
            // 
            this.mIndex.DataPropertyName = "序号";
            this.mIndex.HeaderText = "序号";
            this.mIndex.Name = "mIndex";
            this.mIndex.Width = 80;
            // 
            // Xdata
            // 
            this.Xdata.DataPropertyName = "X坐标";
            this.Xdata.HeaderText = "X坐标";
            this.Xdata.Name = "Xdata";
            this.Xdata.Width = 120;
            // 
            // Ydata
            // 
            this.Ydata.DataPropertyName = "Y坐标";
            this.Ydata.HeaderText = "Y坐标";
            this.Ydata.Name = "Ydata";
            this.Ydata.Width = 120;
            // 
            // Zdata
            // 
            this.Zdata.DataPropertyName = "Z坐标";
            this.Zdata.HeaderText = "Z坐标";
            this.Zdata.Name = "Zdata";
            this.Zdata.Width = 120;
            // 
            // Range
            // 
            this.Range.DataPropertyName = "R角";
            this.Range.HeaderText = "R弯道";
            this.Range.Name = "Range";
            this.Range.Width = 120;
            // 
            // TrackType
            // 
            this.TrackType.DataPropertyName = "TrackType";
            this.TrackType.HeaderText = "路径类型";
            this.TrackType.Name = "TrackType";
            this.TrackType.Width = 120;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DoubleRoadSelected);
            this.groupBox3.Controls.Add(this.SingeRoadSelected);
            this.groupBox3.Location = new System.Drawing.Point(546, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 104);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "路径类型设定";
            // 
            // DoubleRoadSelected
            // 
            this.DoubleRoadSelected.AutoSize = true;
            this.DoubleRoadSelected.Location = new System.Drawing.Point(12, 67);
            this.DoubleRoadSelected.Name = "DoubleRoadSelected";
            this.DoubleRoadSelected.Size = new System.Drawing.Size(71, 16);
            this.DoubleRoadSelected.TabIndex = 4;
            this.DoubleRoadSelected.Text = "双向通道";
            this.DoubleRoadSelected.UseVisualStyleBackColor = true;
            // 
            // SingeRoadSelected
            // 
            this.SingeRoadSelected.AutoSize = true;
            this.SingeRoadSelected.Checked = true;
            this.SingeRoadSelected.Location = new System.Drawing.Point(12, 34);
            this.SingeRoadSelected.Name = "SingeRoadSelected";
            this.SingeRoadSelected.Size = new System.Drawing.Size(71, 16);
            this.SingeRoadSelected.TabIndex = 4;
            this.SingeRoadSelected.TabStop = true;
            this.SingeRoadSelected.Text = "单向通道";
            this.SingeRoadSelected.UseVisualStyleBackColor = true;
            // 
            // Sscale
            // 
            this.Sscale.Location = new System.Drawing.Point(327, 50);
            this.Sscale.Name = "Sscale";
            this.Sscale.Size = new System.Drawing.Size(61, 21);
            this.Sscale.TabIndex = 2;
            this.Sscale.Text = "1";
            this.Sscale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeleteData
            // 
            this.DeleteData.Location = new System.Drawing.Point(444, 640);
            this.DeleteData.Name = "DeleteData";
            this.DeleteData.Size = new System.Drawing.Size(90, 30);
            this.DeleteData.TabIndex = 3;
            this.DeleteData.Text = "删除最后输入";
            this.DeleteData.UseVisualStyleBackColor = true;
            this.DeleteData.Click += new System.EventHandler(this.DeleteData_Click);
            // 
            // ClearData
            // 
            this.ClearData.Location = new System.Drawing.Point(231, 640);
            this.ClearData.Name = "ClearData";
            this.ClearData.Size = new System.Drawing.Size(90, 30);
            this.ClearData.TabIndex = 4;
            this.ClearData.Text = "清空";
            this.ClearData.UseVisualStyleBackColor = true;
            this.ClearData.Click += new System.EventHandler(this.ClearData_Click);
            // 
            // OutExcel
            // 
            this.OutExcel.Location = new System.Drawing.Point(18, 640);
            this.OutExcel.Name = "OutExcel";
            this.OutExcel.Size = new System.Drawing.Size(90, 30);
            this.OutExcel.TabIndex = 5;
            this.OutExcel.Text = "导出EXCEL";
            this.OutExcel.UseVisualStyleBackColor = true;
            this.OutExcel.Click += new System.EventHandler(this.OutExcel_Click);
            // 
            // IndexValue
            // 
            this.IndexValue.Location = new System.Drawing.Point(87, 50);
            this.IndexValue.Name = "IndexValue";
            this.IndexValue.Size = new System.Drawing.Size(61, 21);
            this.IndexValue.TabIndex = 2;
            this.IndexValue.Text = "1";
            this.IndexValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SY_AIX
            // 
            this.SY_AIX.Location = new System.Drawing.Point(155, 34);
            this.SY_AIX.Name = "SY_AIX";
            this.SY_AIX.Size = new System.Drawing.Size(272, 21);
            this.SY_AIX.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AutoRead);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ManulInputPoint);
            this.groupBox1.Controls.Add(this.ManulInputLine);
            this.groupBox1.Controls.Add(this.SY_AIX);
            this.groupBox1.Controls.Add(this.SX_AIX);
            this.groupBox1.Controls.Add(this.SetRefPoint);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拾取对象";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y坐标";
            // 
            // AutoRead
            // 
            this.AutoRead.Location = new System.Drawing.Point(646, 20);
            this.AutoRead.Name = "AutoRead";
            this.AutoRead.Size = new System.Drawing.Size(90, 30);
            this.AutoRead.TabIndex = 0;
            this.AutoRead.Text = "自动全部读取";
            this.AutoRead.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "X坐标";
            // 
            // ManulInputPoint
            // 
            this.ManulInputPoint.Location = new System.Drawing.Point(432, 20);
            this.ManulInputPoint.Name = "ManulInputPoint";
            this.ManulInputPoint.Size = new System.Drawing.Size(90, 30);
            this.ManulInputPoint.TabIndex = 0;
            this.ManulInputPoint.Text = "手动依次读点";
            this.ManulInputPoint.UseVisualStyleBackColor = true;
            this.ManulInputPoint.Click += new System.EventHandler(this.ManulInputPoint_Click);
            // 
            // ManulInputLine
            // 
            this.ManulInputLine.Location = new System.Drawing.Point(539, 20);
            this.ManulInputLine.Name = "ManulInputLine";
            this.ManulInputLine.Size = new System.Drawing.Size(90, 30);
            this.ManulInputLine.TabIndex = 0;
            this.ManulInputLine.Text = "手动依次读线";
            this.ManulInputLine.UseVisualStyleBackColor = true;
            this.ManulInputLine.Click += new System.EventHandler(this.ManulInputLine_Click);
            // 
            // SX_AIX
            // 
            this.SX_AIX.Location = new System.Drawing.Point(155, 12);
            this.SX_AIX.Name = "SX_AIX";
            this.SX_AIX.Size = new System.Drawing.Size(272, 21);
            this.SX_AIX.TabIndex = 2;
            // 
            // SetRefPoint
            // 
            this.SetRefPoint.Location = new System.Drawing.Point(6, 20);
            this.SetRefPoint.Name = "SetRefPoint";
            this.SetRefPoint.Size = new System.Drawing.Size(90, 30);
            this.SetRefPoint.TabIndex = 0;
            this.SetRefPoint.Text = "设定参考点";
            this.SetRefPoint.UseVisualStyleBackColor = true;
            this.SetRefPoint.Click += new System.EventHandler(this.SetRefPoint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Sscale);
            this.groupBox2.Controls.Add(this.KeepValue);
            this.groupBox2.Controls.Add(this.IndexValue);
            this.groupBox2.Controls.Add(this.UWCS);
            this.groupBox2.Controls.Add(this.UUCS);
            this.groupBox2.Controls.Add(this.ApplyPlantAix);
            this.groupBox2.Controls.Add(this.AutoRiseIndex);
            this.groupBox2.Controls.Add(this.ChangeXY);
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本设置";
            // 
            // UWCS
            // 
            this.UWCS.AutoSize = true;
            this.UWCS.Location = new System.Drawing.Point(305, 21);
            this.UWCS.Name = "UWCS";
            this.UWCS.Size = new System.Drawing.Size(83, 16);
            this.UWCS.TabIndex = 1;
            this.UWCS.TabStop = true;
            this.UWCS.Text = "世界坐标系";
            this.UWCS.UseVisualStyleBackColor = true;
            // 
            // UUCS
            // 
            this.UUCS.AutoSize = true;
            this.UUCS.Location = new System.Drawing.Point(159, 21);
            this.UUCS.Name = "UUCS";
            this.UUCS.Size = new System.Drawing.Size(83, 16);
            this.UUCS.TabIndex = 1;
            this.UUCS.TabStop = true;
            this.UUCS.Text = "用户坐标系";
            this.UUCS.UseVisualStyleBackColor = true;
            // 
            // ApplyPlantAix
            // 
            this.ApplyPlantAix.AutoSize = true;
            this.ApplyPlantAix.Checked = true;
            this.ApplyPlantAix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ApplyPlantAix.Location = new System.Drawing.Point(6, 82);
            this.ApplyPlantAix.Name = "ApplyPlantAix";
            this.ApplyPlantAix.Size = new System.Drawing.Size(126, 16);
            this.ApplyPlantAix.TabIndex = 0;
            this.ApplyPlantAix.Text = "应用Plant坐标规则";
            this.ApplyPlantAix.UseVisualStyleBackColor = true;
            // 
            // AutoRiseIndex
            // 
            this.AutoRiseIndex.AutoSize = true;
            this.AutoRiseIndex.Checked = true;
            this.AutoRiseIndex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoRiseIndex.Location = new System.Drawing.Point(6, 52);
            this.AutoRiseIndex.Name = "AutoRiseIndex";
            this.AutoRiseIndex.Size = new System.Drawing.Size(72, 16);
            this.AutoRiseIndex.TabIndex = 0;
            this.AutoRiseIndex.Text = "编码递增";
            this.AutoRiseIndex.UseVisualStyleBackColor = true;
            // 
            // ChangeXY
            // 
            this.ChangeXY.AutoSize = true;
            this.ChangeXY.Location = new System.Drawing.Point(6, 21);
            this.ChangeXY.Name = "ChangeXY";
            this.ChangeXY.Size = new System.Drawing.Size(90, 16);
            this.ChangeXY.TabIndex = 0;
            this.ChangeXY.Text = "X\\Y坐标互换";
            this.ChangeXY.UseVisualStyleBackColor = true;
            // 
            // CadRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(771, 684);
            this.Controls.Add(this.OutToPlant);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.DeleteData);
            this.Controls.Add(this.ClearData);
            this.Controls.Add(this.OutExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(787, 723);
            this.MinimumSize = new System.Drawing.Size(787, 723);
            this.Name = "CadRead";
            this.Text = "CadRead";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KeepValue;
        private System.Windows.Forms.Button OutToPlant;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ydata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton DoubleRoadSelected;
        private System.Windows.Forms.RadioButton SingeRoadSelected;
        private System.Windows.Forms.TextBox Sscale;
        private System.Windows.Forms.Button DeleteData;
        private System.Windows.Forms.Button ClearData;
        private System.Windows.Forms.Button OutExcel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox IndexValue;
        private System.Windows.Forms.TextBox SY_AIX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AutoRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ManulInputPoint;
        private System.Windows.Forms.Button ManulInputLine;
        private System.Windows.Forms.TextBox SX_AIX;
        private System.Windows.Forms.Button SetRefPoint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton UWCS;
        private System.Windows.Forms.RadioButton UUCS;
        private System.Windows.Forms.CheckBox ApplyPlantAix;
        private System.Windows.Forms.CheckBox AutoRiseIndex;
        private System.Windows.Forms.CheckBox ChangeXY;
    }
}