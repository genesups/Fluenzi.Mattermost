using System.Collections.Generic;
using System.Net.Http;
using Mattermost.Constants;
using System.Threading.Tasks;
using Mattermost.Models.Teams;

namespace Mattermost
{
    public partial class MattermostClient
    {
        /// <summary>
        /// Get team by specified identifier.
        /// </summary>
        /// <param name="teamId"> Team identifier. </param>
        /// <returns> Team information. </returns>
        public Task<Team> GetTeamAsync(string teamId)
        {
            return SendRequestAsync<Team>(HttpMethod.Get, Routes.Teams + "/" + teamId);
        }

        /// <summary>
        /// Get teams for the current user.
        /// </summary>
        /// <param name="page"> Page number (0-based). </param>
        /// <param name="perPage"> Number of teams per page. </param>
        /// <returns> List of teams the user is a member of. </returns>
        public Task<IReadOnlyList<Team>> GetMyTeamsAsync(int page = 0, int perPage = 60)
        {
            CheckDisposed();
            string url = Routes.Users + "/me/teams?page=" + page + "&per_page=" + perPage;
            return SendRequestAsync<IReadOnlyList<Team>>(HttpMethod.Get, url);
        }
    }
}
