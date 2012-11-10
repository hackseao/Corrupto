using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class ResultFormatter
    {
        const int MAXRESPONSE = 140;

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
                return from.Substring(0, MAXRESPONSE);

            return string.Empty;
        }
    }
}
