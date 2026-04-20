using System.IO.Ports;

namespace ScaleLink.Services;

/// <summary>RS-232C重量受信サービス（シングルトン）</summary>
public class SerialPortService : IDisposable
{
    private static SerialPortService? _instance;
    private static readonly object _lock = new();

    private SerialPort? _port;
    private System.Windows.Forms.Timer? _timer;
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

    /// <summary>シリアルポートを開いて受信を開始する</summary>
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

            // UIスレッドで1秒ごとにイベント発火
            _timer = new System.Windows.Forms.Timer { Interval = 1000 };
            _timer.Tick += OnTimer;
            _timer.Start();
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

    private void OnTimer(object? sender, EventArgs e)
    {
        WeightReceived?.Invoke(this, new WeightReceivedEventArgs(_lastWeight, _status));
    }

    /// <summary>シリアルポートをクローズする</summary>
    public void Stop()
    {
        _timer?.Stop();
        _timer?.Dispose();
        if (_port?.IsOpen == true)
            _port.Close();
        _port?.Dispose();
        _status = WeightStatus.Disconnected;
    }

    public void Dispose() => Stop();
}

/// <summary>重量受信イベント引数</summary>
public class WeightReceivedEventArgs(decimal weight, WeightStatus status) : EventArgs
{
    public decimal Weight { get; } = weight;
    public WeightStatus Status { get; } = status;
}

/// <summary>重量受信ステータス</summary>
public enum WeightStatus
{
    Stable,       // 安定
    Unstable,     // 計量中
    Error,        // 受信エラー
    Disconnected, // 未接続
}
