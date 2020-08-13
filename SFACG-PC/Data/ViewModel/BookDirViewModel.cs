using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Objects.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class BookDirViewModel {
        private static readonly ObservableCollection<Volumelist> _volumelist = new ObservableCollection<Volumelist>();
        public ObservableCollection<Volumelist> Volumelists => _volumelist;

        public async Task LoadData(int NovelID) {
            _volumelist.Clear();
            _volumelist.AddRange(await SFClient.Instance.GetBookDir(NovelID));
        }
        public BookDirViewModel() {

        }

    }

    public class ChapterItem {
        public int ChapId { get; set; }
        public int NovelId { get; set; }
        public int VolumeId { get; set; }
        public int NeedFireMoney { get; set; }
        public int CharCount { get; set; }
        public string Title { get; set; }
        public bool IsVip { get; set; }
        public DateTime? UpdateTime { get; set; }
    }

    public class Volumelist {
        public int VolumeId { get; set; }
        public string Title { get; set; }
        public float Sno { get; set; }
        public List<ChapterItem> Chapterlist { get; set; }
    }
}
