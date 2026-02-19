using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

public record IPFilterRule
{
    [JsonPropertyName("cidr_block")] public string CidrBlock { get; init; } = "";
    [JsonPropertyName("description")] public string Description { get; init; } = "";
    [JsonPropertyName("enabled")] public bool Enabled { get; init; }
    [JsonPropertyName("owner_id")] public string OwnerId { get; init; } = "";
}

public record IPFilterConfig
{
    [JsonPropertyName("current_ip")] public string CurrentIp { get; init; } = "";
    [JsonPropertyName("allowed_ranges")] public IReadOnlyList<IPFilterRule> AllowedRanges { get; init; } = [];
}
