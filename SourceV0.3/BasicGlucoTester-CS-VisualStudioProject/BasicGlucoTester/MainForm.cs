/*
 * Hazael Fernando Mojica García
 * Software de control de la tarjeta de Adquisición de Datos para el Glucometro
 * basado en arduino.
 * 17/09/2013
 * V0.2
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BasicGlucoTester
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.ToolTip tooltip1 = new System.Windows.Forms.ToolTip();
        Arduino arduino;
        Timer timer;
        double[] valuesCalibrate;
        double[] valuesTest;

        double I0;
        double I1;
        double A;

        enum State
        {
            main,
            inicialized,
            calibrating,
            calibrated,
            testing,
            tested
        }
        State state;

        public MainForm()
        {
            InitializeComponent();
            this.tooltip1.SetToolTip(this.button_Test, "Press here to Start Testing Step");
            this.tooltip1.SetToolTip(this.button_Calibrate, "Press here to Start Calibrating Step");
            this.tooltip1.SetToolTip(this.button_Stop, "Click here to Stop all executions and erase all data");
            this.tooltip1.SetToolTip(this.comboBox_Puertos, "Select the port of the board");
            this.tooltip1.SetToolTip(this.button_Refresh, "Refill the Serial Ports List");
            Turn2BasicMode();
            timer = new Timer();
            timer.Interval = 51;//set to 51ms
            timer.Tick += timer_Tick;
            state_main();
        }





        #region STATES

        private void state_main()
        {
            state = State.main;
            this.chart_Datos.Series.Clear();
            this.groupBox_PuertoSerial.Enabled = true;
            this.groupBox_FlowControl.Enabled = false;
            this.groupBox_Data.Enabled = false;
            serial_combo(this.comboBox_Puertos);
            this.label_FlowPhase.Text = "Not Inicilized";
            this.toolStripProgressBar_Sampling.Value = 0;
            this.toolStripStatusLabel_Sampling.Text = "...";
            this.label_Absorbance.Text = "Absorbance:...";
            this.label_Intensity0.Text = "I0:...";
            this.label_Intensity1.Text = "I1:...";
            I0 = 0;
            I1 = 0;
            A = 0;
            timer.Stop();
        }

        private void state_inicialized()
        {
            state = State.inicialized;
            //Clear all series
            this.chart_Datos.Series.Clear();
            //Add the Calibrate Series
            this.chart_Datos.Series.Add("calibrateSeries");
            //Add the Test Series
            this.chart_Datos.Series.Add("testSeries");
            this.groupBox_PuertoSerial.Enabled = false;
            this.groupBox_FlowControl.Enabled = true;
            this.groupBox_Data.Enabled = false;
            this.label_FlowPhase.Text = "Inicialized";
            this.button_Test.Enabled = true;
            this.button_Stop.Enabled = true;
            this.button_Calibrate.Enabled = true;
            this.button_Test.Enabled = false;
            this.button_Stop.Enabled = true;
        }

        private void state_calibrating()
        {
            state = State.calibrating;
            this.groupBox_PuertoSerial.Enabled = false;
            this.groupBox_FlowControl.Enabled = true;
            this.groupBox_Data.Enabled = true;
            this.button_Test.Enabled = false;
            this.button_Stop.Enabled = true;
            this.label_FlowPhase.Text = "Calibrating...";
            this.button_Calibrate.Enabled = false;
            this.button_Test.Enabled = false;
            this.button_Stop.Enabled = true;
        }

        private void state_calibrated()
        {
            state = State.calibrated;
            this.groupBox_PuertoSerial.Enabled = false;
            this.groupBox_FlowControl.Enabled = true;
            this.groupBox_Data.Enabled = true;
            this.button_Test.Enabled = true;
            this.button_Stop.Enabled = true;
            this.label_FlowPhase.Text = "Calibrated";
            this.label_Intensity0.Text = "I0: " + I0.ToString();
            this.button_Calibrate.Enabled = true;
            this.button_Test.Enabled = true;
            this.button_Stop.Enabled = true;
        }

        private void state_testing()
        {
            state = State.testing;
            this.groupBox_PuertoSerial.Enabled = false;
            this.groupBox_FlowControl.Enabled = true;
            this.groupBox_Data.Enabled = true;
            this.button_Test.Enabled = false;
            this.button_Stop.Enabled = true;
            this.label_FlowPhase.Text = "Testing...";
            this.button_Calibrate.Enabled = false;
            this.button_Test.Enabled = false;
            this.button_Stop.Enabled = true;
        }

        private void state_tested()
        {
            state = State.tested;
            this.groupBox_PuertoSerial.Enabled = false;
            this.groupBox_FlowControl.Enabled = true;
            this.groupBox_Data.Enabled = true;
            this.button_Test.Enabled = false;
            this.button_Stop.Enabled = true;
            this.label_FlowPhase.Text = "Tested...";
            this.label_Absorbance.Text = "Absorbance: " + A.ToString();
            this.label_Intensity0.Text = "I0: " + I0.ToString();
            this.label_Intensity1.Text = "I1: " + I1.ToString();
            this.button_Calibrate.Enabled = true;
            this.button_Test.Enabled = true;
            this.button_Stop.Enabled = true;
        }

        #endregion

        #region EVENTS

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            serial_combo(this.comboBox_Puertos);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serial_combo(this.comboBox_Puertos);
        }

        private void comboBox_Puertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            arduino = new Arduino((string)this.comboBox_Puertos.SelectedItem, 115200);
            if (arduino.Ready)
            {
                state_inicialized();
            }
            else
            {
                state_main();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(arduino != null)
                arduino.FinalizaComunicacion();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {//Test Button
            state_testing();
            arduino.StartLecture();
            timer.Start();
        }

        private void button_Calibrate_Click(object sender, EventArgs e)
        {
            //Inicializado, hay que calibrar
            state_calibrating();
            arduino.StartLecture();
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.toolStripProgressBar_Sampling.Value = arduino.NumValuesReady;
            this.toolStripStatusLabel_Sampling.Text = arduino.NumValuesReady.ToString() + "%";
            if (arduino.ValuesReady)
            {
                switch (state)
                {
                    case State.calibrating://Calibrated
                        valuesCalibrate = arduino.Values;
                        PutCalibrateValuesChart();
                        I0 = valuesCalibrate.Average();//Calculate I0
                        state_calibrated();
                        break;

                    case State.testing://Tested
                        valuesTest = arduino.Values;
                        PutTestValuesChart();
                        I1 = valuesTest.Average();//Calculate I1
                        A = (-1) * Math.Log10(I1 / I0);
                        state_tested();
                        break;
                }
                timer.Stop();
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            arduino.FinalizaComunicacion();
            state_main();
        }

        private void radioButton_ModeBasic_Click(object sender, EventArgs e)
        {
            Turn2BasicMode();
        }

        private void radioButton_ModeAdv_CheckedChanged(object sender, EventArgs e)
        {
            Turn2AdvancedMode();
        }

        #endregion

        #region METHODS

        //Metodo que primero limpia y despues llena la comboBox pasada como
        //parametro con los puertos serie disponibles
        private void serial_combo(ComboBox combo)
        {
            combo.Items.Clear();
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                combo.Items.Add(port);
            }
            combo.Text = "";
            combo.SelectedIndex = -1;
        }

        private void PutCalibrateValuesChart()
        {
            this.chart_Datos.Series["calibrateSeries"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            AddValuesToChartSeries("calibrateSeries", valuesCalibrate);
        }

        private void PutTestValuesChart()
        {
            this.chart_Datos.Series["testSeries"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            AddValuesToChartSeries("testSeries", valuesCalibrate);
        }

        /// <summary>
        /// Add to a Series of chart_Datos the data
        /// </summary>
        /// <param name="seriesName">string name of the Series</param>
        /// <param name="values">double[] of data to add</param>
        private void AddValuesToChartSeries(string seriesName, double[] values)
        {
            this.chart_Datos.Series[seriesName].Points.Clear();
            for (int i = 0; i < values.Length; i++)
                this.chart_Datos.Series[seriesName].Points.AddY(values[i]);
        }

        private void Turn2BasicMode()
        {
            //Hide Data GroupBox
            this.groupBox_Data.Visible = false;

            //Resize Form
            this.Size = new System.Drawing.Size(this.Size.Width, 310);
        }

        private void Turn2AdvancedMode()
        {
            //Show Data GroupBox
            this.groupBox_Data.Visible = true;

            //Resize Form
            this.Size = new System.Drawing.Size(this.Size.Width, 710);
        }

        #endregion









    }
}
