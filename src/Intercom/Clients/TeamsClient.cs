using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intercom.Core;
using Intercom.Data;
using Intercom.Factories;

namespace Intercom.Clients
{
    public class TeamsClient : Client
    {
        private const String TEAMS_RESOURCE = "teams";

        public TeamsClient(RestClientFactory restClientFactory)
            : base (TEAMS_RESOURCE, restClientFactory)
        {
        }

        [Obsolete("This constructor is deprecated as of 3.0.0 and will soon be removed, please use AdminsClient(RestClientFactory restClientFactory)")]
        public TeamsClient(Authentication authentication)
            : base(INTERCOM_API_BASE_URL, TEAMS_RESOURCE, authentication)
        {
        }

        [Obsolete("This constructor is deprecated as of 3.0.0 and will soon be removed, please use AdminsClient(RestClientFactory restClientFactory)")]
        public TeamsClient(String intercomApiUrl, Authentication authentication)
            : base(String.IsNullOrEmpty(intercomApiUrl) ? INTERCOM_API_BASE_URL : intercomApiUrl, TEAMS_RESOURCE, authentication)
        {
        }

        public Teams List ()
        {
            ClientResponse<Teams> result = null;
            result = Get<Teams> ();
            return result.Result;
        }

        public Teams List (Dictionary<String, String> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException (nameof(parameters));
            }

            if (!parameters.Any())
            {
                throw new ArgumentException ("'parameters' argument is empty.");
            }

            ClientResponse<Teams> result = null;
            result = Get<Teams> ();
            return result.Result;
        }

        public Team View (String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException (nameof(id));
            }

            ClientResponse<Team> result = null;
            result = Get<Team> (resource: TEAMS_RESOURCE + Path.DirectorySeparatorChar + id);
            return result.Result;
        }

        public Team View(Team team)
        {
            if (team == null) {
                throw new ArgumentNullException (nameof(team));
            }

            if (String.IsNullOrEmpty(team.id))
            {
                throw new ArgumentException ("you must provide value for 'team.id'.");
            }

            ClientResponse<Team> result = null;
            result = Get<Team> (resource: TEAMS_RESOURCE + Path.DirectorySeparatorChar + team.id);
            return result.Result;  
        }
    }
}