using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corrupto.Logic.Test
{
    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void SearchHelp()
        {
            Corrupto.Logic.Search search = new Corrupto.Logic.Search();
            string querystring = @"-a blah blah!Kwui Kwui! +";

            Corrupto.Interfaces.IResult result = search.ExecuteSearch(querystring);

            Assert.IsNotNull(result);
            string expectedResult = "Utiliser le format suivant [commande] [source] [codepostal]/n" +
            "commande: aide, max, top3, /n" +
            "source: Contrats, Dons, /n" +
            "example: max don H0H0H0";

            Assert.AreEqual(expectedResult, result.ResultToDisplay);

        }
    }
}
