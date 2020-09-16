using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace _01_web_calls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Sync methods
        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time : {elapsedMs} {Environment.NewLine}";
        }

        private void RunDownloadSync()
        {
            var websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel ws = DownloadWebsite(site);
                ReportWebsiteInfo(ws);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);

            return output;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultsWindow.Text += $"{data.WebsiteUrl} downloaded :  {data.WebsiteData.Length} characters long. {Environment.NewLine}";
        }

        #endregion

        private async Task RunDownloadAsync()
        {
            var websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel ws = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(ws);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in websites)
            {
                tasks.Add (DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(tasks);

            foreach (WebsiteDataModel site in results)
            {
                ReportWebsiteInfo(site);
            }
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            output.WebsiteUrl = websiteURL;
            output.WebsiteData = await client.DownloadStringTaskAsync(websiteURL);

            return output;
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            await RunDownloadAsync();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time : {elapsedMs}";
        }

        private List<string> PrepData()
        {
            var output = new List<string>();

            resultsWindow.Text = "";

            output.Add("https://www.lapresse.ca");
            output.Add("https://www.reddit.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.amazon.ca");
            output.Add("https://www.stackoverflow.com");

            return output;
        }

        private async void executeParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            await RunDownloadParallelAsync();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time : {elapsedMs}";
        }
    }
}
