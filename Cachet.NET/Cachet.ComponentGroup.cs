﻿namespace Cachet.NET
{
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;

    using RestSharp;
    using RestSharp.Authenticators;

    public partial class Cachet
    {



        public ComponentGroupResponse NewComponentGroup(
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
                    return response;
                }
            }
            return null;
        }

        public ComponentGroupResponse UpdateComponentGroup(Responses.Objects.ComponentGroupObject item)
        {

            var Request = new RestRequest("components/groups/{id}")
                .AddUrlSegment("id", item.Id)
                .AddJsonBody(item);
            var Response = this.Rest.Put<ComponentGroupResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var response = Response.Data;

                if (response != null)
                {
                    return response;
                }
            }
            return null;
        }


        public bool DeleteComponentGroup(int id)
        {
            return DeleteReq("components/groups/", id);
        }



        /// <summary>
        /// Gets the groups of components of the Cachet API.
        /// </summary>
        public ComponentGroupResponse GetComponentGroup(int id)
        {

            var Request = new RestRequest("components/groups/{id}")
                .AddUrlSegment("id", id);
            var Response = this.Rest.Get<ComponentGroupResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var response = Response.Data;

                if (response != null)
                {
                    return response;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the groups of components of the Cachet API.
        /// </summary>
        public ComponentGroupsResponse GetComponentGroups()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request = new RestRequest("components/groups");
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
        public ComponentGroupsResponse GetComponentGroups(int ComponentGroupId)
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