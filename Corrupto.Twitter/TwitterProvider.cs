using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Twitterizer;

namespace Corrupto.Twitter
{
    public class TwitterProvider
    {
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

        public List<DirectMessage> GetDirectMessages()
        {
            return GetDirectMessages(decimal.Zero);
        }
        public List<DirectMessage> GetDirectMessages(decimal sinceStatusId)
        {
            var options = new DirectMessagesOptions() {
                Count = 200,
                SinceStatusId = sinceStatusId
            };

            var msgs = TwitterDirectMessage.DirectMessages(this.Credentials, options).ResponseObject;
            return (from m in msgs select new DirectMessage{
                Id = m.Id,
                User = m.SenderScreenName,
                Text = m.Text
            }).ToList();
        }

        private void ValidateCredentials()
        {
            if(TwitterAccount.VerifyCredentials(this.Credentials).Result != RequestResult.Success)
            {
                throw(new ApplicationException("Wrong credentials."));
            }
        }
    }
}
