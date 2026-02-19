namespace Fluenzi.Mattermost.WebSocket.Internal;

internal sealed class SequenceTracker
{
    private int _lastSeq;
    private readonly Action<int, int>? _onGapDetected;

    public SequenceTracker(Action<int, int>? onGapDetected = null)
    {
        _onGapDetected = onGapDetected;
    }

    public int LastSequence => _lastSeq;

    public void Track(int seq)
    {
        if (_lastSeq > 0 && seq > _lastSeq + 1)
        {
            _onGapDetected?.Invoke(_lastSeq, seq);
        }
        _lastSeq = seq;
    }

    public void Reset() => _lastSeq = 0;
}
