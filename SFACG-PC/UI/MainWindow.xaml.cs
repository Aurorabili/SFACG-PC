using MahApps.Metro.Controls;
using SFACGPC.Data.ViewModel;
using SFACGPC.Objects.Primitive;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SFACGPC.UI {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow {
        private static readonly NavigationServiceEx _navigationServiceEx = new NavigationServiceEx();
        public NavigationServiceEx navigationServiceEx => _navigationServiceEx;
        public MainWindow() {
            InitializeComponent();

            this.navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            this.HamburgerMenuControl.Content = this.navigationServiceEx.Frame;

            this.Loaded += (sender, args) => this.navigationServiceEx.Navigate(new Uri("UI/Homepage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e) {
            if (e.InvokedItem is HamburgerMenuPageItem menuItem && menuItem.IsNavigation) {
                this.navigationServiceEx.Navigate(menuItem.NavigationDestination);
            }
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e) {
            // select the menu item
            this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl
                                                         .Items
                                                         .OfType<HamburgerMenuPageItem>()
                                                         .FirstOrDefault(x => x.NavigationDestination == e.Uri);
            this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl
                                                                .OptionsItems
                                                                .OfType<HamburgerMenuPageItem>()
                                                                .FirstOrDefault(x => x.NavigationDestination == e.Uri);
            this.GoBackButton.Visibility = this.navigationServiceEx.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }
        private void GoBack_OnClick(object sender, RoutedEventArgs e) {
            this.navigationServiceEx.GoBack();
        }

        private void CommandBinding_OpenDirDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }
    }
}
