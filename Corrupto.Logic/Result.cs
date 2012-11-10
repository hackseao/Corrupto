using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class Result : Corrupto.Interfaces.IResult
    {
        string _resultToDisplay;
        public string ResultToDisplay
        {
            get
            {
                return _resultToDisplay;
            }
            set
            {
                _resultToDisplay = value;
            }
        }
    }
}
