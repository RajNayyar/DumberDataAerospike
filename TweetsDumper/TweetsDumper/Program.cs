using Aerospike.Client;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsDumper
{
    class Program
    {
        public static List<TweetData> GetTweetDataFromFile()
        {
            List<TweetData> TrollData = new List<TweetData>();

            var path = @"C:\Users\rnayyar\Desktop\2018-08-charlottesville-twitter-trolls-master\data\tweets1.csv";

            var reader = new StreamReader(File.OpenRead(path));

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();
                for(int i=0;i<20000;i++)
                {
                    TweetData Troll = new TweetData();
                    string[] fields = csvParser.ReadFields();

                    Troll.author = fields[0];
                    Troll.content = fields[1]; 
                    Troll.region = fields[2];
                    Troll.language = fields[3];
                    Troll.tweet_date = fields[4];
                    Troll.tweet_time = fields[5];
                    Troll.year = int.Parse( fields[6]);
                    Troll.month =int.Parse(fields[7]);
                    Troll.hour = int.Parse(fields[8]);
                    Troll.minute = int.Parse(fields[9]);
                    Troll.following = int.Parse(fields[10]);
                    Troll.follower= int.Parse(fields[11]);

                    Troll.post_url = fields[12];
                    Troll.post_type = fields[13];
                    Troll.retweet = int.Parse(fields[14]);

                    Troll.tweet_id = (fields[15]);
                    Troll.author_id = (fields[16]);
   
                    Troll.acc_category = (fields[17]);
                    Troll.newjune_2018 = int.Parse(fields[18]); 
                    TrollData.Add(Troll);
                }
            }
            return TrollData;
        }
        static void Main(string[] args)
        {
            List<TweetData> TrollData = new List<TweetData>();
            TrollData = GetTweetDataFromFile();
            for(int i=0;i<TrollData.Count;i++)
            {
                Console.WriteLine(TrollData[i].content);
            }
            var client = new AerospikeClient("18.235.70.103", 3000);
            string nameSpace = "AirEngine";
            string setName = "Rajpreet2";
            
            for (int i = 1; i < TrollData.Count; i++)
            {
                Key key = new Key(nameSpace, setName, TrollData[i].tweet_id.ToString());
                client.Put(new WritePolicy(), key, new Bin[] { new Bin("author", TrollData[i].author), new Bin("content", TrollData[i].content), new Bin("region", TrollData[i].region), new Bin("language", TrollData[i].language), new Bin("tweet_date", TrollData[i].tweet_date), new Bin("tweet_time", TrollData[i].tweet_time), new Bin("year", TrollData[i].year), new Bin("month", TrollData[i].month), new Bin("hour", TrollData[i].hour), new Bin("minute", TrollData[i].minute), new Bin("following", TrollData[i].following), new Bin("follower", TrollData[i].follower), new Bin("post_url", TrollData[i].post_url), new Bin("post_type", TrollData[i].post_type), new Bin("retweet", TrollData[i].retweet), new Bin("tweet_Id", TrollData[i].tweet_id), new Bin("author_id", TrollData[i].author_id), new Bin("acc_category", TrollData[i].acc_category), new Bin("new_june_2018", TrollData[i].newjune_2018) });
                Console.WriteLine(i);
            }
                Console.ReadKey();
        }
    }
}
