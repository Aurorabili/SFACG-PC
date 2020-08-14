using MaterialDesignThemes.Wpf;
using PropertyChanged;
using SFACGPC.Data.ViewModel;
using System;
using System.Collections.Generic;
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

    [AddINotifyPropertyChangedInterface]
    /// <summary>
    /// Bookviewer.xaml 的交互逻辑
    /// </summary>
    public partial class Bookviewer : Page {
        public static int _novelid { get; set; }
        public static int _volumeid { get; set; }
        public static int _chapid { get; set; }
        BookDirViewModel bookdir = new BookDirViewModel();
        public Bookviewer(int NovelID, int VolumID = -1, int ChapID = -1) {
            InitializeComponent();
            _novelid = NovelID;
            _volumeid = VolumID;
            _chapid = ChapID;

            Loaded += Bookviewer_Loaded;
        }

        public async Task ReLoad() {
            await bookdir.LoadData(_novelid);

            BookContentViewModel bookContent = new BookContentViewModel();
            if (_chapid == -1) _chapid = bookdir.Volumelists[0].Chapterlist[0].ChapId;
            if (_volumeid == -1) _volumeid = bookdir.Volumelists[0].VolumeId;

            await bookContent.LoadData(_chapid);
            UpdateContent(bookContent.Para);
            TitleShower.Text = bookContent.Title;
        }
        private async void Bookviewer_Loaded(object sender, RoutedEventArgs e) {

            await ReLoad();
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
        }
    }
}
