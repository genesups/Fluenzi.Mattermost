namespace Fluenzi.Mattermost.Enums;

/// <summary>
/// Mattermost channel types.
/// </summary>
public enum ChannelType
{
    /// <summary>Public channel ("O")</summary>
    Open,

    /// <summary>Private channel ("P")</summary>
    Private,

    /// <summary>Direct message channel ("D")</summary>
    Direct,

    /// <summary>Group message channel ("G")</summary>
    Group,
}

/// <summary>
/// Extension methods for converting <see cref="ChannelType"/> to and from API string representations.
/// </summary>
public static class ChannelTypeExtensions
{
    /// <summary>
    /// Converts the <see cref="ChannelType"/> to its single-character API string representation.
    /// </summary>
    public static string ToApiString(this ChannelType channelType) => channelType switch
    {
        ChannelType.Open => "O",
        ChannelType.Private => "P",
        ChannelType.Direct => "D",
        ChannelType.Group => "G",
        _ => throw new ArgumentOutOfRangeException(nameof(channelType), channelType, "Unknown channel type."),
    };

    /// <summary>
    /// Converts a single-character API string to its <see cref="ChannelType"/> representation.
    /// </summary>
    public static ChannelType FromApiString(string apiString) => apiString switch
    {
        "O" => ChannelType.Open,
        "P" => ChannelType.Private,
        "D" => ChannelType.Direct,
        "G" => ChannelType.Group,
        _ => throw new ArgumentOutOfRangeException(nameof(apiString), apiString, "Unknown channel type string."),
    };
}
