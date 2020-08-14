using System;

namespace SFACGPC.Data.Web.Response {
    public class SpecialPushResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public string novelSpecialSubject { get; set; }
            public Homepush[] homePush { get; set; }
            public Vippush[] vipPush { get; set; }
            public Homesecondpush[] homeSecondPush { get; set; }
            public object[] pocketLoopPush { get; set; }
            public Pocketcoverpush[] pocketCoverPush { get; set; }
            public Chatnovelpush[] chatNovelPush { get; set; }
            public Welfarepush[] welfarePush { get; set; }
            public object[] announcementPush { get; set; }
            public object[] popupPush { get; set; }
            public Minipchatnovelpush[] minipChatNovelPush { get; set; }
            public object[] fanNovelHomePush { get; set; }
            public object[] homeFloatPush { get; set; }
        }

        public class Homepush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
        }

        public class Vippush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
        }

        public class Homesecondpush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
            public DateTime endDate { get; set; }
        }

        public class Pocketcoverpush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
            public DateTime endDate { get; set; }
            public string entityName { get; set; }
        }

        public class Chatnovelpush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
            public DateTime endDate { get; set; }
        }

        public class Welfarepush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
        }

        public class Minipchatnovelpush {
            public string imgUrl { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
            public DateTime endDate { get; set; }
        }

    }
}
