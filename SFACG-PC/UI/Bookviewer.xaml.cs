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
    /// Bookviewer.xaml 的交互逻辑
    /// </summary>
    public partial class Bookviewer : Page {
        private static int _novelid { get; set; }
        private static int _chapid { get; set; }

        public Bookviewer(int NovelID,int ChapID = -1) {
            InitializeComponent();
            _novelid = NovelID;
            _chapid = ChapID;

            Loaded += Bookviewer_Loaded;
        }

        private async void Bookviewer_Loaded(object sender, RoutedEventArgs e) {
            BookDirViewModel bookdir = new BookDirViewModel();
            await bookdir.LoadData(_novelid);

            if (_chapid != -1)
                UpdateContent(await BookContentViewModel.LoadData(_chapid));
            else
                UpdateContent(await BookContentViewModel.LoadData(bookdir.Volumelists[0].Chapterlist[0].ChapId));
        }

        private void UpdateContent(Paragraph paragraph) {
            this.Reader.Document.Blocks.Clear();
            this.Reader.Document.Blocks.Add(paragraph);
        }
    }
}
