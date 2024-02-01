using AngleSharp;
using AngleSharp.Dom;

string uri = @"https://kbopub.economie.fgov.be/kbopub/zoeknummerform.html?nummer=0897067282&actionLu=Zoek";

IConfiguration configuration = Configuration.Default.WithDefaultLoader();
IBrowsingContext context = BrowsingContext.New(configuration);

IDocument document = await context.OpenAsync(uri);

string rowSelector = "#table > table:nth-child(1) > tbody > tr";
IHtmlCollection<IElement> rows = document.QuerySelectorAll(rowSelector);

Dictionary<string, string> scrapedData = [];
foreach (IElement row in rows)
{
    IHtmlCollection<IElement> tableCells = row.QuerySelectorAll("td");

    if (tableCells.Length == 2)
    {
        scrapedData.Add(tableCells[0].TextContent.Trim().Replace(":", ""), tableCells[1].TextContent.Trim().Replace("\n", "; ").Replace("\t", " "));

        if (scrapedData.Last().Key == "Naam")
        {
            //Debugger.Break();
        }
    }
}

foreach (KeyValuePair<string, string> kvp in scrapedData)
{
    Console.WriteLine($"[ {kvp.Key}, {kvp.Value} ]");
}