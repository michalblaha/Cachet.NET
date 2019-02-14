namespace Cachet.NET
{
    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;
    using RestSharp.Authenticators;
    using System;
    using System.Threading.Tasks;

    public partial class Cachet
    {


        /// <summary>
        /// Gets a list of incidents from the Cachet API.
        /// </summary>
        public IncidentsResponse GetIncidents(
            IncidentStatus? filterStatus = null,
            int? filterComponent_id = null,
            string sort = "null", bool desc = false
            )
        {
            string query = "";
            if (filterStatus.HasValue)
                query += "status=" + ((int)filterStatus.Value).ToString();
            if (filterComponent_id.HasValue)
            {
                query += query == "" ? "" : "&";
                query += "component_id=" + filterComponent_id.Value.ToString();
            }
            return GetItemsReq<IncidentsResponse, IncidentObject>("incidents", query, sort, desc);

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
        /// <param name="id">The Incident identifier.</param>
        public IncidentObject GetIncident(int id)
        {

            return GetItemReq<IncidentResponse, IncidentObject>("incidents/", id);

        }
        public IncidentObject UpdateIncident(IncidentObject item)
        {
            return UpdateReq<IncidentResponse, IncidentObject>("incidents/", item);

        }


        public bool ExistsIncident(int id)
        {

            return ExistsItemReq<IncidentResponse, IncidentObject>("incidents/", id);

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


        public IncidentObject NewIncident(
             string name,
             string message,
             IncidentStatus status,
             bool visible,
             int component_id = 0,
             ComponentStatus? component_status = null,
             bool notifySubscribers = false,
             DateTime? created_at = null,
             string template = "",
             string[] vars = null
         )
        {

            var Request = new RestRequest("incidents").AddJsonBody(new
            {
                name = name,
                message = message,
                status = (int)status,
                visible = visible ? 1 : 0,
                component_id = component_id,
                component_status = ((int?)component_status) ?? 0,
                notify = notifySubscribers,
                created_at = created_at ?? DateTime.Now,
                template = template ?? "",
                vars = vars ?? new string[] { }
            });
            var Response = this.Rest.Post<IncidentResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var resp = Response.Data;

                if (resp != null)
                {
                    return resp?.Data;
                }
            }
            return null;
        }


        public bool AddIncidentUpdate(
             int incidentId,
             string message,
             IncidentStatus status
         )
        {

            var Request = new RestRequest("incidents/{id}/updates")
                .AddUrlSegment("id", incidentId)
                .AddJsonBody(new
                {
                    message = message,
                    status = (int)status,
                });
            var Response = this.Rest.Post<IncidentResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var resp = Response.Data;

                return resp != null;
            }
            return false;
        }


    }
}
