using SFACGPC.Core;
using SFACGPC.Data.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SFACGPC.UI {
    /// <summary>
    /// BookListPage.xaml 的交互逻辑
    /// </summary>
    public partial class BookListPage : Page {

        private string _mode { get; set; }
        private string _keyword { get; set; }
        private BookListViewModel viewModel { get; set; }
        public BookListPage(string Mode, string Keyword) {
            InitializeComponent();

            _mode = Mode;
            _keyword = Keyword;

            Loaded += BookListPage_Loaded;
        }

        private void BookListPage_Loaded(object sender, RoutedEventArgs e) {
            viewModel = new BookListViewModel(_mode, _keyword);
            this.BookListViewer.ItemsSource = viewModel.BookItems;
        }

        private async void Info_Click(object sender, RoutedEventArgs e) {

            BookInfoViewModel bookinfo = new BookInfoViewModel();
            await bookinfo.LoadData(((BookItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID.ToString());
            BookInfoPage page = new BookInfoPage(bookinfo.BookInfo);
            NavigationService.Navigate(page);

        }
        private async void BeginRead_Click(object sender, RoutedEventArgs e) {
            int _novelid = ((BookItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID;
            int _chapid = await SFClient.Instance.NovelViewData(_novelid);
            int _volumeid = -1;
            if (_chapid != -1) {
                var chapItem = await SFClient.Instance.GetChapContent(_chapid);
                _volumeid = chapItem.VolumeID;
            }
            if (((BookItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).IsChatNovel)
                NavigationService.Navigate(new ChatNovelViewer(((BookItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID, _volumeid, _chapid));
            else
                NavigationService.Navigate(new Bookviewer(((BookItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID, _volumeid, _chapid));
        }
    }
}
