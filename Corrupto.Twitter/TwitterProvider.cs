using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Twitterizer;

namespace Corrupto.Twitter
{
    public class TwitterProvider
    {
        private const int MaxResultsPerQuery = 200;
        private OAuthTokens Credentials
        {
            get
            {
                return new OAuthTokens()
                {
                    AccessToken = ConfigurationManager.AppSettings["twitterAccessToken"],
                    AccessTokenSecret = ConfigurationManager.AppSettings["twitterAccessTokenSecret"],
                    ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"]
                };
            }
        }

        public TwitterProvider()
        {
            ValidateCredentials();
        }

        public void ReciprocateFriendships()
        {
            var followersIds = TwitterFriendship.FollowersIds(this.Credentials).ResponseObject;
            var friendsIds = TwitterFriendship.FriendsIds(this.Credentials).ResponseObject;
            
            foreach(var followerId in followersIds)
            {
                if(!friendsIds.Contains(followerId))
                {
                    TwitterFriendship.Create(this.Credentials, followerId);
                }
            }
        }
        
        public List<Message> GetDirectMessages(decimal sinceStatusId)
        {
            var query = TwitterDirectMessage.DirectMessages(this.Credentials, new DirectMessagesOptions() {
                Count = MaxResultsPerQuery,
                SinceStatusId = sinceStatusId
            }).ResponseObject;

            var messages = (from m in query select new Message {
                Id = m.Id,
                UserId = m.SenderId,
                Username = m.SenderScreenName,
                Text = m.Text
            }).ToList();

            return messages;
        }
        public List<Message> GetMentions(decimal sinceStatusId)
        {
            var query = TwitterTimeline.Mentions(this.Credentials, new TimelineOptions()
            {
                Count = MaxResultsPerQuery,
                SinceStatusId = sinceStatusId
            }).ResponseObject;

            var mentions = (from m in query
                    select new Message
                    {
                        Id = m.Id,
                        UserId = m.User.Id,
                        Username = m.User.ScreenName,
                        Text = m.Text
                    }).ToList();

            this.Follow(mentions.Select(m => m.UserId).ToList());

            return mentions;
        }

        private void ValidateCredentials()
        {
            if(TwitterAccount.VerifyCredentials(this.Credentials).Result != RequestResult.Success)
            {
                throw(new ApplicationException("Wrong credentials."));
            }
        }
        private void Follow(List<decimal> userIds)
        {
            var friendsIds = TwitterFriendship.FriendsIds(this.Credentials).ResponseObject;
            foreach(var userId in userIds)
            {
                if(!friendsIds.Contains(userId))
                {
                    TwitterFriendship.Create(this.Credentials, userId);
                }
            }
        }
    }
}
