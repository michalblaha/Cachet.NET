using RestSharp.Deserializers;

namespace Cachet.NET.Responses.Objects
{
    using System;

    public class IncidentUpdate : ICachetItem
    {
        [DeserializeAs(Name = "id")]
        public int Id
        {
            get;
            set;
        }

        [DeserializeAs(Name = "incident_id")]
        public int IncidentId { get; set; }

        [DeserializeAs(Name = "status")]
        public int Status { get; set; }

        [DeserializeAs(Name = "message")]
        public string Message { get; set; }

        [DeserializeAs(Name = "user_id")]
        public int UserId { get; set; }

        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DeserializeAs(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DeserializeAs(Name = "human_status")]
        public string HumanStatus { get; set; }

        [DeserializeAs(Name = "permalink")]
        public string Permalink { get; set; }
    }


}

