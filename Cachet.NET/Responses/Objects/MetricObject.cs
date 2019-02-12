using RestSharp.Deserializers;

namespace Cachet.NET.Responses.Objects
{
    using System;

    public class MetricObject : ICachetItem
    {
        public enum  MetricCalculationType : int
        {
            Sum = 0,
                Average = 1,
        }

        [DeserializeAs(Name = "id")]
        public int Id
        {
            get;
            set;
        }


        public string Name { get; set; }
        public string Suffix { get; set; }
        public string Description { get; set; }
        public string Default_value { get; set; }
        public bool Display_chart { get; set; }
        public string Default_view_name { get; set; }
        public MetricCalculationType Calc_type { get; set; }

        public int Places { get; set; }
        public int Threashold { get; set; }
        public int Order { get; set; }


        public DateTime CreatedAt
        {
            get;
            set;
        }

        public DateTime UpdatedAt
        {
            get;
            set;
        }

    }
}
