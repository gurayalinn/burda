using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace burda.Helpers
{
    public class RFID
    {
        private SerialPort _serialPort;
        private string _rfid;
        private string _portName;
        private int _baudRate;
        private int _dataBits;
        private Parity _parity;
        private StopBits _stopBits;
        private Handshake _handshake;
        private bool _received;
        private bool _connected;
        private bool _disposed;
        private byte[] _data;

        public RFID()
        {
            _portName = "COM3";
            _baudRate = 9600;
            _dataBits = 8;
            _parity = Parity.None;
            _stopBits = StopBits.One;
            _handshake = Handshake.None;
            _received = false;
            _connected = false;
            _disposed = false;
            _data = new byte[0];
        }

        public RFID(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits, Handshake handshake)
        {
            _portName = portName;
            _baudRate = baudRate;
            _dataBits = dataBits;
            _parity = parity;
            _stopBits = stopBits;
            _handshake = handshake;
            _received = false;
            _connected = false;
            _disposed = false;
            _data = new byte[0];
        }

        public bool Connect()
        {
            try
            {
                _serialPort = new SerialPort(_portName, _baudRate, _parity, _dataBits, _stopBits);
                _serialPort.Handshake = _handshake;
                _serialPort.DataReceived += DataReceivedHandler;
                _serialPort.Open();
                _connected = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RFID Connection error: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            if (_connected)
            {
                _serialPort.Close();
                _connected = false;
                Console.WriteLine("Disconnected from RFID Reader");

            }
        }

        public string Read()
        {
            if (_received)
            {
                _received = false;
                Console.WriteLine("RFID: " + _rfid);
                return _rfid;
            }
            return null;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int bytes = sp.BytesToRead;
            byte[] buffer = new byte[bytes];
            sp.Read(buffer, 0, bytes);
            _data = _data.Concat(buffer).ToArray();

            if (_data.Length >= 12)
            {
                _rfid = BitConverter.ToString(_data.Take(12).ToArray()).Replace("-", "");
                _received = true;
                _data = new byte[0];
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Disconnect();
                _disposed = true;
            }
        }

        public bool IsConnected() => _connected;

        public bool IsDisposed() => _disposed;

        public bool IsReceived() => _received;

        public string GetRFID() => _rfid;

        public string GetPortName() => _portName;

        public int GetBaudRate() => _baudRate;

        public int GetDataBits() => _dataBits;

        public Parity GetParity() => _parity;

        public StopBits GetStopBits() => _stopBits;

        public Handshake GetHandshake() => _handshake;

        public void SetPortName(string portName) => _portName = portName;

        public void SetBaudRate(int baudRate) => _baudRate = baudRate;

        public void SetDataBits(int dataBits) => _dataBits = dataBits;

        public void SetParity(Parity parity) => _parity = parity;

        public void SetStopBits(StopBits stopBits) => _stopBits = stopBits;

        public void SetHandshake(Handshake handshake) => _handshake = handshake;
    }
}