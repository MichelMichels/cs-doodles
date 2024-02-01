using MichelMichels.Proverbs;

IProverbService proverbService = new ProverbService();


for (int i = 0; i < 5; i++)
{
    Console.WriteLine(await proverbService.GetRandomProverb());
}