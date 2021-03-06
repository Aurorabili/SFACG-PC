﻿using CefSharp;
using SFACGPC.Persisting;
using System;
using System.Windows;

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

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (_sFCommunity != null && _session_ID != null) {
                Session.Current = Session.Parse(_sFCommunity, _session_ID);
                await Session.Current.Store();

                MainWindow view = new MainWindow();
                view.Show();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // If the Session already exists
        }
    }


}
