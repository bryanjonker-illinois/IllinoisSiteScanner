namespace IllinoisSiteScanner.PlatformCheck {

    internal static class IpInformation {

        internal static Dictionary<string, string> Hosts = new Dictionary<string, string> {
            { "18.220.149.166", "cPanel" },
            { "18.160.200.125", "PIE" }
        };

        internal static string Check(string ip) => Hosts.ContainsKey(ip) ? Hosts[ip] : "Not Listed";
    }
}