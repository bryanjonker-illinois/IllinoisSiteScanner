using System.Text.RegularExpressions;

namespace IllinoisSiteScanner {

    internal static class TagRemover {

        internal static string RemoveTags(string html) {
            var matches = Regex.Matches(html, "<.*?>");
            foreach (var match in matches) {
                html = html.Replace(match.ToString(), "");
            }
            return html;
        }
    }
}