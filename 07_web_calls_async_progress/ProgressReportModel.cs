using System;
using System.Collections.Generic;
using System.Text;

namespace _01_web_calls
{
    public class ProgressReportModel
    {
        public List<WebsiteDataModel> SitesDownloaded { get; set; } 
            = new List<WebsiteDataModel>();
        public int PercentageComplete { get; set; } = 0;
    }
}
