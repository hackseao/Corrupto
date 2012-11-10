using System;
using System.Collections.Generic;
using Corrupto.Twitter;
using Corrupto.Interfaces;

namespace Corrupto.Logic
{
    public class CorruptoInstance
    {
        private TwitterProvider _twitter;

        public CorruptoInstance()
        {
            _twitter = new TwitterProvider();
        }

        public void Execute(CorruptoExecutionState state)
        {
            _twitter.ReciprocateFriendships();

            var mentions = _twitter.GetMentions(state.LastMentionStatusId); // also follows whomever mentions Corrupto
            var directMessages = _twitter.GetDirectMessages(state.LastDirectMessageStatusId);

            string tmpReply = "Bien reçu @{0} mais je ne suis pas encore prêt! Patience!";

            foreach(var mention in mentions)
            {
                //IResult result = Search(mention.Text);
                //_twitter.SendDirectMessage(mention.UserId, result.ResultToDisplay);
                _twitter.SendDirectMessage(mention.UserId, String.Format(tmpReply, mention.Username));

            }

            foreach(var message in directMessages)
            {
                //IResult result = Search(message.Text);
                //_twitter.SendDirectMessage(message.UserId, result.ResultToDisplay);
                _twitter.SendDirectMessage(message.UserId, String.Format(tmpReply, message.Username));
            }
        }

        private IResult Search(string query)
        {
            Search search = new Search();
            return search.ExecuteSearch(query);
        }
    }
}
