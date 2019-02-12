namespace Cachet.NET
{
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

        public MetricResponse GetMetric(int id)
        {
            return GetItemReq<MetricResponse, MetricObject>("metrics/", id);
            
        }


        public MetricResponse NewMetric(
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
                    return metricResponse;
                }
            }
            return null;
        }

        public MetricResponse UpdateMetric(Responses.Objects.MetricObject item)
        {
            return UpdateReq<Responses.Objects.MetricObject, MetricResponse>("metrics/", item);
            
        }

        public bool DeleteMetric(int id)
        {

            return DeleteReq("metrics/", id);
        }


    }
}
