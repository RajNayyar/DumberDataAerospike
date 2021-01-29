using Aerospike.Client;
using AerospikeTweetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AerospikeTweetApi.Controllers
{
    public class TweetController : ApiController
    {
        AerospikeClient client = new AerospikeClient("18.235.70.103", 3000);
        string nameSpace = "AirEngine";
        string setName = "Rajpreet2";
        [HttpPost]
        [Route("GetTweets")]
        public List<Tweet> GetTweets([FromBody]List<string> tweetsList)
        {

            List<Tweet> tweets = new List<Tweet>();
            foreach (string tweetId in tweetsList)
            {
                Record record = client.Get(new BatchPolicy(), new Key(nameSpace, setName, tweetId.ToString()));
                Tweet tweet = new Tweet();
                tweet.author = record.GetValue("author").ToString();
                tweet.tweetId = record.GetValue("tweet_Id").ToString();
                tweet.tweetText = record.GetValue("content").ToString();
                tweet.UserFollower = record.GetValue("follower").ToString();
                tweet.UserFollowing = record.GetValue("following").ToString();
                tweet.UserFollower = record.GetValue("follower").ToString();
                tweets.Add(tweet);
            }
            return tweets;
        }


        [HttpDelete]
        [Route("DeleteTweet")]
        public void DeleteTweet([FromBody]string tweet)
        {
            try
            {
                client.Delete(new WritePolicy(), new Key(nameSpace, setName, tweet));
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace);
            }
          


        }

        // Put: api/Trolls/ Updataing content of a tweet using their tweet id.
        [HttpPut]
        [Route("PutTweet")]
        public void PutTweet([FromBody]Tweet tweet)
        {
            try
            {
                client.Put(new WritePolicy(), new Key(nameSpace, setName, tweet.tweetId), new Bin[] { new Bin("content", tweet.tweetText) });
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace);
            }
        }
    }
}
