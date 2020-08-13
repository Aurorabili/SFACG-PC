using MaterialDesignThemes.Wpf;
using SFACGPC.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        private void BeginRead_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Bookviewer(((HotPushItem)((FrameworkElement)((FrameworkElement)e.Source).Parent).DataContext).NovelID));
        }
    }
}
