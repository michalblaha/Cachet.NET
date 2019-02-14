using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cachet.NET.Responses
{ 

    //TODO
    public class IncidentUpdateResponse
    {

            public int incident_id { get; set; }
            public int status { get; set; }
            public string message { get; set; }
            public int user_id { get; set; }
            public string updated_at { get; set; }
            public string created_at { get; set; }
            public int id { get; set; }
            public Incident incident { get; set; }
            public string human_status { get; set; }
            public string permalink { get; set; }
        

        public class Incident
        {
            public int id { get; set; }
            public int component_id { get; set; }
            public string name { get; set; }
            public int status { get; set; }
            public int visible { get; set; }
            public bool stickied { get; set; }
            public string message { get; set; }
            public string occurred_at { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object deleted_at { get; set; }
            public bool is_resolved { get; set; }
            public object[] meta { get; set; }
            public Update[] updates { get; set; }
            public Component component { get; set; }
            public string human_status { get; set; }
            public int latest_update_id { get; set; }
            public int latest_status { get; set; }
            public string latest_human_status { get; set; }
            public string latest_icon { get; set; }
            public string permalink { get; set; }
            public int duration { get; set; }
        }

        public class Component
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string link { get; set; }
            public int status { get; set; }
            public int order { get; set; }
            public int group_id { get; set; }
            public bool enabled { get; set; }
            public object meta { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object deleted_at { get; set; }
            public string status_name { get; set; }
            public object[] tags { get; set; }
        }

        public class Update
        {
            public int id { get; set; }
            public int incident_id { get; set; }
            public int status { get; set; }
            public string message { get; set; }
            public int user_id { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string human_status { get; set; }
            public string permalink { get; set; }
        }

    }
}
