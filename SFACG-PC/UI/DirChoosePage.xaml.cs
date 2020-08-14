using MaterialDesignThemes.Wpf;
using SFACGPC.Data.ViewModel;
using SFACGPC.Objects.Primitive;
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
    public partial class DirChoosePage : Page {

        public int ChapIndex { get; set; }
        public int VolumeIndex { get; set; }
        public BookDirViewModel BookDir { get; set; }

        public DirChoosePage(BookDirViewModel bookdir, int nowVolumID, int nowChapID) {
            InitializeComponent();

            BookDir = bookdir;

            foreach (var item in bookdir.Volumelists) {
                if (item.VolumeId == nowVolumID) { VolumeIndex = bookdir.Volumelists.IndexOf(item); break; }
            }
            foreach (var item in bookdir.Volumelists[VolumeIndex].Chapterlist) {
                if (item.ChapId == nowChapID) { ChapIndex = bookdir.Volumelists[VolumeIndex].Chapterlist.IndexOf(item); break; }
            }

            BookDirShower.ItemsSource = BookDir.Volumelists[VolumeIndex].Chapterlist;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e) {
            Bookviewer._chapid = ((SFACGPC.Data.ViewModel.ChapterItem)((System.Windows.FrameworkElement)sender).DataContext).ChapId;
            NavigationService.GoBack();
        }
        private void CommandBinding_NextVolumeList_Executed(object sender, RoutedEventArgs e) {
            if ((VolumeIndex + 1) <= BookDir.Volumelists.Count) {
                VolumeIndex++;
                ChapIndex = 0;
                BookDirShower.ItemsSource = BookDir.Volumelists[VolumeIndex].Chapterlist;
            }
        }
        private void CommandBinding_PreviousVolumeList_Executed(object sender, RoutedEventArgs e) {
            if ((VolumeIndex - 1) >= 0) {
                VolumeIndex--;
                ChapIndex = 0;
                BookDirShower.ItemsSource = BookDir.Volumelists[VolumeIndex].Chapterlist;
            }
        }
    }
}
