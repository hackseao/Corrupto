﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corrupto.Interfaces;

namespace Corrupto.Logic
{
    public class QueryStringParser
    {
        private string _rawQueryString = "";

        public QueryStringParser(string rawQueryString)
        {
            if (!string.IsNullOrEmpty(rawQueryString))
            _rawQueryString = rawQueryString.Trim();
        }

        public List<IQuery> GetQueries()
        {
            List<IQuery> result = new List<IQuery>();
            //Add Langage stemming here
            
            //For each command or source;
            //      Return a new Query to executed down a search.
            IQuery helpQuery = GetCommandListQuery(_rawQueryString);
            if (helpQuery!=null)
                result.Add(helpQuery);

            IQuery licenseQuery = GetCommandLicenseListQuery(_rawQueryString);
            if (licenseQuery != null)
                result.Add(licenseQuery);

            //TODO: Add more parsers here.

            return result;
        }

        private IQuery GetCommandListQuery(string queryString)
        {
            if (queryString.ToLower().Contains("aide")
                || queryString.ToLower().Contains("-a")
                || queryString.ToLower().Contains("help")
                || queryString.ToLower().Contains("-?"))
                    return new QueryHelp();
            
            return null;
        }

        private IQuery GetCommandLicenseListQuery(string queryString)
        {
            if (queryString.ToLower().Contains("license"))
                return new QueryLicense(QueryLicense.QueryType.Top3);

            return null;
        }
    }
}
