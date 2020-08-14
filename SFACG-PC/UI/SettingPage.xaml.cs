using SFACGPC.Data.ViewModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SFACGPC.UI {
    /// <summary>
    /// SettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingPage : Page {
        public SettingPage() {
            InitializeComponent();
        }

        private async void TextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                if (Regex.IsMatch(CommandBox.Text, @"(?<=GOTO )\S*", RegexOptions.IgnoreCase)) {
                    BookInfoViewModel bookinfo = new BookInfoViewModel();
                    await bookinfo.LoadData(Regex.Match(CommandBox.Text, @"(?<=GOTO )\S*", RegexOptions.IgnoreCase).Value);
                    BookInfoPage page = new BookInfoPage(bookinfo.BookInfo);
                    NavigationService.Navigate(page);
                }
                if (Regex.IsMatch(CommandBox.Text, @"(?<=SearchNovel )\S*", RegexOptions.IgnoreCase)) {
                    BookListPage page = new BookListPage("Novel", Regex.Match(CommandBox.Text, @"(?<=SearchNovel )\S*", RegexOptions.IgnoreCase).Value);
                    NavigationService.Navigate(page);
                }
                if (Regex.IsMatch(CommandBox.Text, @"(?<=SearchChatNovel )\S*", RegexOptions.IgnoreCase)) {
                    BookListPage page = new BookListPage("ChatNovel", Regex.Match(CommandBox.Text, @"(?<=SearchChatNovel )\S*", RegexOptions.IgnoreCase).Value);
                    NavigationService.Navigate(page);
                }
            }
        }
    }
}
