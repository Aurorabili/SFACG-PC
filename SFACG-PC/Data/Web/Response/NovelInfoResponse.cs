using System;

namespace SFACGPC.Data.Web.Response {
    public class NovelInfoResponse {

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
            public int chapterCount { get; set; }
            public string bigBgBanner { get; set; }
            public string bigNovelCover { get; set; }
            public string typeName { get; set; }
            public string intro { get; set; }
            public int fav { get; set; }
            public int ticket { get; set; }
            public int pointCount { get; set; }
            public object[] tags { get; set; }
            public Systag[] sysTags { get; set; }
            public string signLevel { get; set; }
            public float discount { get; set; }
            public DateTime discountExpireDate { get; set; }
            public int totalNeedFireMoney { get; set; }
            public int originTotalNeedFireMoney { get; set; }
            public Latestchapter latestChapter { get; set; }
            public DateTime latestCommentDate { get; set; }
            public object essayTag { get; set; }
            public string auditCover { get; set; }
        }

        public class Latestchapter {
            public string title { get; set; }
            public int chapId { get; set; }
            public DateTime addTime { get; set; }
        }

        public class Systag {
            public int sysTagId { get; set; }
            public string tagName { get; set; }
        }

    }
}
