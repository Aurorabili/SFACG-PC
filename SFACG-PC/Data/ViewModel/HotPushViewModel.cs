using PropertyChanged;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class HotPushViewModel {
        private static readonly ObservableCollection<HotPushItem> _hotPushItems = new ObservableCollection<HotPushItem>();

        public ObservableCollection<HotPushItem> HotPushItems => _hotPushItems;

        private async void LoadData() {

        }
        public HotPushViewModel() {
            LoadData();
        }

    }

    public class HotPushItem {
        public string Imgurl { get; set; }

        public string Title { get; set; }

        public string Tags { get; set; }
    }
}
