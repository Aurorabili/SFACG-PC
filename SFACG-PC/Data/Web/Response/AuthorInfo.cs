using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class AuthorInfo {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int authorId { get; set; }
            public int accountId { get; set; }
            public string authorName { get; set; }
            public string introduce { get; set; }
            public string avatar { get; set; }
            public Userinfo userInfo { get; set; }
        }

        public class Userinfo {
            public int accountId { get; set; }
            public string userName { get; set; }
            public string nickName { get; set; }
            public Expand expand { get; set; }
        }

        public class Expand {
            public bool youfollow { get; set; }
            public int fansNum { get; set; }
        }

    }
}
