using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    class QueryLicense : Corrupto.Interfaces.IQuery
    {
        public string Nom {get; set;}
        public string Nom2 { get; set; }
        public string NumeroLicense { get; set; }

        public enum QueryType
        {
            Max,
            Top3,
            Any,
        };

        private QueryType _type;
        public QueryLicense(QueryType type)
        {
            _type = type;
        }

        public Interfaces.IUnformattedResult Execute()
        {
            Interfaces.IUnformattedResult re = new UnformattedResult();
            Corrupto.Data.Licence data = new Data.Licence(ConfigurationManager.ConnectionStrings["CorruptoDB"].ConnectionString);
            List<string> rawResult = data.GetLicense(Nom, Nom2, NumeroLicense);
            if (rawResult != null && rawResult.Count > 0)
            {
                re.RawResult = "NON! ";

                foreach (string r in rawResult)
                    re.RawResult += r;
            }
            else 
            {
                re.RawResult = "Cette entreprise ne figure au registre des licenses révoquées.";
            }

            return re;
        }
    }
}
