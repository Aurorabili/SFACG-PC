using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using SFACGPC.Objects.Primitive;
using System.Linq;
using SFACGPC.Data.ViewModel;

namespace SFACGPC.UI {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow {
        private readonly NavigationServiceEx navigationServiceEx;

        public MainWindow() {
            InitializeComponent();

            this.navigationServiceEx = new NavigationServiceEx();
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
    }
}
