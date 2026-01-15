using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TWA.Core.Entities;

namespace TWA.Service.Services.Parsers
{
    public class ReportParser : BaseHtmlParser
    {
        public List<Report> ParseReports(string html)
        {
            var reports = new List<Report>();
            var doc = LoadHtml(html);

            // Report list table
            var rows = doc.DocumentNode.SelectNodes("//table[@id='report_list']//tr[contains(@class, 'row_')]");
            if (rows == null) return reports;

            foreach (var row in rows)
            {
                try
                {
                   var report = ParseReportRow(row);
                   if (report != null) reports.Add(report);
                }
                catch { }
            }

            return reports;
        }

        private Report ParseReportRow(HtmlNode row)
        {
            var report = new Report();

            // Try to find ID from input check box or link
            var input = row.SelectSingleNode(".//input[@name='id[]']");
            if (input != null)
            {
                report.GameId = input.GetAttributeValue("value", "");
            }

            // Subject and Link
            var subjectLink = row.SelectSingleNode(".//span[contains(@class, 'quickedit-label')]//a") 
                           ?? row.SelectSingleNode(".//a[contains(@href, 'view=')]");
            
            if (subjectLink != null)
            {
                report.Subject = subjectLink.InnerText.Trim();
                
                // Check if unread (often implies bold text or specific class on row)
                // Assuming row class "new" for unread
                // But simplistically, if subject contains "(yeni)" text
                if (row.InnerText.Contains("(yeni)"))
                {
                    report.IsUnread = true;
                }
            }

            // Date - usually the last cell
            var cells = row.SelectNodes(".//td");
            if (cells != null && cells.Count > 1)
            {
                var dateText = cells.Last().InnerText.Trim();
                // Simple date parsing or just set as string in another property if type mismatches
                // report.Date = ... (Skipping complex parsing logic for brevity/safety)
            }

            // Status Icon (dot) - usually first cell
            var dotImg = row.SelectSingleNode(".//img[contains(@src, 'graphic/dots/')]");
            if (dotImg != null)
            {
                var src = dotImg.GetAttributeValue("src", "");
                var match = Regex.Match(src, @"/([^/]+)\.png");
                if (match.Success) report.StatusIcon = match.Groups[1].Value;
            }
            
            // Loot icon?
            var lootImg = row.SelectSingleNode(".//img[contains(@src, 'graphic/max_loot')]");
            if (lootImg != null)
            {
                report.Loot = 1; // Indicator that loot exists
            }

            return report;
        }
        public Report ParseReportDetail(string html)
        {
            var report = new Report();
            var doc = LoadHtml(html);

            // Extract main report content usually inside a specific container or just body
            // We want to capture the specific table or div that contains the battle report
            // Based on user sample: <table class="vis">...</table> (but there are many tables)
            // A good selector for battle reports is usually specific classes like 'report_ReportAttack'
            
            // Let's try to grab the main container
            var reportTable = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'vis')]/tbody/tr/td[contains(@class, 'report_ReportAttack')]")?.ParentNode?.ParentNode?.ParentNode;
            
            // Fallback to a broader selector if specific attack report structure not found
            if (reportTable == null)
            {
                 // Try finding by ID if possible or just main content area
                 // The user provided snippet starts with <table class="vis">
                 // We might just capture the entire significant part
                 reportTable = doc.DocumentNode.SelectSingleNode("//table[@width='100%']//table[contains(@class, 'vis')]");
            }
            
            if (reportTable != null)
            {
                 report.HtmlContent = reportTable.OuterHtml;
            }
            else
            {
                // Last resort: extract body content or a large container
                report.HtmlContent = html; // Or better, just a placeholder saying not parseable
            }

            // Also try to parse ID from URL params in the page if available or hidden inputs
            // But usually this parser is called with context.
            
            return report;
        }
}
}
