namespace Cachet.NET
{
    using System;
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;
    using RestSharp.Authenticators;

    public partial class Cachet
    {
        public MetricsResponse GetMetrics()
        {
            return GetItemsReq<MetricsResponse, MetricObject>("metrics");
            
        }

        public MetricObject GetMetric(int id)
        {
            return GetItemReq<MetricResponse, MetricObject>("metrics/", id);
            
        }

        public bool ExistsMetric(int id)
        {
            return ExistsItemReq<MetricResponse, MetricObject>("metrics/", id);

        }

        public MetricObject NewMetric(
         string name,
         string description,
         string suffix,
         int default_value = 0,
         bool display_chart = true
         )
        {

            var Request = new RestRequest("metrics").AddJsonBody(new
            {
                name = name,
                description = description,
                suffix = suffix,
                default_value = default_value,
                display_chart = display_chart

            });
            var Response = this.Rest.Post<MetricResponse>(Request);

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

        public MetricObject UpdateMetric(Responses.Objects.MetricObject item)
        {
            return UpdateReq<MetricResponse, MetricObject>("metrics/", item);
            
        }

        public bool DeleteMetric(int id)
        {

            return DeleteReq("metrics/", id);
        }

        public void AddMetricPoint(int metricId, double value, DateTime measured)
        {

            var Request = new RestRequest("metrics/{id}/points")
                .AddUrlSegment("id", metricId)
                .AddJsonBody(new
            {
                value = value,
                timestamp = ((DateTimeOffset)measured.ToUniversalTime()).ToUnixTimeSeconds().ToString()
            });
            var Response = this.Rest.Post<MetricResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
            }
            else
                throw new GeneralApiException();
        }


    }
}
