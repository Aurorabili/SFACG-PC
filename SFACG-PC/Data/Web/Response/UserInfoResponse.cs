using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class UserInfoResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public string userName { get; set; }
            public string nickName { get; set; }
            public string email { get; set; }
            public int accountId { get; set; }
            public string roleName { get; set; }
            public int fireCoin { get; set; }
            public string avatar { get; set; }
            public bool isAuthor { get; set; }
            public string phoneNum { get; set; }
            public Expand expand { get; set; }
        }

        public class Expand {
            public Vipinfo vipInfo { get; set; }
            public int welfareCoin { get; set; }
            public bool isRealNameAuth { get; set; }
            public Changenicknameinfo changeNickNameInfo { get; set; }
            public float welfareMoney { get; set; }
            public string redpacketCode { get; set; }
            public bool useWelfaresys { get; set; }
            public string usedRedpacketCode { get; set; }
        }

        public class Vipinfo {
            public int level { get; set; }
            public int point { get; set; }
            public int nextLevelPoint { get; set; }
        }

        public class Changenicknameinfo {
            public bool canChange { get; set; }
            public int nextChangeNeedDays { get; set; }
        }

    }
}
