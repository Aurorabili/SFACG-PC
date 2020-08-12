using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class NovelNewPushResponse {
        public PublicBookInfoRespone.Status status { get; set; }
        public PublicBookInfoRespone.Data[] data { get; set; }
    }
}
