namespace Fluenzi.Mattermost.Constants;

public static class ApiLimits
{
    public const int MaxPostMessageLength = 16383;
    public const int MaxFileSize = 100 * 1024 * 1024;
    public const int DefaultPerPage = 60;
    public const int MaxPerPage = 200;
    public const int MaxUsersPerBatch = 200;
    public const int DefaultChannelPerPage = 200;
}
