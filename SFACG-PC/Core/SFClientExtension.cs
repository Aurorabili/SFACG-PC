using SFACGPC.Data.ViewModel;
using SFACGPC.Data.Web.Delegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFACGPC.Core {
    public static class SFClientExtension {

        public static async Task<List<SpecialPushItem>> GetSpecialPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetSpecialPushResponse();
            var list = new List<SpecialPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.homePush.Select(book => new SpecialPushItem() {
                    ImgUrl = book.imgUrl,
                    Link = book.link,
                    Type = book.type
                }));
            }
            return list;
        }
    }
}
