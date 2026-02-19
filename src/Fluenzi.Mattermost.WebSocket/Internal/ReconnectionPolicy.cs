namespace Fluenzi.Mattermost.WebSocket.Internal;

internal sealed class ReconnectionPolicy
{
    private readonly TimeSpan _minDelay;
    private readonly TimeSpan _maxDelay;
    private readonly int _maxAttempts;
    private readonly Random _jitter = new();
    private int _attempt;

    public ReconnectionPolicy(WebSocketClientOptions options)
    {
        _minDelay = options.ReconnectMinDelay;
        _maxDelay = options.ReconnectMaxDelay;
        _maxAttempts = options.MaxReconnectAttempts;
    }

    public int Attempt => _attempt;
    public bool CanRetry => _attempt < _maxAttempts;

    public TimeSpan NextDelay()
    {
        var baseDelay = Math.Min(
            _minDelay.TotalMilliseconds * Math.Pow(2, _attempt),
            _maxDelay.TotalMilliseconds);

        var jitter = _jitter.Next(0, 500);
        _attempt++;

        return TimeSpan.FromMilliseconds(baseDelay + jitter);
    }

    public void Reset() => _attempt = 0;
}
