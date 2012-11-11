using System;
using System.Linq;
using System.Collections.Generic;
using Corrupto.Twitter;
using Corrupto.Interfaces;

namespace Corrupto.Logic
{
    public class CorruptoInstance
    {
        private TwitterProvider _twitter;

        public static bool InstanceActive
        {
            get;
            set;
        }

        public CorruptoInstance()
        {
            _twitter = new TwitterProvider();
        }

        public void Execute()
        {
            CorruptoInstance.InstanceActive = true;

            var state = ExecutionStatePersistence.Get();

            _twitter.ReciprocateFriendships();

            var mentions = _twitter.GetMentions(state.LastMentionStatusId); // also follows whomever mentions Corrupto
            var directMessages = _twitter.GetDirectMessages(state.LastDirectMessageStatusId);

            foreach(var mention in mentions)
            {
                string query = CleanQuery(mention.Text);
                string answer = Search(query);
                _twitter.Tweet(FormatAnswer(answer, mention.Username));
            }

            foreach(var message in directMessages)
            {
                string query = CleanQuery(message.Text);
                string answer = Search(query);
                _twitter.SendDirectMessage(message.UserId, FormatAnswer(answer, message.Username));
            }

            var newState = new ExecutionState()
            {
                LastMentionStatusId = mentions.Count() > 0 ? mentions.Max(m => m.Id) : state.LastMentionStatusId,
                LastDirectMessageStatusId = directMessages.Count() > 0 ? directMessages.Max(m => m.Id) : state.LastDirectMessageStatusId
            };

            ExecutionStatePersistence.Set(newState);

            CorruptoInstance.InstanceActive = false;
        }

        private string Search(string query)
        {
            Search search = new Search();
            return search.ExecuteSearch(query).ResultToDisplay;
        }

        private string CleanQuery(string message)
        {
            return message.Replace("@CorruptoLeRaton", String.Empty);
        }

        private string FormatAnswer(string answer, string username)
        {
            string raw = String.Format("@{0} {1}", username, answer);
            if(raw.Length > 140) raw = raw.Substring(0, 140);
            return raw;
        }
    }
}
