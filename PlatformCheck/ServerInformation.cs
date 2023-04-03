namespace IllinoisSiteScanner.PlatformCheck {

    internal static class ServerInformation {

        internal static string Check(string s) => string.IsNullOrWhiteSpace(s) ? "Not Listed" : s.Trim();
    }
}