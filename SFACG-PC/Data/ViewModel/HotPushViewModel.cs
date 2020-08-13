using PropertyChanged;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using SFACGPC.Objects.Generic;
using SFACGPC.Core;
using static SFACGPC.Data.Web.Response.PublicBookInfo;
using System.Threading.Tasks;

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
        public bool IsSerialize { get; set; }
        public bool IsSign { get; set; }
        public int NovelID { get; set; }
    }
}
