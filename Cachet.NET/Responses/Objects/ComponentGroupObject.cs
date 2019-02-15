namespace Cachet.NET.Responses.Objects
{
    using RestSharp.Deserializers;
    using System;

    public class ComponentGroupObject : ICachetItem
    {

        public enum CollapsedType : int
        {
            No =0,
            Yes = 1,
            OnlyIfNotOperational = 2
        }

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

        [DeserializeAs(Name = "order")]
        public int Order
        {
            get;
            set;
        }

        [DeserializeAs(Name = "collapsed")]

        public CollapsedType Collapsed
        {
            get;
            set;
        }
    }
}
