using System;

namespace Corrupto.Logic
{
    public class CorruptoExecutionState
    {
        public decimal LastMentionStatusId { get; set; }
        public decimal LastDirectMessageStatusId { get; set; }

        public CorruptoExecutionState()
        {
            LastMentionStatusId = 0;
            LastDirectMessageStatusId = 0;
        }
    }
}
