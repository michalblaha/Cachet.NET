namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;

    using RestSharp.Deserializers;
    using System.Collections.Generic;

    public class GeneralSimpleResponse<T> : BaseGeneralResponse<T>
            where T : class, ICachetItem, new()
    {
        [DeserializeAs(Name = "data")]
        public T Data
        {
            get;
            set;
        }

    }
    public class GeneralCollectionResponse<T> : BaseGeneralResponse<T>
            where T : ICachetItem, new()
    {
        [DeserializeAs(Name = "data")]
        public List<T> Data { get; set; }
    }

    public abstract class BaseGeneralResponse<T>
    {
        /// <summary>
        /// Gets or sets the <see cref="MetaObject"/>.
        /// </summary>
        public MetaObject Meta
        {
            get;
            set;
        }


    }
}
