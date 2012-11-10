using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Interfaces
{
    public interface IQuery
    { //Key; Values

        IUnformattedResult Execute();
    }
}
