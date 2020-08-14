using PropertyChanged;
using System.Collections.ObjectModel;
using static SFACGPC.Data.Web.Response.PublicBookInfo;

namespace SFACGPC.Data.ViewModel {

    [AddINotifyPropertyChangedInterface]
    public class TagsViewModel {

        private static readonly ObservableCollection<TagItem> _tagItems = new ObservableCollection<TagItem>();

        public ObservableCollection<TagItem> TagItems => _tagItems;

        public TagsViewModel() {

        }
    }

    public class TagItem : Systag {

    }
}
