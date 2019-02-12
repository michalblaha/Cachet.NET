namespace Cachet.NET.Responses
{
    public class VersionResponse : BaseGeneralResponse<string>
    {
        public  VersionMetaObject Meta { get; set; }

        public class VersionMetaObject
        {

                public bool On_latest { get; set; }
                public LatestObj Latest { get; set; }

            public class LatestObj
            {
                public string Tag_name { get; set; }
                public bool Prelease { get; set; }
                public bool Draft { get; set; }
            }

        }
    }
}
