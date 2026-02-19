namespace Fluenzi.Mattermost.Enums;

/// <summary>
/// Mattermost plugin runtime states.
/// </summary>
public enum PluginState
{
    NotRunning,
    Starting,
    Running,
    FailedToStart,
    FailedToStayRunning,
    Stopping,
}
