using CefSharp;
using MaterialDesignThemes.Wpf;
using SFACGPC.Persisting;
using SFACGPC.Objects.Primitive;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SFACGPC.UI {
    /// <summary>
    /// WebBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class SignInWebBrowser : Window {

        private string _session_ID = null;
        private string _sFCommunity = null;

        public static SignInWebBrowser Instance;

        public SignInWebBrowser() {
            Instance = this;
            InitializeComponent();
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            string _url = e.Url;
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();

            if (_url.Contains("https://passport.sfacg.com/Message.aspx?msg=LoginSuccessToHome&rul=/")) {
                CookieVisitor visitor = new CookieVisitor();
                visitor.SendCookie += Visitor_SendCookie;
                cookieManager.VisitAllCookies(visitor);
            }
        }
        private void Visitor_SendCookie(Cookie obj) {
            if (obj.Name == ".SFCommunity")
                _sFCommunity = obj.Value;
            if (obj.Name == "session_PC")
                _session_ID = obj.Value;
        }

        public class CookieVisitor : ICookieVisitor {
            public event Action<Cookie> SendCookie;
            public void Dispose() {
            }
            public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie) {
                deleteCookie = false;
                SendCookie?.Invoke(cookie);
                return true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (_sFCommunity != null && _session_ID != null)
                Session.Current = Session.Parse(_sFCommunity, _session_ID);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // If the Session already exists
        }
    }


}
