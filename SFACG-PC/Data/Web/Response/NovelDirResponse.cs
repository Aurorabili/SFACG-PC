using System;

namespace SFACGPC.Data.Web.Response {
    public class NovelDirResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int novelId { get; set; }
            public DateTime lastUpdateTime { get; set; }
            public Volumelist[] volumeList { get; set; }
        }

        public class Volumelist {
            public int volumeId { get; set; }
            public string title { get; set; }
            public float sno { get; set; }
            public Chapterlist[] chapterList { get; set; }
        }

        public class Chapterlist {
            public int chapId { get; set; }
            public int novelId { get; set; }
            public int volumeId { get; set; }
            public int needFireMoney { get; set; }
            public int originNeedFireMoney { get; set; }
            public int charCount { get; set; }
            public int rowNum { get; set; }
            public int chapOrder { get; set; }
            public string title { get; set; }
            public object content { get; set; }
            public float sno { get; set; }
            public bool isVip { get; set; }
            public DateTime AddTime { get; set; }
            public DateTime? updateTime { get; set; }
        }

    }
}
