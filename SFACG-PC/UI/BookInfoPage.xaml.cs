using SFACGPC.Data.ViewModel;
using System.Windows.Controls;

namespace SFACGPC.UI {
    /// <summary>
    /// BookInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class BookInfoPage : Page {
        public BookInfoPage(BookInfo info) {
            InitializeComponent();

            this.DataContext = info;
        }

    }
}
