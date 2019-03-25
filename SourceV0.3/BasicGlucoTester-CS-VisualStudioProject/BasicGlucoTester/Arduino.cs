using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace BasicGlucoTester
{
    class Arduino
    {
        SerialPort serialPort;
        Timer timer;
        bool ok;
        bool valuesready = false;
        int numvaluesready = 0;
        double[] values;
        

        public Arduino(string portname, int bauds)
        {
            try
            {
                serialPort = new SerialPort(portname, bauds);
                timer = new Timer();
                timer.Interval = 50;                            //Lapsos de 50ms para el timer
                timer.Tick += timer_Tick;
                ok = true;
                ok = Inicializa_Comunicacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la asignacion del puerto del arduino. " + ex, "Error de Inicializacion de Puerto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
        }



        #region PROPIEDADES PUBLICAS

        public void FinalizaComunicacion()
        {
            if (ok)
            {
                timer.Stop();
                Stop();
                CierraPuerto();
                ok = false;
            }
            else
            {
                TryToStop();
            }
        }

        public void StartLecture()
        {
            timer.Start();
            valuesready = false;
            numvaluesready = 0;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            RecorreArray(GetLectura());
            numvaluesready++;
            if (numvaluesready >= 100)
            {
                timer.Stop();
                valuesready = true;
            }
        }

        #endregion

        #region PROPIEDADES PRIVADAS

        private bool Inicializa_Comunicacion()
        {
            if (ok)
            {
                try
                {
                    if (!serialPort.IsOpen) //Si el puerto esta cerrado
                        serialPort.Open();
                    serialPort.ReadTimeout = 45;            //TimeOut in ms
                    serialPort.Write("S");                  //Put Board in  Stop or Initilice mode before try anything
                    serialPort.Write("square");
                    values = new double[100];
                    if (serialPort.ReadChar() == 'a')
                    {
                        ;//MessageBox.Show("Comunicacion Establecida", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in the assignation of UART Port. PLEASE SELECT THE CORRECT UART PORT AND REBOOT THE BOARD. This error can happen also if uncorrect Firmware was loaded in the BOARD.\nOriginal ERROR: " + ex, "UART initisialisation ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TryToStop();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void CierraPuerto()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }

        private void Stop()
        {
            if (ok)
            {
                serialPort.Write("S");
            }
        }

        private double GetLectura()
        {
            int lectura = -1;
            double volts = -1;
            try
            {
                if (ok)
                {
                    timer.Stop();                           //Stop Timer while we read values and make operations
                    serialPort.Write("b");
                    lectura = Convert.ToInt32(serialPort.ReadLine());
                    
                    //Arduino is adjusted to 5V reference, 10bit converter going to return values between 0 for 0V and 1023 for 5V
                    //3.3V -> 1023bits, 0V -> 0bits, [(x)(3.3)/1023]V -> xbits, [(x)(0.0032258) -> xbits]
                    //THIS CONVERTION HAS A ACCURACY OF 5 DECIMALS
                    volts = lectura * 0.0032258;
                    if (volts < 0)
                        volts = 0;
                }
            }
            catch (TimeoutException exTE)
            {//Time Out
                volts = 0;
            }
            catch (Exception ex)
            {//If is other type of exception, then close application
                timer.Stop();
                MessageBox.Show("Internal Error while trying to Read an ADC value.\nPLEASE REBOOT THE BOARD\nOriginal Error: " + ex + "\nTHIS APPLICATION IS GOING TO CLOSE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {//Get sure any byte is un Serial Buffer
                if (serialPort.IsOpen)
                    serialPort.DiscardInBuffer();
                timer.Start();                      //Activate timer again
            }
            return volts;
        }

        private void TryToStop()
        {
            try
            {
                serialPort.Write("S");
            }
            catch
            {
                ;
            }
        }

        private void RecorreArray(double newValue)
        {
            for (int i = (values.Length - 1); i > 0; i--)
                values[i] = values[i - 1];
            values[0] = newValue;
        }

        #endregion

        #region PROPIEDADES PUBLICAS

        /// <summary>
        /// Indica cuando el Array de 100 valores está listo despues de indicar la lectura
        /// </summary>
        public bool ValuesReady
        {
            get
            {
                return valuesready;
            }
        }

        /// <summary>
        /// Indica el numero de valores que se tienen leidos hasta ese momento despues de indicar el inicio de la lectura
        /// </summary>
        public int NumValuesReady
        {
            get
            {
                return numvaluesready;
            }
        }

        public bool Ready
        {
            get
            {
                return ok;
            }
        }

        public double[] Values
        {
            get
            {
                return values;
            }
        }

        #endregion
    }
}
