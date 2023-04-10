using NUnit.Framework;
using System.Collections;

namespace SearchModuleEngine.InputData.TestCaseSource
{
    internal static class SearchEngineInputData
    {
        public static IEnumerable SearchEngineTestCase
        {
            get
            {
                yield return new TestCaseData(
                    "", ArticuleType.Newsletter, null,
                    new List<string> { "Efterårsnyt", "Forårsnyt", "Ny organisationsstruktur", "Sommernyt" })
                    .SetCategory("SmokeTests")
                    .SetName("Search Newsletter");
                yield return new TestCaseData(
                    "", ArticuleType.Newsletter, SelectYearOptions.Year2022,
                    new List<string> { "Efterårsnyt", "Forårsnyt", "Ny organisationsstruktur", "Sommernyt" })
                    .SetCategory("SmokeTests")
                    .SetName("Search Newsletter 2022");
                yield return new TestCaseData(
                    "", null,null,
                    new List<string> { "Den længe ventede rapport er nu lanceret", "Efterårsnyt", "Forårsnyt", "Ny organisationsstruktur", "Sommernyt", "Tilladelse til indvinding af grundvand og screeningsafgørelse" })
                    .SetCategory("SmokeTests")
                    .SetName("Search No filters");
                yield return new TestCaseData(
                    "Efterårsnyt", null, null,
                    new List<string> { "Efterårsnyt" })
                    .SetCategory("SmokeTests")
                    .SetName("Search Efterårsnyt");
                yield return new TestCaseData(
                    "", null, SelectYearOptions.Year2015,
                    new List<string> { })
                    .SetCategory("SmokeTests")
                    .SetName("Search 2015");
                yield return new TestCaseData(
                    "lanceret", ArticuleType.Publication, SelectYearOptions.Year2022,
                    new List<string> { "Den længe ventede rapport er nu lanceret" })
                    .SetCategory("SmokeTests")
                    .SetName("Search lanceret Publication 2022");
            }
        }
    }
}
