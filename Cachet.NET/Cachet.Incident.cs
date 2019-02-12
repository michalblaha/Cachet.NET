﻿namespace Cachet.NET
{
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;

    using RestSharp;
    using RestSharp.Authenticators;

    public partial class Cachet
    {


        /// <summary>
        /// Gets a list of incidents from the Cachet API.
        /// </summary>
        public IncidentsResponse GetIncidents()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("incidents");
            var Response = this.Rest.Get<IncidentsResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var incidentsResponse = Response.Data;

                if (incidentsResponse != null)
                {
                    return incidentsResponse;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the Incidents of the Cachet API.
        /// </summary>
        public async Task<IncidentsResponse> GetIncidentsAsync()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("incidents");
            var Response = await this.Rest.ExecuteGetTaskAsync<IncidentsResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var incidentsResponse = Response.Data;

                if (incidentsResponse != null)
                {
                    return incidentsResponse;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the specified Incident of the Cachet API.
        /// </summary>
        /// <param name="IncidentId">The Incident identifier.</param>
        public IncidentResponse GetIncident(int IncidentId)
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("incidents/{incidentId}").AddUrlSegment("incidentId", IncidentId);
            var Response = this.Rest.Get<IncidentResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var IncidentResponse = Response.Data;

                if (IncidentResponse != null)
                {
                    return IncidentResponse;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the specified Incident of the Cachet API.
        /// </summary>
        /// <param name="IncidentId">The Incident identifier.</param>s
        public async Task<IncidentResponse> GetIncidentAsync(int IncidentId)
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("incidents/{incidentId}").AddUrlSegment("incidentId", IncidentId);
            var Response = await this.Rest.ExecuteGetTaskAsync<IncidentResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var IncidentResponse = Response.Data;

                if (IncidentResponse != null)
                {
                    return IncidentResponse;
                }
            }

            return null;
        }

    }
}