using System.Net;
using IllinoisSiteScanner.PlatformCheck;

//TODO Change this to point to your location
var rootPath = "C:\\Users\\jonker\\source\\repos\\IllinoisSiteScanner\\";

var path = rootPath + "sitelist.txt";
var pathOutput = rootPath + "sitelist-output.txt";
var lines = File.ReadAllLines(path);
var linesOut = new List<string>();

foreach (var url in lines) {
    try {
        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(new HttpRequestMessage {
            Version = HttpVersion.Version10,
            RequestUri = new Uri(url),
            Method = HttpMethod.Get
        });

        _ = response.EnsureSuccessStatusCode();
        var html = await response.Content.ReadAsStringAsync();

        var myUri = new Uri(url);
        var ip = Dns.GetHostAddresses(myUri.Host)[0];
        var line = url;
        line += "\t";
        line += myUri.Host;
        line += "\t";
        line += ip;
        line += "\t";
        line += IpInformation.Check(ip.ToString());
        line += "\t";
        line += CmsInformation.Check(html, ip.ToString());
        line += "\t";
        line += ServerInformation.Check(response.Headers.Server.ToString());
        line += "\t";
        line += ToolkitInformation.Check(html);
        line += "\t";
        line += HeaderInformation.Check(html);
        line += "\t";
        line += PrimarySiteInformation.Check(html);
        linesOut.Add(line);
        Console.WriteLine(url);
    } catch (Exception e) {
        linesOut.Add("error with " + url + ". " + e.Message);
        Console.WriteLine("error with " + url + ". " + e.Message);
    }
}
linesOut = linesOut.OrderBy(l => l).ToList();
linesOut.Insert(0, "URL\tHost\tHost Information\tIP\tCMS Information\tServer Hosting\tToolkit\tH1\tPrimary Site");
File.WriteAllLines(pathOutput, linesOut);