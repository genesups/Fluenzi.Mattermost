using Fluenzi.Mattermost.Events;
using Fluenzi.Mattermost.Enums;

namespace Fluenzi.Mattermost.Interfaces.WebSocket;

public interface IWebSocketEventStream
{
    IObservable<WebSocketEventEnvelope> Events { get; }
    IObservable<ConnectionState> ConnectionStateChanged { get; }
    IObservable<T> OfType<T>() where T : WebSocketEvent;
}
