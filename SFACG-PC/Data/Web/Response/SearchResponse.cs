namespace SFACGPC.Data.Web.Response {
    public class SearchResponse {
        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public PublicBookInfo.Data[] novels { get; set; }
            public object[] comics { get; set; }
            public object[] albums { get; set; }
        }
    }
}
