using System.IO.Ports;
using System;
namespace SMKSimulator
   
{
   public class ComPort:SerialPort
    {
      public  ComPort()
        {

        }
        public void setParameters(int baud, string portname) 
        {
            this.BaudRate = baud;
            this.PortName = portname;
            this.ReadTimeout = 5000;
            this.WriteTimeout = 15000;
            this.DtrEnable = true;
            this.RtsEnable = true;
            if (!this.IsOpen) this.Open();
        }
    }
}
