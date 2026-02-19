namespace Fluenzi.Mattermost.Enums;

/// <summary>
/// Mattermost server job statuses.
/// </summary>
public enum JobStatus
{
    Pending,
    InProgress,
    Success,
    Error,
    CancelRequested,
    Canceled,
    Warning,
}
