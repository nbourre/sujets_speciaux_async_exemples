using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_web_calls
{
    public static class DemoMethods
    {
        private static List<string> PrepData()
        {
            var output = new List<string>
            {
                "https://www.lapresse.ca",
                "https://www.reddit.com",
                "https://www.microsoft.com",
                "https://www.amazon.ca",
                "https://www.stackoverflow.com",
                "https://www.facebook.com",
                "https://www.google.ca",
                "https://www.hotmail.com",
                "https://www.codeproject.com",
                "https://fr.wikipedia.org"
            };

            return output;
        }

        public static List<WebsiteDataModel> RunDownloadSync()
        {
            var websites = PrepData();
            var output = new List<WebsiteDataModel>();

            foreach (string site in websites)
            {
                WebsiteDataModel ws = DownloadWebsite(site);
                output.Add(ws);
            }

            return output;
        }

        public static async Task<List<WebsiteDataModel>> 
            RunDownloadAsync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            var websites = PrepData();
            var output = new List<WebsiteDataModel>();
            var report = new ProgressReportModel();

            foreach (string site in websites)
            {
                WebsiteDataModel results = await DownloadWebsiteAsync(site);
                output.Add(results);

                /// On déclenche l'exception OperationCanceledException
                /// SI DEMANDÉ
                cancellationToken.ThrowIfCancellationRequested();

                report.SitesDownloaded = output;
                report.PercentageComplete = (output.Count * 100) / websites.Count;

                progress.Report(report);
            }

            return output;
        }

        public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsync()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in websites)
            {
                tasks.Add(DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(tasks);

            return new List<WebsiteDataModel>(results);
        }

        private static WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);

            return output;
        }

        private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = await client.DownloadStringTaskAsync(websiteURL);

            return output;
        }

        
    }
}
