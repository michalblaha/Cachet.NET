namespace Cachet.NET
{
    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;
    using RestSharp.Authenticators;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
            this.Hostname = Host;
            this.ApiKey = ApiKey;

            this.Rest = new RestClient(Host);
            this.Rest.AddDefaultHeader("X-Cachet-Token", ApiKey);

            this.Initialized = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cachet"/> class.
        /// </summary>
        /// <param name="Host">The host.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Password">The password.</param>
        public Cachet(string Host, string Email, string Password)
        {
            this.Hostname = Host;
            this.ApiKey = ApiKey;

            this.Rest = new RestClient(Host)
            {
                Authenticator = new HttpBasicAuthenticator(Email, Password)
            };

            this.Initialized = true;
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

            var Request = new RestRequest("ping");
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

            var Request = new RestRequest("ping");
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

            var Request = new RestRequest("version");
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

            var Request = new RestRequest("version");
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

        protected T ProcessResponse<T>(IRestResponse<T> Response)
            where T: class
        {

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    return Response.Data;
                else if (Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new NotFoundException(Response.ErrorMessage, Response.ErrorException)
                    {
                        ResponseStatus = Response.ResponseStatus.ToString(),
                        StatusCode = Response.StatusCode
                    };
                else if (Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new UnauthorizedException(Response.ErrorMessage, Response.ErrorException)
                    {
                        ResponseStatus = Response.ResponseStatus.ToString(),
                        StatusCode = Response.StatusCode
                    };
                else
                    throw new GeneralApiException(Response.ErrorMessage, Response.ErrorException)
                    {
                        ResponseStatus = Response.ResponseStatus.ToString(),
                        StatusCode = Response.StatusCode
                    };

            }
            else
                throw new GeneralApiException(Response.ErrorMessage, Response.ErrorException)
                {
                    ResponseStatus = Response.ResponseStatus.ToString(),
                    StatusCode = Response.StatusCode
                };
        }

        protected Resp GetItemsReq<Resp, Obj>(string apiPath, string searchQuery = null, string sort = null, bool desc = false, int per_page = 1000)
            where Resp : GeneralCollectionResponse<Obj>, new()
            where Obj : class, Responses.Objects.ICachetItem, new()
        {
            if (apiPath.Contains("?"))
                apiPath += "&per_page=" + per_page;
            else
                apiPath += "?per_page=" + per_page;


            if (!string.IsNullOrEmpty(searchQuery))
                apiPath += searchQuery + "&";
            if (!string.IsNullOrEmpty(sort))
                apiPath += sort + "&order=" + (desc ? "desc" : "asc") + "&";

            var Request = new RestRequest(apiPath);
            var Response = this.Rest.Get<Resp>(Request);

            return ProcessResponse(Response);

        }

        protected Obj GetItemReq<Resp, Obj>(string apiPath, int id)
            where Resp : GeneralSimpleResponse<Obj>, new()
            where Obj : class, Responses.Objects.ICachetItem, new()
        {
            {
                var Request = new RestRequest(apiPath + "{id}")
                    .AddUrlSegment("id", id);
                IRestResponse<Resp> Response = this.Rest.Get<Resp>(Request);
                return ProcessResponse(Response)?.Data;
            }

        }

        protected bool ExistsItemReq<Resp, Obj>(string apiPath, int id)
          where Resp : GeneralSimpleResponse<Obj>, new()
          where Obj : class, Responses.Objects.ICachetItem, new()
        {


            var Request = new RestRequest(apiPath + "{id}").AddUrlSegment("id", id);
            var Response = this.Rest.Get<Resp>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.StatusCode == System.Net.HttpStatusCode.OK;
            }

            return false;

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

        protected Obj UpdateReq<Resp, Obj>(string apiPath, Obj item)
            where Resp : GeneralSimpleResponse<Obj>, new()
            where Obj : class, Responses.Objects.ICachetItem, new()
        {

            var Request = new RestRequest(apiPath + "{id}")
                .AddUrlSegment("id", item.Id)
                .AddJsonBody(item)
                ;
            Request.JsonSerializer = new Util.JsonSerializer();

            var Response = this.Rest.Put<Resp>(Request);

            return ProcessResponse(Response)?.Data;


        }

    }
}
