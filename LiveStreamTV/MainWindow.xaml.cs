using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel.Syndication;

namespace LiveStreamTV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SyndicationItem> newsItems = new List<SyndicationItem>();

        public double GetListboxViewportWidth { get {
                //Width="{Binding RelativeSource={RelativeSource AncestorType={x:Type Window}}, Path=GetListboxViewportWidth}"
                ScrollViewer scvu = null;

                int cnt = VisualTreeHelper.GetChildrenCount(listView);
                for (int i = 0; i < cnt; i++) {
                    var child = VisualTreeHelper.GetChild(listView, i);
                    if (child is ScrollViewer) {
                        scvu = (ScrollViewer)child;
                    }
                }

                if (scvu == null) return listView.ActualWidth;
                return scvu.ViewportWidth;
            } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            newsItems = new ContentFetcher().GoFetch();
            listView.ItemsSource = newsItems;

            //webBrowser.Address = "http://get.adobe.com/flashplayer/?fpchrome";
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SyndicationItem item = listView.SelectedItem as SyndicationItem;
            if (item == null) return;

            //System.Net.WebClient wc = new System.Net.WebClient();
            //var html = wc.DownloadString(item.Links.First().Uri);

            //webBrowser.Navigate(item.Links.First().Uri);
            webBrowser.Address = item.Links.First().Uri.ToString();
        }
    }
}
