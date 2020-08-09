using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class NovelHotPushResponse {

        public Status status { get; set; }
        public Datum[] data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Datum {
            public int authorId { get; set; }
            public DateTime lastUpdateTime { get; set; }
            public int markCount { get; set; }
            public string novelCover { get; set; }
            public string bgBanner { get; set; }
            public int novelId { get; set; }
            public string novelName { get; set; }
            public float point { get; set; }
            public bool isFinish { get; set; }
            public string authorName { get; set; }
            public int charCount { get; set; }
            public int viewTimes { get; set; }
            public int typeId { get; set; }
            public bool allowDown { get; set; }
            public string signStatus { get; set; }
            public int categoryId { get; set; }
            public Expand expand { get; set; }
        }

        public class Expand {
            public Systag[] sysTags { get; set; }
            public float discount { get; set; }
            public DateTime discountExpireDate { get; set; }
        }

        public class Systag {
            public int sysTagId { get; set; }
            public string tagName { get; set; }
        }

    }
}
