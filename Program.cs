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
            //instantiate into class
            //create object from class
            //Master Loop
            bool menu = true;

            while (menu)
            {
                //menu for tweetbot
                Console.WriteLine("Welcome to the twitterbot. \n Please make a selection \n 1.Send Tweet \n 2. Send Random Tweet \n 3. Quit");
                //tryparse
                string menuselection = Console.ReadLine();

                int num = 0;
                bool success = Int32.TryParse(menuselection, out num);
                List<string> TweetOptions = new List<string>();
                TweetOptions.Add("Twitter is cool.");
                TweetOptions.Add("This is a test.");
                TweetOptions.Add("Hello World!");
                TweetOptions.Add("This is a Twitter Bot.");

                if (num == 1)
                {
                    Console.WriteLine($"<{DateTime.Now}> - Bot Started");

                    //add dictionary or list to the sendtweet variable foreach
                    var tweetOptionsCount = 1;
                    foreach (var TweetOption in TweetOptions)
                    {
                        Console.WriteLine($"{tweetOptionsCount++} {TweetOption}");
                    }
                    string tweetChoice = Console.ReadLine();
                    int selection;
                    Int32.TryParse(tweetChoice, out selection);
                    if (selection == 1)
                        {
                        SendTweet(TweetOptions[0]);
                        }
                    if (selection == 2)
                        {
                        SendTweet(TweetOptions[1]);
                        }
                    if (selection == 3)
                        {
                        SendTweet(TweetOptions[2]);
                        }
                    if (selection == 4)
                        {
                        SendTweet(TweetOptions[3]);
                        }
                    //SendTweet(tweetChoice);
                    //Figure out how to make this wait until after tweet is sent or not sent
                    //wait
                    Console.WriteLine("Would you like to send another tweet? [Y/N]");
                }
                //fix by adding a random selection from list
                if (num == 2)
                {
                    Console.WriteLine("Currently under construction");
                }
                if (num == 3)
                {
                    break;
                }
                //make it so if anything else comes back as a non valid input
                string endmenu = Console.ReadLine();
                endmenu = endmenu.ToUpper();
                if (endmenu == "Y")
                {
                    continue;
                }
                if (endmenu == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Thats not a valid input");
                }
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