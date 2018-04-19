using System;
using System.Net;
using System.Threading.Tasks;
using Akka.Actor;

namespace AkkaAny
{
    public class DownloadAnyHtmlActor : ReceiveActor
    {
        public DownloadAnyHtmlActor()
        {
            ReceiveAny(async obj=>await GetHtmlPageAsync(obj));
        }

        private async Task GetHtmlPageAsync(object obj)
        {
            if (obj is string|| obj is Uri)
            {
                var url = obj.ToString();
                var html = await new WebClient().DownloadStringTaskAsync(url);
                Console.WriteLine("\n ====================================");
                Console.WriteLine($"Data for {url}");
                Console.WriteLine(html.Trim().Substring(0,100));
                Console.Read();
            }
            else
            {
                throw new ArgumentNullException(@"Actor does not accept this kind of message");
            }
        }
    }
}