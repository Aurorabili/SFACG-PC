using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class ComicsHotPushResponse {
        public PublicComicsInfo.Status status { get; set; }
        public PublicComicsInfo.Data[] data { get; set; }
    }
}
