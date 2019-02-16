using System;

namespace Cachet.NET.Responses.Objects
{
    public class PointObject : ICachetItem
    {
        public int value { get; set; }
        public int counter { get; set; }
        public int metric_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public long CalculatedValue { get; set; }
        public int Id { get; set; }
    }
}