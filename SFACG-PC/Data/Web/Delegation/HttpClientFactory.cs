using Refit;
using SFACGPC.Data.Web.Protocol;
using SFACGPC.Objects.Generic;
using SFACGPC.Persisting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SFACGPC.Data.Web.Delegation {
    public class HttpClientFactory {

        public static HttpClient AppAPIHttpClient() {
            return SFACGClient(ProtocolBase.AppAPIBaseUrl)
                .Apply(h => h.DefaultRequestHeaders.Add("Authorization", ProtocolBase.AppAPIAuthorization));
        }

        public static IAppAPIProtocol AppApiService() {
            return RestService.For<IAppAPIProtocol>(SFACGClient(ProtocolBase.AppAPIBaseUrl));
        }

        public static HttpClient SFACGClient(string baseAddress) {
            var _httpclient = new HttpClient() {
                BaseAddress = new Uri(baseAddress),
            };
            _httpclient.DefaultRequestHeaders.Add("Cookie", Session.ToCookie());

            return _httpclient;
        }

        public static Task<HttpResponseMessage> GetResponseHeader(HttpClient client, string uri) {
            return client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
        }
    }
}
