using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class ResultFormatter
    {
        const int MAXRESPONSE = 130;

        public Corrupto.Interfaces.IResult Format(List<Corrupto.Interfaces.IUnformattedResult> uresults)
        {
            if (uresults.Count() == 1)
                return Format(uresults.First());

            return null;
        }

        private Corrupto.Interfaces.IResult Format(Corrupto.Interfaces.IUnformattedResult uresult)
        {
            //ToDo Apply result filters here
            return new Result() { ResultToDisplay = applyMaxCharFilter(uresult.RawResult) };
        }

        private string applyMaxCharFilter(string from)
        {
            if (!string.IsNullOrEmpty(from))
            {
                if (from.Length > MAXRESPONSE)
                    return from.Substring(1, MAXRESPONSE);
                else
                    return from;
            }

            return string.Empty;
        }
    }
}
