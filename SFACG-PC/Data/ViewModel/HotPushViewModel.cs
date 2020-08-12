using PropertyChanged;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using SFACGPC.Objects.Generic;
using SFACGPC.Core;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class HotPushViewModel {
        private static readonly ObservableCollection<HotPushItem> _hotPushItems = new ObservableCollection<HotPushItem>();

        public ObservableCollection<HotPushItem> HotPushItems => _hotPushItems;

        private async void LoadData() {
            this.HotPushItems.AddRange(await SFClient.Instance.GetNovelHotPush());
        }
        public HotPushViewModel() {
            LoadData();
        }

    }

    public class HotPushItem {
        public string CoverUrl { get; set; }

        public string Title { get; set; }

        public string Tags { get; set; }

        public int novelID { get; set; }
    }
}
