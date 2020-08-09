using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SFACGPC.Objects {
    public class Host {
        public static string Url { set; get; }
        public static X509Certificate Certificate { set; get; }

        public Host(string _Url, string _CAPath = null) {
            Url = _Url;
            if (_CAPath != null)
                Certificate = new X509Certificate(_CAPath);
        }
    }
}
