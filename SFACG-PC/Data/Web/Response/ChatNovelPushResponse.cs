﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.Web.Response {
    public class ChatNovelPushResponse {
        public PublicBookInfo.Status status { get; set; }
        public PublicBookInfo.Data[] data { get; set; }
    }
}