using MaterialDesignThemes.Wpf;
using SFACGPC.Data.ViewModel;
using SFACGPC.Persisting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SFACGPC.UI {
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class WelcomeWindow : Window {
        private DispatcherTimer timer;

        public WelcomeWindow() {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            UserLogin(sender, e);
            timer.Stop();
        }
        private async void UserLogin(object sender, EventArgs e) {
            /* 
             * 使用内置登录
            var View = new LoginDialog() {
                DataContext = new User()
            };

            var result = await DialogHost.Show(View, "RootDialog");
            Console.WriteLine(result);
            */
            if (Session.ConfExists()) {
                await Session.Restore();

                MainWindow view = new MainWindow();
                view.Show();
            } else {
                System.IO.FileStream f = System.IO.File.Create(Path.Combine(AppContext.ConfFolder, AppContext.ConfigurationFileName));
                f.Close();
                f.Dispose();
                SignInWebBrowser signIn = new SignInWebBrowser();
                signIn.Show();
            }
            this.Close();
        }
    }
}
