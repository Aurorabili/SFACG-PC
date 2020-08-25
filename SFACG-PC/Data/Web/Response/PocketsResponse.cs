using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class PocketsResponse {

        public class Rootobject {
            public Status status { get; set; }
            public Datum[] data { get; set; }
        }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Datum {
            public int accountId { get; set; }
            public int pocketId { get; set; }
            public string name { get; set; }
            public int typeId { get; set; }
            public DateTime createTime { get; set; }
            public bool isFull { get; set; }
            public bool canModify { get; set; }
            public Expand expand { get; set; }
        }

        public class Expand {
            public PublicBookInfo.Data[] chatNovels { get; set; }
            public PublicBookInfo.Data[] novels { get; set; }
            public PublicComicsInfo.Data[] comics { get; set; }
        }
    }
}
