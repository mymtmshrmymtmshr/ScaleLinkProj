using System.IO.Ports;
using System.Threading;

namespace ScaleLink.Services;

/// <summary>RS-232C weight reception service (Singleton)</summary>
public class SerialPortService : IDisposable
{
    private static SerialPortService? _instance;
    private static readonly object _lock = new();

    private SerialPort? _port;
    private Timer? _timer;
    private decimal _lastWeight;
    private WeightStatus _status = WeightStatus.Disconnected;

    public event EventHandler<WeightReceivedEventArgs>? WeightReceived;

    private SerialPortService() { }

    public static SerialPortService Instance
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new SerialPortService();
                return _instance;
            }
        }
    }

    public WeightStatus Status => _status;
    public decimal LastWeight => _lastWeight;

    /// <summary>Open serial port and start reception</summary>
    public void Start(string portName, int baudRate = 9600, int dataBits = 8,
        Parity parity = Parity.None, StopBits stopBits = StopBits.One)
    {
        try
        {
            _port = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
            {
                ReadTimeout  = 500,
                WriteTimeout = 500,
            };
            _port.DataReceived += OnDataReceived;
            _port.Open();
            _status = WeightStatus.Stable;

            // Fire event every 1 second
            _timer = new Timer(OnTimer, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        catch
        {
            _status = WeightStatus.Error;
        }
    }

    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            var raw = _port!.ReadLine().Trim();
            if (decimal.TryParse(raw, out var weight))
            {
                _lastWeight = weight;
                _status = WeightStatus.Stable;
            }
            else
            {
                _status = WeightStatus.Unstable;
            }
        }
        catch
        {
            _status = WeightStatus.Error;
        }
    }

    private void OnTimer(object? state)
    {
        WeightReceived?.Invoke(this, new WeightReceivedEventArgs(_lastWeight, _status));
    }

    /// <summary>Close serial port</summary>
    public void Stop()
    {
        _timer?.Dispose();
        if (_port?.IsOpen == true)
            _port.Close();
        _port?.Dispose();
        _status = WeightStatus.Disconnected;
    }

    public void Dispose() => Stop();
}

/// <summary>Weight reception event args</summary>
public class WeightReceivedEventArgs(decimal weight, WeightStatus status) : EventArgs
{
    public decimal Weight { get; } = weight;
    public WeightStatus Status { get; } = status;
}

/// <summary>Weight reception status</summary>
public enum WeightStatus
{
    Stable,       // Stable
    Unstable,     // Measuring
    Error,        // Reception error
    Disconnected, // Disconnected
}
