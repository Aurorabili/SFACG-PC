﻿using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Data.ViewModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SFACGPC.UI {

    [AddINotifyPropertyChangedInterface]
    /// <summary>
    /// Bookviewer.xaml 的交互逻辑
    /// </summary>
    public partial class Bookviewer : Page {
        public static int _novelid { get; set; }
        public static int _volumeid { get; set; }
        public static int _chapid { get; set; }
        private static int VolumeIndex { get; set; }
        private static int ChapIndex { get; set; }

        BookDirViewModel bookdir = new BookDirViewModel();
        public Bookviewer(int NovelID, int VolumID = -1, int ChapID = -1) {
            InitializeComponent();
            _novelid = NovelID;
            _volumeid = VolumID;
            _chapid = ChapID;

            Loaded += Bookviewer_Loaded;
        }

        public async Task ReLoad() {
            BookContentViewModel bookContent = new BookContentViewModel();
            if (_chapid == -1) _chapid = bookdir.Volumelists[0].Chapterlist[0].ChapId;
            if (_volumeid == -1) _volumeid = bookdir.Volumelists[0].VolumeId;

            await bookContent.LoadData(_novelid, _chapid);
            UpdateContent(bookContent.Para);
            TitleShower.Text = bookContent.Title;

            Reader.Focus();
        }
        private async void Bookviewer_Loaded(object sender, RoutedEventArgs e) {
            await bookdir.LoadData(_novelid);
            await ReLoad();

            foreach (var item in bookdir.Volumelists) {
                if (item.VolumeId == _volumeid) { VolumeIndex = bookdir.Volumelists.IndexOf(item); break; }
            }
            foreach (var item in bookdir.Volumelists[VolumeIndex].Chapterlist) {
                if (item.ChapId == _chapid) { ChapIndex = bookdir.Volumelists[VolumeIndex].Chapterlist.IndexOf(item); break; }
            }
        }

        private void UpdateContent(Paragraph paragraph) {
            this.Reader.Document.Blocks.Clear();
            this.Reader.Document.Blocks.Add(paragraph);
        }

        private void CommandBinding_OpenDirDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private async void CommandBinding_OpenDirDialog_Executed(object sender, ExecutedRoutedEventArgs e) {
            DirChoosePage dialog = new DirChoosePage(bookdir, _volumeid, _chapid);
            NavigationService.Navigate(dialog);

            await ReLoad();
            Reader.ScrollToHome();
        }
        private void CommandBinding_PageDown_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if (ChapIndex + 1 >= 0 && ChapIndex + 1 <= bookdir.Volumelists[VolumeIndex].Chapterlist.Count)
                e.CanExecute = true;
            else e.CanExecute = false;
        }

        private async void CommandBinding_PageDown_Executed(object sender, ExecutedRoutedEventArgs e) {
            ChapIndex++;
            _chapid = bookdir.Volumelists[VolumeIndex].Chapterlist[ChapIndex].ChapId;

            await ReLoad();
            Reader.ScrollToHome();
        }
        private void CommandBinding_PageUp_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if (ChapIndex - 1 >= 0 && ChapIndex - 1 <= bookdir.Volumelists[VolumeIndex].Chapterlist.Count)
                e.CanExecute = true;
            else e.CanExecute = false;
        }

        private async void CommandBinding_PageUp_Executed(object sender, ExecutedRoutedEventArgs e) {
            ChapIndex--;
            _chapid = bookdir.Volumelists[VolumeIndex].Chapterlist[ChapIndex].ChapId;

            await ReLoad();
            Reader.ScrollToHome();
        }
    }
}
