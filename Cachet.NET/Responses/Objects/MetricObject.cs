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

        [DeserializeAs(Name = "name")]

        public string Name { get; set; }


        [DeserializeAs(Name = "suffix")]
        public string Suffix { get; set; }


        [DeserializeAs(Name = "description")]
        public string Description { get; set; }

        [DeserializeAs(Name = "default_value")]
        public string Default_value { get; set; }

        [DeserializeAs(Name = "display_chart")]
        public bool Display_chart { get; set; }

        [DeserializeAs(Name = "default_view_name")]
        public string Default_view_name { get; set; }

        [DeserializeAs(Name = "calc_type")]
        public MetricCalculationType Calc_type { get; set; }


        [DeserializeAs(Name = "places")]
        public int Places { get; set; }

        [DeserializeAs(Name = "threashold")]
        public int Threashold { get; set; }

        [DeserializeAs(Name = "order")]
        public int Order { get; set; }


        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt
        {
            get;
            set;
        }

        [DeserializeAs(Name = "updated_at")]
        public DateTime UpdatedAt
        {
            get;
            set;
        }

    }
}
