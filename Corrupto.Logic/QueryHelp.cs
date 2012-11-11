using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    public class QueryHelp : Corrupto.Interfaces.IQuery
    {
        const string RESPONSEHELP = "Utiliser le format suivant [commande] [source] [codepostal]/n" + 
            "commande: aide, max, top3, /n"+ 
            "source: Contrats, Dons, /n" +
            "example: max don H0H0H0";

        public Interfaces.IUnformattedResult Execute()
        {
            return new UnformattedResult()
            {
                RawResult = RESPONSEHELP
            };
        }
    }
}
