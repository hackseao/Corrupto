using System;

namespace Corrupto.Logic
{
    public class ExecutionState
    {
        public decimal LastMentionStatusId { get; set; }
        public decimal LastDirectMessageStatusId { get; set; }

        public ExecutionState()
        {
            LastMentionStatusId = 0;
            LastDirectMessageStatusId = 0;
        }
    }
}
