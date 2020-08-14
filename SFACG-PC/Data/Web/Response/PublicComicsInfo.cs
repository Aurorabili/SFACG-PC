using System;

namespace SFACGPC.Data.Web.Response {
    public class PublicComicsInfo {
        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int comicId { get; set; }
            public string comicName { get; set; }
            public string folderName { get; set; }
            public int typeId { get; set; }
            public int viewTimes { get; set; }
            public float point { get; set; }
            public bool isFinished { get; set; }
            public string comicCover { get; set; }
            public string bgBanner { get; set; }
            public string latestChapterTitle { get; set; }
            public DateTime lastUpdateTime { get; set; }
            public int authorId { get; set; }
            public Expand expand { get; set; }
        }

        public class Expand {
            public string typeName { get; set; }
            public string intro { get; set; }
            public string authorName { get; set; }
            public string originalauthor { get; set; }
            public float discount { get; set; }
            public DateTime discountExpireDate { get; set; }
            public int totalNeedFireMoney { get; set; }
            public int originTotalNeedFireMoney { get; set; }
        }
    }
}
