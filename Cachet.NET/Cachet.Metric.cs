namespace Cachet.NET
{
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;

    using RestSharp;
    using RestSharp.Authenticators;

    public partial class Cachet
    {
        public MetricsResponse GetMetrics()
        {

            var Request = new RestRequest("metrics");
            var Response = this.Rest.Get<MetricsResponse>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                var metricsResponse = Response.Data;

                if (metricsResponse != null)
                {
                    return metricsResponse;
                }
            }

            return null;
        }

        public MetricResponse GetMetric(int id)
        {

            var Request = new RestRequest("metrics/{id}").AddUrlSegment("id", id);
            var Response = this.Rest.Get<MetricResponse>(Request);

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

            var Request = new RestRequest("metrics/{id}")
                .AddUrlSegment("id", item.Id)
                .AddJsonBody(item);
            var Response = this.Rest.Put<MetricResponse>(Request);

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

        public bool DeleteMetric(int id)
        {

            return DeleteReq("metrics/", id);
        }


    }
}
