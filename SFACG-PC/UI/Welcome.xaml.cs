using MaterialDesignThemes.Wpf;
using SFACGPC.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            UserLogin(sender, e);
            timer.Stop();
        }
        private async void UserLogin(object sender, EventArgs e) {
            var View = new LoginDialog() {
                DataContext = new User()
            };

            var result = await DialogHost.Show(View, "RootDialog");
            Console.WriteLine(result);
        }
    }
}
