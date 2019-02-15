namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;
    using RestSharp.Deserializers;
    using System.Collections.Generic;

    public class PaginationObject
    {
        public int total
        {
            get;
            set;
        }

        public int count
        {
            get;
            set;
        }


        public int per_page
        {
            get;
            set;
        }

        public int current_page
        {
            get;
            set;
        }

        public int total_pages
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
            public string next_page
            {
                get;
                set;
            }

            public string previous_page
            {
                get;
                set;
            }
        }
    }
}
