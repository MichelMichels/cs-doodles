namespace MichelMichels.Proverbs;

public interface IProverbService
{
    Task<string> GetRandomProverb();
}
