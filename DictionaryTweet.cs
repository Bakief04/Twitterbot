using System;
using System.Collections.Generic;
using System.Text;

namespace Twitterbot
{
    //foreach key value pair
    public class DictionaryTweet
    {
        public static void Mylist(string[] args)
        {
            List<string> TweetOptions = new List<string>();
            TweetOptions.Add("Twitter is cool.");
            TweetOptions.Add("This is a test.");
            TweetOptions.Add("Hello World!");
            TweetOptions.Add("This is a Twitter Bot.");
        }
    }
}
//var tweetOptionsCount = 1;
//foreach (var TweetOption in TweetOptions)
//{
//    Console.WriteLine($"{tweetOptionsCount++ } { TweetOption}");
//}