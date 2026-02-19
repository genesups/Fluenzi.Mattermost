using System.Text.Json;
using Fluenzi.Mattermost.Enums;

namespace Fluenzi.Mattermost.Events;

public record WebSocketEventEnvelope(
    WebSocketEventType EventType,
    string RawEventName,
    int Sequence,
    JsonElement Data,
    JsonElement Broadcast);

public abstract record WebSocketEvent;
