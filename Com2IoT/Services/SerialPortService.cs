using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com2IoT.Services
{
    public class SerialPortService
    {
        public SerialPort _serialPort { get; set; }
        public bool WriteLine { get; set; }
        public bool SendByEnter { get; set; }
        public bool LogToTxt { get; set; }
        public bool ViewData { get; set; }

        public SerialPortService(int writeTimeout, int readTimeout)
        {
            _serialPort = new SerialPort();
            _serialPort.WriteTimeout = writeTimeout;
            _serialPort.ReadTimeout = readTimeout;
        }

        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames().ToArray();
        }

        public bool OpenPort(string portName, string rate, string dataBits, string stopBits, string parityBits)
        {
            try
            {
                _serialPort.PortName = portName;
                _serialPort.BaudRate = Convert.ToInt32(rate);
                _serialPort.DataBits = Convert.ToInt32(dataBits);
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parityBits);
                _serialPort.Open();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ClosePort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SendData(string data)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    if (WriteLine)
                    {
                        _serialPort.WriteLine(data);
                    }
                    else
                    {
                        _serialPort.Write(data);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string ReadData()
        {
            return _serialPort.ReadExisting();
        }
    }
}
