using Fluenzi.Mattermost.Models.Preferences;

namespace Fluenzi.Mattermost.Events;

public record PreferencesChangedEvent(IReadOnlyList<Preference> Preferences) : WebSocketEvent;
public record PreferencesDeletedEvent(IReadOnlyList<Preference> Preferences) : WebSocketEvent;
