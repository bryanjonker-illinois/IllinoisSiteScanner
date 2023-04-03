using System.Text.RegularExpressions;

namespace IllinoisSiteScanner.PlatformCheck {

    internal static class HeaderInformation {

        internal static string Check(string html) {
            var match = Regex.Match(html, "<h1.*?>(.*?)</h1>");
            if (match.Success) {
                return TagRemover.RemoveTags(match.Groups[1].Value);
            }
            return "No H1 found";
        }
    }
}