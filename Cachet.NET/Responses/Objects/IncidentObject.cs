using RestSharp.Deserializers;

namespace Cachet.NET.Responses.Objects
{
    using System;
    using System.Collections.Generic;

    public class IncidentObject : ICachetItem
    {
        [DeserializeAs(Name = "id")]
        public int Id
        {
            get;
            set;
        }

        [DeserializeAs(Name = "component_id")]
        public int ComponentId
        {
            get;
            set;
        }

        [DeserializeAs(Name = "name")]

        public string Name
        {
            get;
            set;
        }
        [DeserializeAs(Name = "status")]

        public IncidentStatus Status
        {
            get;
            set;
        }
        [DeserializeAs(Name = "visible")]
        public bool Visible
        {
            get;
            set;
        }
        [DeserializeAs(Name = "message")]

        public string Message
        {
            get;
            set;
        }
        [DeserializeAs(Name = "scheduled_at")]

        public DateTime? ScheduledAt
        {
            get;
            set;
        }
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
        [DeserializeAs(Name = "deleted_at")]

        public DateTime? DeletedAt
        {
            get;
            set;
        }

        [DeserializeAs(Name = "human-status")]
        public string StatusName
        {
            get;
            set;
        }

        [DeserializeAs(Name = "updates")]

        public List<IncidentUpdate> Updates { get; set; } = new List<IncidentUpdate>();
    }
}
