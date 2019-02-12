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

        public string Name
        {
            get;
            set;
        }

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

        public int Order
        {
            get;
            set;
        }


        public CollapsedType Collapsed
        {
            get;
            set;
        }
    }
}
