﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
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

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();
            RunDownloadSync();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Total execution time : {elapsedMs}";
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

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultsWindow.Text += $"{data.WebsiteUrl} downloaded :  {data.WebsiteData.Length} characters long. {Environment.NewLine}";
            Console.WriteLine(data.WebsiteUrl);
        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();

            WebClient client = new WebClient();
            output.WebsiteUrl = websiteURL;

            try
            {
                output.WebsiteData = client.DownloadString(websiteURL);
            }
            catch (Exception ex)
            {
                output.WebsiteData = ex.Message;
            }

            return output;
        }

        private void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pas implémenté!");
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
    }
}
