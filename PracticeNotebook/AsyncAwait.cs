using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace PracticeNotebook
{
    public class AsyncAwait
    {
        string url = @"https://www.dotnetfoundation.org";

        public async Task HtmlDisplay()
        {
            var client = new HttpClient();
            var html = await client.GetStringAsync(url);
            Console.WriteLine(html);
        }
        
        async Task<string> GetFirstCharactersCountAsync(int count)
        {
            var client = new HttpClient();

            var page = await client.GetStringAsync(url);

            if (count > page.Length)
            {
                return page;
            }
            return page.Substring(0, count);
        }

        async void DisplayResult()
        {
            var chars = await GetFirstCharactersCountAsync(10);
            Console.WriteLine("checkpoint....");
            chars.ToCharArray().ToList().ForEach(s => Console.WriteLine(s));
        }
    }
}