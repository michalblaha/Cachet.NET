namespace Cachet.NET
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;
    using RestSharp.Authenticators;

    public partial class Cachet
    {
        /// <summary>
        /// Gets the components of the Cachet API.
        /// </summary>
        public ComponentsResponse GetComponents()
        {
            return GetItemsReq<ComponentsResponse, ComponentObject>("components/");
        }


        /// <summary>
        /// Gets the components of the Cachet API.
        /// </summary>
        public async Task<ComponentsResponse> GetComponentsAsync()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("components");
            var Response = await this.Rest.ExecuteGetTaskAsync<ComponentsResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var ComponentsResponse = Response.Data;

                if (ComponentsResponse != null)
                {
                    return ComponentsResponse;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the specified component of the Cachet API.
        /// </summary>
        /// <param name="id">The component identifier.</param>
        public ComponentObject GetComponent(int id)
        {
            return GetItemReq<ComponentResponse, ComponentObject>("components/", id);
        }

        public bool ExistsComponent(int id)
        {
            return ExistsItemReq<ComponentResponse, ComponentObject>("components/", id);
        }

        public ComponentObject NewComponent(
            string name,
            string description,
            Responses.Objects.ComponentStatus status,
            string link,
            int order = 0,
            int group_id = 0,
            bool enabled = true
            )
        {

            var Request = new RestRequest("components").AddJsonBody(new
            {
                name = name,
                description = description,
                status = (int)status,
                link = link,
                order = order,
                group_id = group_id,
                enabled = enabled
            });
            var Response = this.Rest.Post<ComponentResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var ComponentResponse = Response.Data;

                if (ComponentResponse != null)
                {
                    return ComponentResponse?.Data;
                }
            }
            return null;
        }

        public ComponentObject UpdateComponent(Responses.Objects.ComponentObject item)
        {
            return UpdateReq<ComponentResponse, ComponentObject>("components/", item);
            
        }


        public bool DeleteComponent(int id)
        {

            return DeleteReq("components/", id);

        }


        /// <summary>
        /// Gets the specified component of the Cachet API.
        /// </summary>
        /// <param name="ComponentId">The component identifier.</param>s
        public async Task<ComponentResponse> GetComponentAsync(int ComponentId)
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("components/{componentId}").AddUrlSegment("componentId", ComponentId);
            var Response = await this.Rest.ExecuteGetTaskAsync<ComponentResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var ComponentResponse = Response.Data;

                if (ComponentResponse != null)
                {
                    return ComponentResponse;
                }
            }

            return null;
        }


    }
}
