namespace SFACGPC.Core {
    public sealed class SFClient {
        private static volatile SFClient _instance;

        private static readonly object _locker = new object();

        public static SFClient Instance {
            get {
                if (_instance == null)
                    lock (_locker) {
                        _instance ??= new SFClient();
                    }

                return _instance;
            }
        }
    }
}
