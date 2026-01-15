using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TWA.Core.Entities;

namespace TWA.Service.Services.Parsers
{
    public class CommandParser : BaseHtmlParser
    {
        public List<Command> ParseCommands(string html)
        {
            var commands = new List<Command>();
            var doc = LoadHtml(html);

            // Try to find the commands table
            // Usually id="commands_table" or inside a specific container
            // We look for rows that likely contain command info
            var rows = doc.DocumentNode.SelectNodes("//table[@id='commands_table']//tr[contains(@class, 'row_')]");
            
            if (rows == null)
            {
                // Fallback: look for generic visible tables that have command icons
                rows = doc.DocumentNode.SelectNodes("//tr[.//img[contains(@src, 'graphic/command/')]]");
            }

            if (rows == null) return commands;

            foreach (var row in rows)
            {
                try 
                {
                    // Skip header rows
                    if (row.SelectSingleNode(".//th") != null) continue;

                    var cmd = ParseCommandRow(row);
                    if (cmd != null)
                    {
                        commands.Add(cmd);
                    }
                }
                catch 
                { 
                    // continue on error
                }
            }

            return commands;
        }

        private Command ParseCommandRow(HtmlNode row)
        {
            var command = new Command();
            
            // Icon
            var iconNode = row.SelectSingleNode(".//img[contains(@src, 'graphic/command/')]");
            if (iconNode != null)
            {
                var src = iconNode.GetAttributeValue("src", "");
                // extract attack.png, support.png etc.
                // handle .png and .webp
                var match = Regex.Match(src, @"/([^/]+)\.(png|webp)"); 
                if (match.Success) 
                {
                    command.IconName = match.Groups[1].Value;
                    command.Type = DetermineCommandType(command.IconName);
                }
            }

            // Command Text / ID (usually in the first column's link)
            var linkNode = row.SelectSingleNode(".//a[contains(@href, 'screen=info_command')]");
            if (linkNode != null)
            {
                command.CommandText = linkNode.InnerText.Trim();
                var href = linkNode.GetAttributeValue("href", "");
                var idMatch = Regex.Match(href, @"id=(\d+)");
                if (idMatch.Success) command.GameId = idMatch.Groups[1].Value;
            }

            // Arrival Time Parsing
            // Usually the text in one of the cells (e.g., cell 2 or 3) contains the arrival date
            var cells = row.SelectNodes(".//td");
            if (cells != null)
            {
                foreach (var cell in cells)
                {
                    var text = cell.InnerText.Trim();
                    // Look for patterns like "bugün saat 14:00:00" or date patterns
                    if (Regex.IsMatch(text, @"\d+:\d+:\d+"))
                    {
                        // Identify if it's the arrival time cell
                        // Often the arrival time cell does NOT contain the timer
                        if (cell.SelectSingleNode(".//span[@class='timer']") == null)
                        {
                            // This might be the arrival time
                            // Parsing logic for Turkish time is needed here, simplifying for now
                            // We can use a shared utility if available, but for now simple check
                        }
                    }
                    
                    // Check for timer for remaining time
                    var timerSpan = cell.SelectSingleNode(".//span[@class='timer']");
                    if (timerSpan != null)
                    {
                        var secondsStr = timerSpan.InnerText.Trim(); // Usually formatted
                        // Actually the timer span usually has the raw seconds in data-endtime or content
                        // But let's assume valid timer span
                        // command.TimeRemaining = ...
                    }
                }
            }
            
            return command;
        }

        private CommandType DetermineCommandType(string icon)
        {
             if (icon.Contains("attack")) return CommandType.Attack;
             if (icon.Contains("support")) return CommandType.Support;
             if (icon.Contains("return")) return CommandType.Return;
             if (icon.Contains("spy")) return CommandType.Other; // Spy attack
             if (icon.Contains("snob")) return CommandType.Attack; // Snob attack
             return CommandType.Other;
        }
    }
}
