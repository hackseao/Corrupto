using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    /// <summary>
    /// Entry Point for Server Data scrapping.
    /// </summary>
    public class Search
    {
        const string IDONTUNDERSTAND = "Je ne comprends pas la question!  Essayez: License? [Nom d'entreprise ou no.RBQ] ou Dons? [Codepostal]";

        public Corrupto.Interfaces.IResult ExecuteSearch(string rawQueryString)
        {
            //Parse
            QueryStringParser parser = new QueryStringParser(rawQueryString);
            //Get commands from parse
            List<Corrupto.Interfaces.IQuery> queries = parser.GetQueries();

            //Analyze queries

            //Get data 

            //Analyze and format results
            List<Corrupto.Interfaces.IUnformattedResult> uresult = new List<Interfaces.IUnformattedResult>();
            foreach (Corrupto.Interfaces.IQuery query in queries)
            {
                Corrupto.Interfaces.IUnformattedResult currentUResult = query.Execute();
                if (currentUResult != null)
                    uresult.Add(currentUResult);
            }

            //No Queries! We got spammed or a typo was made.
            if (queries.Count() == 0)
                uresult.Add(new UnformattedResult(){RawResult = IDONTUNDERSTAND});

            ResultFormatter rFormatter = new ResultFormatter();
            return rFormatter.Format(uresult);
        }
    }
}
