using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Objects.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static SFACGPC.Data.Web.Response.PublicBookInfo;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class HotPushViewModel {
        private static readonly ObservableCollection<HotPushItem> _hotPushItems = new ObservableCollection<HotPushItem>();

        public ObservableCollection<HotPushItem> HotPushItems => _hotPushItems;

        public static async Task LoadData(string Mode) {
            _hotPushItems.Clear();
            List<HotPushItem> result = new List<HotPushItem>();
            if (Mode == "Novel")
                result = await SFClient.Instance.GetNovelHotPush();
            else if (Mode == "ChatNovel")
                result = await SFClient.Instance.GetChatNovelHotPush();
            else
                result = await SFClient.Instance.GetComicsHotPush();

            _hotPushItems.AddRange(result);
        }
        public HotPushViewModel() {
            HotPushItems.Clear();
            LoadData("Novel");
        }

    }

    public class tag : Systag {

    }

    public class HotPushItem {
        public string CoverUrl { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string charCount { get; set; }
        public List<tag> Tags { get; set; }
        public string IsSerialize { get; set; }
        public string IsSign { get; set; }
        public int NovelID { get; set; }
        public bool IsChatNovel { get; set; }
    }
}
