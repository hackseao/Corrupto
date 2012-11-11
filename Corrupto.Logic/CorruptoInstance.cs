﻿using System;
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

            //HACK
            string tmpReply = "Bien reçu @{0} mais je ne suis pas encore prêt! Patience!";

            foreach(var mention in mentions)
            {
                //IResult result = Search(mention.Text);
                _twitter.Tweet(String.Format(tmpReply, mention.Username));
            }

            foreach(var message in directMessages)
            {
                //IResult result = Search(message.Text);
                _twitter.SendDirectMessage(message.UserId, String.Format(tmpReply, message.Username));
            }

            var newState = new ExecutionState()
            {
                LastMentionStatusId = mentions.Count() > 0 ? mentions.Max(m => m.Id) : state.LastMentionStatusId,
                LastDirectMessageStatusId = directMessages.Count() > 0 ? directMessages.Max(m => m.Id) : state.LastDirectMessageStatusId
            };

            ExecutionStatePersistence.Set(newState);

            CorruptoInstance.InstanceActive = false;
        }

        private IResult Search(string query)
        {
            Search search = new Search();
            return search.ExecuteSearch(query);
        }
    }
}
