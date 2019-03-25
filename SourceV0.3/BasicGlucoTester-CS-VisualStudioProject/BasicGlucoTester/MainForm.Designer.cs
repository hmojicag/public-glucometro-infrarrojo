namespace BasicGlucoTester
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.groupBox_PuertoSerial = new System.Windows.Forms.GroupBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.comboBox_Puertos = new System.Windows.Forms.ComboBox();
            this.groupBox_FlowControl = new System.Windows.Forms.GroupBox();
            this.button_Calibrate = new System.Windows.Forms.Button();
            this.label_FlowPhase = new System.Windows.Forms.Label();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Test = new System.Windows.Forms.Button();
            this.groupBox_Data = new System.Windows.Forms.GroupBox();
            this.label_Intensity1 = new System.Windows.Forms.Label();
            this.label_Intensity0 = new System.Windows.Forms.Label();
            this.label_Absorbance = new System.Windows.Forms.Label();
            this.pictureBox_Absorbance = new System.Windows.Forms.PictureBox();
            this.chart_Datos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Team = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_Sampling = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_Sampling = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_Results = new System.Windows.Forms.GroupBox();
            this.groupBox_Mode = new System.Windows.Forms.GroupBox();
            this.radioButton_ModeAdv = new System.Windows.Forms.RadioButton();
            this.radioButton_ModeBasic = new System.Windows.Forms.RadioButton();
            this.groupBox_PuertoSerial.SuspendLayout();
            this.groupBox_FlowControl.SuspendLayout();
            this.groupBox_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Absorbance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Datos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox_Mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_PuertoSerial
            // 
            this.groupBox_PuertoSerial.Controls.Add(this.button_Refresh);
            this.groupBox_PuertoSerial.Controls.Add(this.comboBox_Puertos);
            this.groupBox_PuertoSerial.Location = new System.Drawing.Point(13, 13);
            this.groupBox_PuertoSerial.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_PuertoSerial.Name = "groupBox_PuertoSerial";
            this.groupBox_PuertoSerial.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_PuertoSerial.Size = new System.Drawing.Size(296, 80);
            this.groupBox_PuertoSerial.TabIndex = 2;
            this.groupBox_PuertoSerial.TabStop = false;
            this.groupBox_PuertoSerial.Text = "Board Serial Port";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(177, 21);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(100, 28);
            this.button_Refresh.TabIndex = 1;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // comboBox_Puertos
            // 
            this.comboBox_Puertos.FormattingEnabled = true;
            this.comboBox_Puertos.Location = new System.Drawing.Point(8, 23);
            this.comboBox_Puertos.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Puertos.Name = "comboBox_Puertos";
            this.comboBox_Puertos.Size = new System.Drawing.Size(160, 24);
            this.comboBox_Puertos.TabIndex = 0;
            this.comboBox_Puertos.SelectedIndexChanged += new System.EventHandler(this.comboBox_Puertos_SelectedIndexChanged);
            // 
            // groupBox_FlowControl
            // 
            this.groupBox_FlowControl.Controls.Add(this.button_Calibrate);
            this.groupBox_FlowControl.Controls.Add(this.label_FlowPhase);
            this.groupBox_FlowControl.Controls.Add(this.button_Stop);
            this.groupBox_FlowControl.Controls.Add(this.button_Test);
            this.groupBox_FlowControl.Enabled = false;
            this.groupBox_FlowControl.Location = new System.Drawing.Point(316, 13);
            this.groupBox_FlowControl.Name = "groupBox_FlowControl";
            this.groupBox_FlowControl.Size = new System.Drawing.Size(131, 80);
            this.groupBox_FlowControl.TabIndex = 3;
            this.groupBox_FlowControl.TabStop = false;
            this.groupBox_FlowControl.Text = "Flow Control";
            // 
            // button_Calibrate
            // 
            this.button_Calibrate.BackColor = System.Drawing.SystemColors.Window;
            this.button_Calibrate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Calibrate.Image = ((System.Drawing.Image)(resources.GetObject("button_Calibrate.Image")));
            this.button_Calibrate.Location = new System.Drawing.Point(6, 21);
            this.button_Calibrate.Name = "button_Calibrate";
            this.button_Calibrate.Size = new System.Drawing.Size(35, 35);
            this.button_Calibrate.TabIndex = 3;
            this.button_Calibrate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Calibrate.UseVisualStyleBackColor = false;
            this.button_Calibrate.Click += new System.EventHandler(this.button_Calibrate_Click);
            // 
            // label_FlowPhase
            // 
            this.label_FlowPhase.AutoSize = true;
            this.label_FlowPhase.Location = new System.Drawing.Point(6, 59);
            this.label_FlowPhase.Name = "label_FlowPhase";
            this.label_FlowPhase.Size = new System.Drawing.Size(95, 17);
            this.label_FlowPhase.TabIndex = 2;
            this.label_FlowPhase.Text = "Not Inicialized";
            // 
            // button_Stop
            // 
            this.button_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Stop.Image = ((System.Drawing.Image)(resources.GetObject("button_Stop.Image")));
            this.button_Stop.Location = new System.Drawing.Point(88, 21);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(35, 35);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Test
            // 
            this.button_Test.BackColor = System.Drawing.SystemColors.Window;
            this.button_Test.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Test.Image = ((System.Drawing.Image)(resources.GetObject("button_Test.Image")));
            this.button_Test.Location = new System.Drawing.Point(47, 21);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(35, 35);
            this.button_Test.TabIndex = 0;
            this.button_Test.UseVisualStyleBackColor = false;
            this.button_Test.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // groupBox_Data
            // 
            this.groupBox_Data.Controls.Add(this.label_Intensity1);
            this.groupBox_Data.Controls.Add(this.label_Intensity0);
            this.groupBox_Data.Controls.Add(this.label_Absorbance);
            this.groupBox_Data.Controls.Add(this.pictureBox_Absorbance);
            this.groupBox_Data.Controls.Add(this.chart_Datos);
            this.groupBox_Data.Enabled = false;
            this.groupBox_Data.Location = new System.Drawing.Point(13, 231);
            this.groupBox_Data.Name = "groupBox_Data";
            this.groupBox_Data.Size = new System.Drawing.Size(578, 391);
            this.groupBox_Data.TabIndex = 4;
            this.groupBox_Data.TabStop = false;
            this.groupBox_Data.Text = "Data";
            // 
            // label_Intensity1
            // 
            this.label_Intensity1.AutoSize = true;
            this.label_Intensity1.Location = new System.Drawing.Point(132, 296);
            this.label_Intensity1.Name = "label_Intensity1";
            this.label_Intensity1.Size = new System.Drawing.Size(35, 17);
            this.label_Intensity1.TabIndex = 4;
            this.label_Intensity1.Text = "I1:...";
            // 
            // label_Intensity0
            // 
            this.label_Intensity0.AutoSize = true;
            this.label_Intensity0.Location = new System.Drawing.Point(133, 313);
            this.label_Intensity0.Name = "label_Intensity0";
            this.label_Intensity0.Size = new System.Drawing.Size(35, 17);
            this.label_Intensity0.TabIndex = 3;
            this.label_Intensity0.Text = "I0:...";
            // 
            // label_Absorbance
            // 
            this.label_Absorbance.AutoSize = true;
            this.label_Absorbance.Location = new System.Drawing.Point(133, 330);
            this.label_Absorbance.Name = "label_Absorbance";
            this.label_Absorbance.Size = new System.Drawing.Size(100, 17);
            this.label_Absorbance.TabIndex = 2;
            this.label_Absorbance.Text = "Absorbance:...";
            // 
            // pictureBox_Absorbance
            // 
            this.pictureBox_Absorbance.Location = new System.Drawing.Point(8, 296);
            this.pictureBox_Absorbance.Name = "pictureBox_Absorbance";
            this.pictureBox_Absorbance.Size = new System.Drawing.Size(117, 51);
            this.pictureBox_Absorbance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Absorbance.TabIndex = 1;
            this.pictureBox_Absorbance.TabStop = false;
            // 
            // chart_Datos
            // 
            chartArea1.AxisX.Title = "Sample Time (t*50ms)";
            chartArea1.AxisY.Interval = 0.3D;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Maximum = 2D;
            chartArea1.AxisY.Title = "Volts (V)";
            chartArea1.Name = "ChartArea1";
            this.chart_Datos.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart_Datos.Legends.Add(legend1);
            this.chart_Datos.Location = new System.Drawing.Point(8, 21);
            this.chart_Datos.Name = "chart_Datos";
            this.chart_Datos.Size = new System.Drawing.Size(553, 269);
            this.chart_Datos.TabIndex = 0;
            this.chart_Datos.Text = "chart1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Team,
            this.toolStripProgressBar_Sampling,
            this.toolStripStatusLabel_Sampling});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(604, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Team
            // 
            this.toolStripStatusLabel_Team.Name = "toolStripStatusLabel_Team";
            this.toolStripStatusLabel_Team.Size = new System.Drawing.Size(440, 20);
            this.toolStripStatusLabel_Team.Text = "Hazael Fernando Mojica García 1500724, Ricardo Guevara Zavala";
            // 
            // toolStripProgressBar_Sampling
            // 
            this.toolStripProgressBar_Sampling.Name = "toolStripProgressBar_Sampling";
            this.toolStripProgressBar_Sampling.Size = new System.Drawing.Size(100, 19);
            this.toolStripProgressBar_Sampling.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel_Sampling
            // 
            this.toolStripStatusLabel_Sampling.Name = "toolStripStatusLabel_Sampling";
            this.toolStripStatusLabel_Sampling.Size = new System.Drawing.Size(18, 20);
            this.toolStripStatusLabel_Sampling.Text = "...";
            // 
            // groupBox_Results
            // 
            this.groupBox_Results.Location = new System.Drawing.Point(13, 99);
            this.groupBox_Results.Name = "groupBox_Results";
            this.groupBox_Results.Size = new System.Drawing.Size(583, 126);
            this.groupBox_Results.TabIndex = 6;
            this.groupBox_Results.TabStop = false;
            this.groupBox_Results.Text = "Results";
            // 
            // groupBox_Mode
            // 
            this.groupBox_Mode.Controls.Add(this.radioButton_ModeAdv);
            this.groupBox_Mode.Controls.Add(this.radioButton_ModeBasic);
            this.groupBox_Mode.Location = new System.Drawing.Point(453, 13);
            this.groupBox_Mode.Name = "groupBox_Mode";
            this.groupBox_Mode.Size = new System.Drawing.Size(143, 80);
            this.groupBox_Mode.TabIndex = 7;
            this.groupBox_Mode.TabStop = false;
            this.groupBox_Mode.Text = "Mode";
            // 
            // radioButton_ModeAdv
            // 
            this.radioButton_ModeAdv.AutoSize = true;
            this.radioButton_ModeAdv.Location = new System.Drawing.Point(7, 51);
            this.radioButton_ModeAdv.Name = "radioButton_ModeAdv";
            this.radioButton_ModeAdv.Size = new System.Drawing.Size(131, 21);
            this.radioButton_ModeAdv.TabIndex = 1;
            this.radioButton_ModeAdv.Text = "Advanced Mode";
            this.radioButton_ModeAdv.UseVisualStyleBackColor = true;
            this.radioButton_ModeAdv.CheckedChanged += new System.EventHandler(this.radioButton_ModeAdv_CheckedChanged);
            // 
            // radioButton_ModeBasic
            // 
            this.radioButton_ModeBasic.AutoSize = true;
            this.radioButton_ModeBasic.Checked = true;
            this.radioButton_ModeBasic.Location = new System.Drawing.Point(7, 23);
            this.radioButton_ModeBasic.Name = "radioButton_ModeBasic";
            this.radioButton_ModeBasic.Size = new System.Drawing.Size(102, 21);
            this.radioButton_ModeBasic.TabIndex = 0;
            this.radioButton_ModeBasic.TabStop = true;
            this.radioButton_ModeBasic.Text = "Basic Mode";
            this.radioButton_ModeBasic.UseVisualStyleBackColor = true;
            this.radioButton_ModeBasic.Click += new System.EventHandler(this.radioButton_ModeBasic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(604, 659);
            this.Controls.Add(this.groupBox_Mode);
            this.Controls.Add(this.groupBox_Results);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_Data);
            this.Controls.Add(this.groupBox_FlowControl);
            this.Controls.Add(this.groupBox_PuertoSerial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "BasicGlucotester V0.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_PuertoSerial.ResumeLayout(false);
            this.groupBox_FlowControl.ResumeLayout(false);
            this.groupBox_FlowControl.PerformLayout();
            this.groupBox_Data.ResumeLayout(false);
            this.groupBox_Data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Absorbance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Datos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_Mode.ResumeLayout(false);
            this.groupBox_Mode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_PuertoSerial;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.ComboBox comboBox_Puertos;
        private System.Windows.Forms.GroupBox groupBox_FlowControl;
        private System.Windows.Forms.GroupBox groupBox_Data;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Team;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_Sampling;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Sampling;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Datos;
        private System.Windows.Forms.Label label_FlowPhase;
        private System.Windows.Forms.PictureBox pictureBox_Absorbance;
        private System.Windows.Forms.Label label_Absorbance;
        private System.Windows.Forms.Label label_Intensity0;
        private System.Windows.Forms.Label label_Intensity1;
        private System.Windows.Forms.GroupBox groupBox_Results;
        private System.Windows.Forms.Button button_Calibrate;
        private System.Windows.Forms.GroupBox groupBox_Mode;
        private System.Windows.Forms.RadioButton radioButton_ModeAdv;
        private System.Windows.Forms.RadioButton radioButton_ModeBasic;
    }
}

