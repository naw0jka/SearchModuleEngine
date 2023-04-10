
namespace SearchModuleEngine.InputData
{
    public class ArticuleDetails
    {
        public Dictionary<string, string> ArticleId = new Dictionary<string, string>()
        {
            {ArticuleType.Newsletter, "6320"},
            {ArticuleType.Publication, "6321"},
        };
    }

    public class ArticuleType
    {
        public const string Newsletter = "Newsletter";
        public const string Publication = "Publication";
    }
}
