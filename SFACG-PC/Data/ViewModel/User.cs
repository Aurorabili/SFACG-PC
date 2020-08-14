using PropertyChanged;

namespace SFACGPC.Data.ViewModel {

    [AddINotifyPropertyChangedInterface]
    public class User {
        public string Username { set; get; }

        public string Password { set; get; }

        public string SFCommunity { set; get; }

        public string session_ID { set; get; }

        public string FiremoneyRemain { set; get; }

        public string FiremoneyUsed { set; get; }

        public string VIPLevel { set; get; }
    }
}
