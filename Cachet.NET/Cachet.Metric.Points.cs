namespace Cachet.NET
{
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;
    using RestSharp.Authenticators;

    public partial class Cachet
    {
        public GetPointsResponse GetPoints(int MetricId)
        {
            return GetItemsReq<GetPointsResponse, PointObject>("metrics/" + MetricId + "/points");
        }
        public PointObject NewPoint(int MetricId, int value)
        {
            var Request = new RestRequest("metrics/" + MetricId + "/points").AddJsonBody(new
            {
                value = value
            });
            var Response = Rest.Post<AddPointResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var metricResponse = Response.Data;

                if (metricResponse != null)
                {
                    return metricResponse.Data;
                }
            }
            return null;
        }
        public bool DeletePoint(int MetricId, int pointId)
        {
            return DeleteReq("metrics/" + MetricId + "/points/", pointId);
        }
    }
}
