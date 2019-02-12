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
        /// Gets a value indicating whether this instance is filled.
        /// </summary>
        private bool Initialized
        {
            get;
        }

        private readonly string Hostname;
        private readonly string ApiKey;

        private RestClient Rest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cachet"/> class.
        /// </summary>
        /// <param name="Host">The host.</param>
        /// <param name="ApiKey">The API key.</param>
        public Cachet(string Host, string ApiKey)
        {
            this.Hostname       = Host;
            this.ApiKey         = ApiKey;

            this.Rest           = new RestClient(Host);
            this.Rest.AddDefaultHeader("X-Cachet-Token", ApiKey);

            this.Initialized    = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cachet"/> class.
        /// </summary>
        /// <param name="Host">The host.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Password">The password.</param>
        public Cachet(string Host, string Email, string Password)
        {
            this.Hostname       = Host;
            this.ApiKey         = ApiKey;

            this.Rest           = new RestClient(Host)
            {
                Authenticator   = new HttpBasicAuthenticator(Email, Password)
            };

            this.Initialized    = true;
        }

        /// <summary>
        /// Pings the Cachet API.
        /// </summary>
        public bool Ping()
        {
            if (this.Initialized == false)
            {
                return false;
            }

            var Request  = new RestRequest("ping");
            var Response = this.Rest.Get<PingResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var PingResponse = Response.Data;

                if (PingResponse.IsValid)
                {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Pings the Cachet API.
        /// </summary>
        public async Task<bool> PingAsync()
        {
            if (this.Initialized == false)
            {
                return false;
            }

            var Request  = new RestRequest("ping");
            var Response = await this.Rest.ExecuteGetTaskAsync<PingResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var PingResponse = Response.Data;

                if (PingResponse.IsValid)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the version of the Cachet API.
        /// </summary>
        public VersionResponse GetVersion()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request  = new RestRequest("version");
            var Response = this.Rest.Get<VersionResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var VersionResponse = Response.Data;

                if (VersionResponse != null)
                {
                    return VersionResponse;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the version of the Cachet API.
        /// </summary>
        public async Task<VersionResponse> GetVersionAsync()
        {
            if (this.Initialized == false)
            {
                return null;
            }

            var Request  = new RestRequest("version");
            var Response = await this.Rest.ExecuteGetTaskAsync<VersionResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var VersionResponse = Response.Data;

                if (VersionResponse != null)
                {
                    return VersionResponse;
                }
            }

            return null;
        }


        protected Resp GetItemsReq<Resp, Obj>(string apiPath)
            where Resp : GeneralCollectionResponse<Obj>, new()
            where Obj : class, Responses.Objects.ICachetItem, new()
        {
            {

                var Request = new RestRequest(apiPath );
                var Response = this.Rest.Get<Resp>(Request);

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

        }

        protected Resp GetItemReq<Resp,Obj>(string apiPath, int id)
            where Resp : GeneralSimpleResponse<Obj>, new()
            where Obj : class, Responses.Objects.ICachetItem, new()
        {
            {

                var Request = new RestRequest(apiPath + "{id}").AddUrlSegment("id", id);
                var Response = this.Rest.Get<Resp>(Request);

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

        }

        protected bool DeleteReq(string apiPath, int id)
        {
            var Request = new RestRequest(apiPath + "{id}")
                .AddUrlSegment("id", id)
                ;
            var Response = this.Rest.Delete(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            return false;

        }

        protected Resp UpdateReq<ReqObj,Resp>(string apiPath, ReqObj item)
            where ReqObj : Responses.Objects.ICachetItem
            where Resp : class, new()
        {

            var Request = new RestRequest(apiPath + "{id}")
                .AddUrlSegment("id", item.Id)
                .AddJsonBody(item);
            var Response = this.Rest.Put<Resp>(Request);

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

    }
}
