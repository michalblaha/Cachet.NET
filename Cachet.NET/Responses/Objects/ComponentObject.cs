namespace Cachet.NET.Responses.Objects
{
    using Newtonsoft.Json;
    using RestSharp.Deserializers;
    using System;
    using System.Collections.Generic;

    public class ComponentObject : ICachetItem
    {
        [DeserializeAs(Name = "id")]
        public int Id
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

        [DeserializeAs(Name = "description")]
        public string Description
        {
            get;
            set;
        }

        [DeserializeAs(Name = "link")]
        public string Link
        {
            get;
            set;
        }

        [DeserializeAs(Name = "status")]

        public int Status
        {
            get;
            set;
        }
        [DeserializeAs(Name = "order")]

        public int Order
        {
            get;
            set;
        }

        [DeserializeAs(Name = "group_id")]

        public int GroupId
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

        [DeserializeAs(Name = "status_name")]

        public string StatusName
        {
            get;
            set;
        }

        //[DeserializeAs(Name = "tags")]
        //[JsonConverter(typeof(CustomArraySerializer))]
        //public List<string> Tags
        //{
        //    get;
        //    set;
        //}


        public class CustomArraySerializer : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var date = value as List<string>;
                if (date == null)
                    writer.WriteValue("");
                else
                    writer.WriteValue(string.Join(",",date.ToArray()));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
            }

            public override bool CanRead
            {
                get { return false; }
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime);
            }
        }
    }
}
