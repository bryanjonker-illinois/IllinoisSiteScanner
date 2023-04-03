namespace IllinoisSiteScanner.PlatformCheck {

    internal static class CmsInformation {

        internal static Dictionary<string, string> Cms = new() {
            { "content=\"Drupal", "Drupal" },
            { "wp-content/themes", "Wordpress" },
            { "src=\"/ScriptResource.axd?", "Sitefinity" },
            { "/sitemanager/", "Site Manager" }
        };

        internal static List<string> SitefinityIP = new() {
            "52.240.149.243", "40.80.191.1"
        };

        internal static string Check(string html, string ip) {
            foreach (var item in Cms) {
                if (html.Contains(item.Key)) {
                    return item.Value;
                }
            }
            return SitefinityIP.Contains(ip) ? "Sitefinity" : "Unknown CMS";
        }
    }
}