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
        
        //API key info (API keys are in seperate file)
        private static TwitterService service = new TwitterService(Apikeys.api_key, Apikeys.api_key_secret, Apikeys.access_token, Apikeys.access_token_secret);


        static void Main(string[] args)
        {
            //Master Loop
            while (true)
            {
                //menu for tweetbot
                Console.WriteLine("Welcome to the twitterbot. \n Please make a selection \n 1.Send Tweet \n 2. Send Random Tweet \n 3. Quit");
                var menuselection = Convert.ToInt32(Console.ReadLine());
                if (menuselection == 1)
                {
                    Console.WriteLine($"<{DateTime.Now}> - Bot Started");
                    
                    //add dictionary or list to the sendtweet variable

                    SendTweet("tweet1");
                }
                //fix by adding a random selection from list
                if (menuselection == 2)
                {
                    Console.WriteLine("Currently under construction");
                }
                if (menuselection == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Thats not a valid input");
                }
                //Figure out how to make this wait until after tweet is sent or not sent
                Console.WriteLine("Would you like to send another tweet?");
            }
        }

        //check to see if Tweet was successful
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