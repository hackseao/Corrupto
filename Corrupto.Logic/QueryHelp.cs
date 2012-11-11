using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class QueryHelp : Corrupto.Interfaces.IQuery
    {
        const string RESPONSEHELP = "La commande: License? [Nom d'entreprise] identifiera une entreprise avec une license en litige.";

        public Interfaces.IUnformattedResult Execute()
        {
            return new UnformattedResult()
            {
                RawResult = RESPONSEHELP
            };
        }
    }
}
