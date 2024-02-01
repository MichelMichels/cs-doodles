using AngleSharp;
using AngleSharp.Dom;

namespace MichelMichels.Proverbs;

public class ProverbService : IProverbService
{
    private static readonly string uri = @"https://www.woorden.org/inc/10spreekwoorden.php";

    private readonly IConfiguration configuration = Configuration.Default.WithDefaultLoader();
    private readonly IBrowsingContext context;

    public ProverbService()
    {
        context = BrowsingContext.New(configuration);
    }

    public async Task<string> GetRandomProverb()
    {
        IDocument document = await context.OpenAsync(uri);

        string listItemSelector = "body > ol li";
        IElement? element = document.QuerySelector(listItemSelector);
        if (element == null)
        {
            return string.Empty;
        }

        return element.TextContent;
    }
}
