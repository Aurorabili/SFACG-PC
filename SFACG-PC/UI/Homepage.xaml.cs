using SFACGPC.Core;
using SFACGPC.Data.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SFACGPC.UI {
    /// <summary>
    /// Homepage.xaml 的交互逻辑
    /// </summary>
    public partial class Homepage : Page {
        public Homepage() {
            InitializeComponent();
        }

        private async void LightnovelPage_Checked(object sender, RoutedEventArgs e) {
            await SpecialPushViewModel.LoadData("Novel");
            await HotPushViewModel.LoadData("Novel");
            SpecialPushViewer.GoForward();
        }

        private async void ComicsPage_Checked(object sender, RoutedEventArgs e) {
            await SpecialPushViewModel.LoadData("Comics");
            await HotPushViewModel.LoadData("Comics");
            SpecialPushViewer.GoForward();
        }

        private async void ChatNovelPage_Checked(object sender, RoutedEventArgs e) {
            await SpecialPushViewModel.LoadData("ChatNovel");
            await HotPushViewModel.LoadData("ChatNovel");
            SpecialPushViewer.GoForward();
        }

        private async void Info_Click(object sender, RoutedEventArgs e) {

            BookInfoViewModel bookinfo = new BookInfoViewModel();
            await bookinfo.LoadData(((HotPushItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID.ToString());
            BookInfoPage page = new BookInfoPage(bookinfo.BookInfo);
            NavigationService.Navigate(page);

        }
        private async void BeginRead_Click(object sender, RoutedEventArgs e) {
            int _novelid = ((HotPushItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID;
            int _chapid = await SFClient.Instance.NovelViewData(_novelid);
            int _volumeid = -1;
            if (_chapid != -1) {
                var chapItem = await SFClient.Instance.GetChapContent(_chapid);
                _volumeid = chapItem.VolumeID;
            }
            
            if (((HotPushItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).IsChatNovel)
                NavigationService.Navigate(new ChatNovelViewer(((HotPushItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID, _volumeid, _chapid));
            else
                NavigationService.Navigate(new Bookviewer(((HotPushItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID, _volumeid, _chapid));
        }
    }
}
