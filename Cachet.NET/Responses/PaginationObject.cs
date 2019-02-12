namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;
    using RestSharp.Deserializers;
    using System.Collections.Generic;

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
                get;
                set;
            }

            public int PreviousPage
            {
                get;
                set;
            }
        }
    }
}
