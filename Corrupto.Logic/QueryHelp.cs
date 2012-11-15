using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class QueryHelp : Corrupto.Interfaces.IQuery
    {
        const string RESPONSEHELP = "License? [Nom d'entreprise ou no.RBQ] identifiera une entreprise avec une license en litige. ET Dons? [Codepostal] pour les dons aux partis.";

        public Interfaces.IUnformattedResult Execute()
        {
            return new UnformattedResult()
            {
                RawResult = RESPONSEHELP
            };
        }
    }
}
