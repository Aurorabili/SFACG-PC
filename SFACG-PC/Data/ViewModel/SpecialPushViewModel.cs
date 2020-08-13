using MahApps.Metro.Controls;
using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Objects.Generic;
using SFACGPC.Objects.Primitive;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class SpecialPushViewModel {
        private static readonly ObservableCollection<SpecialPushItem> _specialpushitems = new ObservableCollection<SpecialPushItem>();

        public ObservableCollection<SpecialPushItem> SpecialPushItems => _specialpushitems;

        public static async Task LoadData(string Mode) {
            _specialpushitems.Clear();
            List<SpecialPushItem> result = new List<SpecialPushItem>();
            if (Mode == "Novel")
                result = await SFClient.Instance.GetSpecialPush();
            else if (Mode == "ChatNovel")
                result = await SFClient.Instance.GetChatNovelSpecialPush();
            else
                result = await SFClient.Instance.GetComicsSpecialPush();
            foreach (var item in result) {
                if (item.ImgUrl != "")
                    _specialpushitems.Add(item);
            }
        }
        public SpecialPushViewModel() {
            SpecialPushItems.Clear();
            LoadData("Novel");
        }
    }

    public class SpecialPushItem : FlipViewItem {
        public string ImgUrl { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }
}
