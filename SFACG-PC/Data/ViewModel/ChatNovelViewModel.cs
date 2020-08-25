using PropertyChanged;
using SFACGPC.Core;
using SFACGPC.Objects.Generic;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class ChatNovelViewModel {

        private static readonly ObservableCollection<ChatLineItem> _chats = new ObservableCollection<ChatLineItem>();
        public ObservableCollection<ChatLineItem> ChatLines => _chats;

        private async Task LoadData(int chapid) {
            ChatLines.AddRange(await SFClient.Instance.GetChapChatline(chapid));
        }
        public ChatNovelViewModel(int chapid) {
            ChatLines.Clear();
            LoadData(chapid);
        }
    }
    
    public class ChatLineItem {
        public int CharId { get; set; }
        public string CharName { get; set; }
        public string Avatar { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string ChatType { get; set; }
        public string IsShowChip { get; set; }
    }
}
