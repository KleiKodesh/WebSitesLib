﻿using Microsoft.VisualBasic;
using System;
using System.Windows.Controls;

namespace WebSitesLib
{
    /// <summary>
    /// Interaction logic for WebSitesView.xaml
    /// </summary>
    public partial class WebSitesView : UserControl
    {
        public WebSitesView()
        {
            InitializeComponent();
            string selectedIndex = Interaction.GetSetting(AppDomain.CurrentDomain.FriendlyName, "WebSitesView", "SelectedIndex", AdressBar.SelectedIndex.ToString());
            if (int.TryParse(selectedIndex, out int index))
                AdressBar.SelectedIndex = index;
        }

        private void AdressBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Interaction.SaveSetting(AppDomain.CurrentDomain.FriendlyName, "WebSitesView", "SelectedIndex", AdressBar.SelectedIndex.ToString());
        }

        private void GobackButton_Click(object sender, System.Windows.RoutedEventArgs e) =>
            browser.WebView.GoBack();

        private void GoForwardButton_Click(object sender, System.Windows.RoutedEventArgs e) =>
            browser.WebView.GoForward();

        private void RefreshButton_Click(object sender, System.Windows.RoutedEventArgs e) =>
            browser.WebView.CoreWebView2?.Reload();
    }
}
