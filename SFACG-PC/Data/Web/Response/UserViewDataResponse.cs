using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class UserViewDataResponse {
        public Status status { get; set; }
        public Data[] data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int accountId { get; set; }
            public int novelId { get; set; }
            public int chapterId { get; set; }
            public DateTime lastViewTime { get; set; }
        }

    }
}
