using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class ComicsSpecialPushResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public Comicpush[] comicPush { get; set; }
        }

        public class Comicpush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
        }

    }
}
