namespace Cachet.NET.Responses
{
    using System.Collections.Generic;

    using global::Cachet.NET.Responses.Objects;

    using RestSharp.Deserializers;

    public partial class IncidentsResponse : GeneralResponse<List<IncidentObject>>
    {
            set;
        }

        /// <summary>
        /// Gets or sets the Incidents.
        /// </summary>
        [DeserializeAs(Name = "data")]
        public List<IncidentObject> Incidents
        {
            get;
            set;
        }

        public class MetaObject
        {
            /// <summary>
            /// Gets or sets the pagination.
            /// </summary>
            public PaginationObject Pagination
            {
                get;
                set;
            }

            public class PaginationObject
            {
                public int Total
                {
                    get;
                    set;
                }

                public int Count
                {
                    get;
                    set;
                }

                public int PerPage
                {
                    get;
                    set;
                }

                public int CurrentPage
                {
                    get;
                    set;
                }

                public int TotalPages
                {
                    get;
                    set;
                }

                public LinksObject Links
                {
                    get;
                    set;
                }

                public class LinksObject
                {
                    public int NextPage
                    {
    }
}
