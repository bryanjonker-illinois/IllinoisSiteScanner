using System.Text.RegularExpressions;

namespace IllinoisSiteScanner.PlatformCheck {

    internal static class ToolkitInformation {

        internal static string Check(string html) {
            var match = Regex.Match(html, "toolkit.illinois.edu\\/(.*?)\\/toolkit");
            if (match.Success) {
                return match.Groups[1].Value;
            }
            return "No toolkit found";
        }
    }
}