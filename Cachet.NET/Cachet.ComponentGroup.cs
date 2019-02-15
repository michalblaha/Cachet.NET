namespace Cachet.NET
{
    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;
    using RestSharp.Authenticators;
    using System.Threading.Tasks;

    public partial class Cachet
    {



        public ComponentGroupObject NewComponentGroup(
         string name,
         Responses.Objects.ComponentGroupObject.CollapsedType collapsed,
         int order = 0
         )
        {

            var Request = new RestRequest("components/groups").AddJsonBody(new
            {
                name = name,
                order = order,
                collapsed = (int)collapsed
            });
            var Response = this.Rest.Post<ComponentGroupResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var response = Response.Data;

                if (response != null)
                {
                    return response.Data;
                }
            }
            return null;
        }

        public ComponentGroupObject UpdateComponentGroup(Responses.Objects.ComponentGroupObject item)
        {
            return UpdateReq<ComponentGroupResponse, ComponentGroupObject>("components/groups/", item);

        }


        public bool DeleteComponentGroup(int id)
        {
            return DeleteReq("components/groups/", id);
        }



        /// <summary>
        /// Gets the groups of components of the Cachet API.
        /// </summary>
        public ComponentGroupObject GetComponentGroup(int id)
        {
            return GetItemReq<ComponentGroupResponse, ComponentGroupObject>("components/groups/", id);
        }
        public bool ExistsComponentGroup(int id)
        {
            return ExistsItemReq<ComponentGroupResponse, ComponentGroupObject>("components/groups/", id);

        }


        /// <summary>
        /// Gets the groups of components of the Cachet API.
        /// </summary>
        public ComponentGroupsResponse GetComponentGroups()
        {
            return GetItemsReq<ComponentGroupsResponse, ComponentGroupObject>("components/groups");

        }

        /// <summary>
        /// Gets the groups of components of the Cachet API.
        /// </summary>
        public async Task<ComponentGroupsResponse> GetComponentGroupsAsync()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("components/groups");
            var Response = await this.Rest.ExecuteGetTaskAsync<ComponentGroupsResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var ComponentGroupsResponse = Response.Data;

                if (ComponentGroupsResponse != null)
                {
                    return ComponentGroupsResponse;
                }
            }

            return null;
        }


        /// <summary>
        /// Gets the specified group of components of the Cachet API.
        /// </summary>
        /// <param name="ComponentGroupId">The component group identifier.</param>
        public async Task<ComponentGroupsResponse> GetComponentGroupsAsync(int ComponentGroupId)
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("components/groups/{componentGroupId}").AddUrlSegment("componentGroupId", ComponentGroupId);
            var Response = this.Rest.Get<ComponentGroupsResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var ComponentGroupsResponse = Response.Data;

                if (ComponentGroupsResponse != null)
                {
                    return ComponentGroupsResponse;
                }
            }

            return null;
        }


    }
}
