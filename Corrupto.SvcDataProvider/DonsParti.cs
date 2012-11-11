using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.SvcDataProvider
{
    public class DonsParti
    {
        public string GetDonsParti(string codepostal)
        {
            if (string.IsNullOrEmpty(codepostal))
                throw new InvalidOperationException("The field codepostal is required!");

            DonsPartiServiceReference.corruptoSoapClient client = new DonsPartiServiceReference.corruptoSoapClient();

            //contribution par codepostal h8n
            string result = client.InterrogerCorrupto(string.Format("contribution par codepostal {0}", codepostal.Trim().ToUpper()));
            if (!String.IsNullOrEmpty(result))
                return result;

            //Else case if no rows found.
            //ret.Add("Aucun don au pour le code postal " + codepostal);
            return string.Empty;
        }
    }
}
