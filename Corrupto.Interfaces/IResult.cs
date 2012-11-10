using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Interfaces
{
    public interface IResult
    {
        /// <summary>
        /// This result should already be formatted for display
        /// </summary>
        string ResultToDisplay { get; set; }
    }
}
