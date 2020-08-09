using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class UserMoneyResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int rmbCost { get; set; }
            public int fireMoneyUsed { get; set; }
            public int fireMoneyRemain { get; set; }
            public int vipLevel { get; set; }
            public int couponsRemain { get; set; }
        }

    }
}
