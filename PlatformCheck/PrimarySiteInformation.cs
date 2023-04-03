using System.Text.RegularExpressions;

namespace IllinoisSiteScanner.PlatformCheck {

    internal static class PrimarySiteInformation {

        internal static string Check(string html) {
            var match = Regex.Match(html, "<p class=\"il-primary-unit\">(.*?)</p>");
            if (match.Success) {
                return TagRemover.RemoveTags(match.Groups[1].Value);
            }
            return "";
        }
    }
}