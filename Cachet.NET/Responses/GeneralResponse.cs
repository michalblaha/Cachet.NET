namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;

    using RestSharp.Deserializers;

    public class GeneralResponse<T>
    {
        /// <summary>
        /// Gets or sets the <see cref="MetaObject"/>.
        /// </summary>
        public  MetaObject Meta
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Incident.
        /// </summary>
        [DeserializeAs(Name = "data")]
        public T Data
        {
            get;
            set;
        }

    }
}
