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
                uresult.Add(new UnformattedResult(){RawResult = "Je ne comprends pas la question!"});

            ResultFormatter rFormatter = new ResultFormatter();
            return rFormatter.Format(uresult);
        }
    }
}
