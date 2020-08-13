using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using PropertyChanged;
using SFACGPC.Objects.Primitive;
using SFACGPC.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class HamburgerMenuViewModel {
        private static readonly ObservableCollection<HamburgerMenuPageItem> AppMenu = new ObservableCollection<HamburgerMenuPageItem>();
        private static readonly ObservableCollection<HamburgerMenuPageItem> AppOptionsMenu = new ObservableCollection<HamburgerMenuPageItem>();

        public ObservableCollection<HamburgerMenuPageItem> Menu => AppMenu;

        public ObservableCollection<HamburgerMenuPageItem> OptionsMenu => AppOptionsMenu;

        public HamburgerMenuViewModel() {
            // Build the menus
            this.Menu.Add(new HamburgerMenuPageItem() {
                Icon = new PackIcon() { Kind = PackIconKind.HomeMinus },
                Label = (string)Application.Current.FindResource("i18n.Homepage"),
                NavigationType = typeof(Homepage),
                NavigationDestination = new Uri("UI/Homepage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new HamburgerMenuPageItem() {
                Icon = new PackIcon() { Kind = PackIconKind.Bookshelf },
                Label = (string)Application.Current.FindResource("i18n.Bookshelf"),
                NavigationType = typeof(Bookshelf),
                NavigationDestination = new Uri("UI/Bookshelf.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new HamburgerMenuPageItem() {
                Icon = new PackIcon() { Kind = PackIconKind.UserCircle },
                Label = (string)Application.Current.FindResource("i18n.Usercenter"),
                NavigationType = typeof(Usercenter),
                NavigationDestination = new Uri("UI/Usercenter.xaml", UriKind.RelativeOrAbsolute)
            });

            this.OptionsMenu.Add(new HamburgerMenuPageItem() {
                Icon = new PackIcon() { Kind = PackIconKind.Gear },
                Label = (string)Application.Current.FindResource("i18n.Setting"),
                NavigationType = typeof(SettingPage),
                NavigationDestination = new Uri("UI/SettingPage.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }

    public class HamburgerMenuPageItem : HamburgerMenuIconItem {
        public static readonly DependencyProperty NavigationDestinationProperty = DependencyProperty.Register(
      nameof(NavigationDestination), typeof(Uri), typeof(HamburgerMenuPageItem), new PropertyMetadata(default(Uri)));

        public Uri NavigationDestination {
            get => (Uri)this.GetValue(NavigationDestinationProperty);
            set => this.SetValue(NavigationDestinationProperty, value);
        }

        public static readonly DependencyProperty NavigationTypeProperty = DependencyProperty.Register(
          nameof(NavigationType), typeof(Type), typeof(HamburgerMenuPageItem), new PropertyMetadata(default(Type)));

        public Type NavigationType {
            get => (Type)this.GetValue(NavigationTypeProperty);
            set => this.SetValue(NavigationTypeProperty, value);
        }

        public bool IsNavigation => this.NavigationDestination != null;
    }
}
