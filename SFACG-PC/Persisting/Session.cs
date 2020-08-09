using Newtonsoft.Json;
using SFACGPC.Data.Web;
using SFACGPC.Data.Web.Delegation;
using SFACGPC.Data.Web.Response;
using SFACGPC.Objects.Primitive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SFACGPC.Persisting {
    public class Session {

        public static Session Current;

        [JsonIgnore]
        public string Password { set; get; }

        public string SFCommunity { set; get; }

        public string Session_ID { set; get; }

        public DateTime ExpireIn { set; get; }

        public static Session Parse(string _sfcommunity,string _session_id) {
            return new Session {
                SFCommunity = _sfcommunity,
                Session_ID = _session_id,
                ExpireIn = DateTime.Now + TimeSpan.FromDays(7)
            };
        }

        public static string ToCookie() {
            return $".SFCommunity={Current.SFCommunity};session_PC={Current.Session_ID}";
        }

        public override string ToString() {
            return this.ToJson();
        }

        public async Task Store() {
            await File.WriteAllTextAsync(Path.Combine(AppContext.ConfFolder, AppContext.ConfigurationFileName),
                                         ToString());
        }

        public static async Task Restore() {
            Current = (await File.ReadAllTextAsync(
                    Path.Combine(AppContext.ConfFolder, AppContext.ConfigurationFileName), Encoding.UTF8))
                .FromJson<Session>();
        }

        public static bool ConfExists() {
            var path = Path.Combine(AppContext.ConfFolder, AppContext.ConfigurationFileName);
            return File.Exists(path) &&
                new FileInfo(path).Length != 0;
        }

        public static bool KeyRefreshRequired(Session identity) {
            return identity == null ||
                identity.SFCommunity.IsNullOrEmpty() ||
                identity.ExpireIn == default ||
                identity.ExpireIn <= DateTime.Now;
        }

        public static void Clear() {
            if (File.Exists(Path.Combine(AppContext.ConfFolder, AppContext.ConfigurationFileName))) File.Delete(Path.Combine(AppContext.ConfFolder, AppContext.ConfigurationFileName));
            Current = new Session();
        }
    }
}
