using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Logic
{
    class QueryDons : Corrupto.Interfaces.IQuery
    {
        public string CodePostal { get; set; }

        public enum QueryType
        {
            Max,
            Top3,
            Any,
        };

        private QueryType _type;
        public QueryDons(QueryType type)
        {
            _type = type;
        }

        public Interfaces.IUnformattedResult Execute()
        {
            Interfaces.IUnformattedResult re = new UnformattedResult();
            Corrupto.SvcDataProvider.DonsParti svcData = new Corrupto.SvcDataProvider.DonsParti();
            string rawResult = svcData.GetDonsParti(CodePostal);
            if (!string.IsNullOrEmpty(rawResult))
            {
                re.RawResult += rawResult;
            }
            else
            {
                re.RawResult = "Aucun don pour un partie au codepostal " + CodePostal.ToUpper();
            }

            return re;
        }

    }
}
