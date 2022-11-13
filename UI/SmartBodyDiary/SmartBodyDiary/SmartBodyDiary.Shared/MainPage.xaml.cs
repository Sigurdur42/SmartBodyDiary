using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartBodyDiary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MainViewModel _viewModel = new();
        public MainViewModel ViewModel => _viewModel;
        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = this;
            SetCurrentNavigationViewItem(OverviewPage);
        }

        private void rootNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //var item = args.SelectedItem as NavigationViewItem;
            //_viewModel.SelectedPageName = item?.Name;

            //testTextBox.Text = _viewModel.SelectedPageName;

            SetCurrentNavigationViewItem(args.SelectedItemContainer as NavigationViewItem);
        }

        public void SetCurrentNavigationViewItem(NavigationViewItem item)
        {
            // TODO: Handle Settings
            if (item == null)
            {
                return;
            }

            if (item.Tag == null)
            {
                return;
            }

            if (item.Tag.Equals("Settings"))
            {
                item.Tag = "SmartBodyDiary.SettingsPage";
            }

            ContentFrame.Navigate(Type.GetType(item.Tag.ToString()), item.Content);
            NavigationView.Header = item.Content;
            NavigationView.SelectedItem = item;
        }
    }
}