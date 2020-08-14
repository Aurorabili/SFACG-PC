using PropertyChanged;
using SFACGPC.Core;
using System.Threading.Tasks;

namespace SFACGPC.Data.ViewModel {

    [AddINotifyPropertyChangedInterface]
    public class BookInfoViewModel {
        private static BookInfo _bookinfo = new BookInfo();

        public BookInfo BookInfo => _bookinfo;

        public async Task LoadData(string NovelID) {
            _bookinfo = await SFClient.Instance.GetBookInfo(NovelID);
        }
        public BookInfoViewModel() {
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class BookInfo {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public bool IsNeedVIP { get; set; }
        public string AuthorUrl { get; set; }
        public string TypeString { get; set; }
        public string LatestString { get; set; }
        public string Intro { get; set; }
        public int Point { get; set; }
        public string MarkCount { get; set; }
        public string TicketCount { get; set; }
        public int Like { get; set; }
    }
}
