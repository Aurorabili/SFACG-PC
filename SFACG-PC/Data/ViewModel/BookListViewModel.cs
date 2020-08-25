using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Objects.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class BookListViewModel {
        private static readonly ObservableCollection<BookItem> _bookItems = new ObservableCollection<BookItem>();

        public ObservableCollection<BookItem> BookItems => _bookItems;

        public async Task LoadData(string Mode, string keyword) {
            _bookItems.Clear();
            List<BookItem> result = new List<BookItem>();
            if (Mode == "Novel")
                result = await SFClient.Instance.SearchNovels(keyword);
            else if (Mode == "ChatNovel")
                result = await SFClient.Instance.SearchChatNovels(keyword);

            _bookItems.AddRange(result);
        }
        public BookListViewModel(string Mode, string keyword) {
            BookItems.Clear();
            LoadData(Mode, keyword);
        }

    }

    public class BookItem {
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
