using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsDumper
{
    class TweetData
    {
        public string author { get; set; }
        public string content { get; set; }
        public string region { get; set; }
        public string language { get; set; }
        public string tweet_date { get; set; }
        public string tweet_time { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int following { get; set; }
        public int follower { get; set; }
        public string post_url { get; set; }
        public string post_type { get; set; }
        public int retweet { get; set; }

        public string tweet_id { get; set; }
        public string author_id {get; set;}
        public string acc_category { get; set; }
        public int newjune_2018 { get; set; }
    }
}
