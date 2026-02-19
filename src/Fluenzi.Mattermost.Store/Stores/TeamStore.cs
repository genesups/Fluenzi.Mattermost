using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Teams;

namespace Fluenzi.Mattermost.Store.Stores;

public class TeamStore : EntityStore<string, Team>, ITeamStore { }
