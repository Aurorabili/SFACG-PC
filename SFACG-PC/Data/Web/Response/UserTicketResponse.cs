using System;

namespace SFACGPC.Data.Web.Response {
    public class UserTicketResponse {

        public Status status { get; set; }
        public Data data { get; set; }

        public class Status {
            public int httpCode { get; set; }
            public int errorCode { get; set; }
            public int msgType { get; set; }
            public object msg { get; set; }
        }

        public class Data {
            public int totalTicketNum { get; set; }
            public int chapterConsumeMoney { get; set; }
            public int fireMoneyNeedForTicket { get; set; }
            public int allFireMoneyNeedForTicket { get; set; }
            public int allFireMoneyForConsumeTicket { get; set; }
            public int ticketsNumPerConsume { get; set; }
            public Ticket[] tickets { get; set; }
        }

        public class Ticket {
            public int num { get; set; }
            public string source { get; set; }
            public DateTime expireDate { get; set; }
        }

    }
}
