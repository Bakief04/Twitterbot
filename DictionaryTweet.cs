using System;
using System.Collections.Generic;
using System.Text;

namespace Twitterbot
{
    //foreach key value pair
    public class DictionaryTweet
    {
        static void List(string[] args)
        {
            List<string> TweetOptions = new List<string>();
            TweetOptions.Add("Twitter is cool.");
            TweetOptions.Add("This is a test.");
            TweetOptions.Add("Hello World!");
            TweetOptions.Add("This is a Twitter Bot.");
        }
    }
}
