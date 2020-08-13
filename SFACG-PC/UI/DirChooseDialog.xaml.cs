using SFACGPC.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// DirChooseDialog.xaml 的交互逻辑
    /// </summary>
    public partial class DirChooseDialog : Page {
        public DirChooseDialog(BookDirViewModel bookdir) {
            InitializeComponent();

            BookDirShower.ItemsSource = bookdir.Volumelists;
        }
    }
}
