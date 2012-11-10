using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class QueryHelp : Corrupto.Interfaces.IQuery
    {
        public enum QueryType
        {
            Max,
            Top3,
            Any,
            Help
        };

        private QueryType _type;
        public QueryHelp(QueryType type)
        {
            _type = type;
        }

        public Interfaces.IUnformattedResult Execute()
        {
            throw new NotImplementedException();
        }
    }
}
