using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerospikeTweetApi.Models
{
    public class Tweet
    {
        public string author;

        public string tweetId{get; set;}

        public string tweetText { get; set; }
        public string UserFollower { get; internal set; }
        public string UserFollowing { get; internal set; }
    }
}