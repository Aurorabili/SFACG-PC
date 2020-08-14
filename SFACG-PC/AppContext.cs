using System.IO;

namespace SFACGPC {
    public static class AppContext {
        public const string AppIdentifier = "SFACGPC";

        public const string CurrentVersion = "0.0.1-alpha";

        public const string ConfigurationFileName = "SFACG_Config.json";

        //public static readonly string ProjectFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppIdentifier.ToLower());

        public static readonly string ProjectFolder = System.IO.Directory.GetCurrentDirectory() + "\\UserConfig\\";

        public static readonly string ConfFolder = ProjectFolder;

        public static readonly string SettingsFolder = ProjectFolder;

        public static readonly string ExceptionReportFolder = Path.Combine(ProjectFolder, "crash-reports");

        public static readonly string InterchangeFolder = Path.Combine(ProjectFolder, "interchange");

        public static readonly string CacheFolder = Path.Combine(ProjectFolder, "cache");

        public static readonly string ResourceFolder = Path.Combine(Path.GetDirectoryName(typeof(App).Assembly.Location)!, "Resource");

        public static readonly string PermanentlyFolder = Path.Combine(Path.GetDirectoryName(typeof(App).Assembly.Location)!, "Permanent");

        //public static async Task<bool> UpdateAvailable() {
        //    const string url = "http://xxx.github.io/xxx/version.txt";
        //    var httpClient = new HttpClient();
        //    return await httpClient.GetStringAsync(url) != CurrentVersion;
        //}
    }
}
