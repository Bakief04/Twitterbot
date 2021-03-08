using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;
using TweetSharp;
using Newtonsoft.Json;


namespace Twitterbot
{
    class Program
    {
        private static string api_key = "UBVfuWPFvlhGJC3yCq2HY8Z36";
        private static string api_key_secret = "Oz1XHOYSIAUuvenvR9o2RIGEVlcSK6y7PFUYddTpRb5ZR28bRd";
        private static string access_token = "1367626134154842115-mHw8G1hFolmUtVlJkNXlBCiIWNkNZs";
        private static string access_token_secret = "WHFaM0VDsMRW2UBEQM7JrsjnS80mihASd9d1sqkJYK9Sr";

        private static TwitterService service = new TwitterService(api_key, api_key_secret, access_token, access_token_secret);

        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started");
            SendTweet("It's Alive");
            Console.Read();
        }

        private static void SendTweet(string _status)
        {
            service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
             {
                 if (response.StatusCode == HttpStatusCode.OK)
                 {
                     Console.ForegroundColor = ConsoleColor.Green;
                     Console.WriteLine($"<{DateTime.Now}> - Tweet Sent!");
                     Console.ResetColor();
                 }
                 else
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine($"<{DateTime.Now}> - Encountered an Error.");
                     Console.ResetColor();
                 }
             });
        }
    }
}