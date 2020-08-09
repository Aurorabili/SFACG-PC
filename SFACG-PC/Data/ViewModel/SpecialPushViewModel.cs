using MahApps.Metro.Controls;
using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Objects.Generic;
using SFACGPC.Objects.Primitive;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class SpecialPushViewModel {
        private static readonly ObservableCollection<SpecialPushItem> _specialpushitems = new ObservableCollection<SpecialPushItem>();

        public ObservableCollection<SpecialPushItem> SpecialPushItems => _specialpushitems;

        private async void LoadView() {
            this.SpecialPushItems.AddRange(await SFClient.Instance.GetSpecialPush());
        }
        public SpecialPushViewModel() {
            LoadView();
        }

        
    }

    public class SpecialPushItem : FlipViewItem {
        public string ImgUrl { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }
}
