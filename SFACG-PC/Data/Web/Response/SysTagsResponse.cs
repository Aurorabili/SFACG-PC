using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class SysTagsResponse {

        public Status status { get; set; }
        public Datum[] data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Datum {
            public int sysTagId { get; set; }
            public int refferTimes { get; set; }
            public string tagName { get; set; }
        }

    }
}
