using System;

namespace SFACGPC.Data.Web.Response {
    public class ChapDetailResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int chapId { get; set; }
            public int novelId { get; set; }
            public int volumeId { get; set; }
            public int charCount { get; set; }
            public int rowNum { get; set; }
            public int chapOrder { get; set; }
            public string title { get; set; }
            public DateTime addTime { get; set; }
            public int sno { get; set; }
            public bool isVip { get; set; }
            public Expand expand { get; set; }
        }

        public class Expand {
            public int needFireMoney { get; set; }
            public int originNeedFireMoney { get; set; }
            public string content { get; set; }
            public Tsukkomi[] tsukkomi { get; set; }
            public Chatline[] chatLines { get; set; }
        }

        public class Tsukkomi {
            public int row { get; set; }
            public int count { get; set; }
        }

        public class Chatline {
            public int charId { get; set; }
            public int charType { get; set; }
            public int lineNum { get; set; }
            public string charName { get; set; }
            public string avatar { get; set; }
            public string content { get; set; }
            public string image { get; set; }
        }

    }
}
