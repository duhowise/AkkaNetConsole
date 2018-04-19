using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace AkkaNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("html-download-system");
            var downloadHtmlActor = system.ActorOf<DownloadHtmlActor>("html-download-Actor");
            downloadHtmlActor.Tell("https://www.agile-code.com");
            downloadHtmlActor.Tell("https://www.microsoft.com");
            downloadHtmlActor.Tell("https://www.syncfusion.com");
            Console.Read();
        }
    }

    public class DownloadHtmlActor : ReceiveActor
    {
        public DownloadHtmlActor()
        {
            ReceiveAsync<string>(async url => await GetPageHtmlAsync(url));
        }
        private async Task GetPageHtmlAsync(string url)
        {
            var html = await new
                System.Net.WebClient().DownloadStringTaskAsync(url);
            Console.WriteLine("\n=====================================");
            Console.WriteLine($"Data for {url}");
            Console.WriteLine(html.Trim().Substring(0, 100));
            Console.Read();
        }
    }
}
