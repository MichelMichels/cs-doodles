using System.Printing;

namespace MichelMichels.PrintingFun.Services;

public interface IPrintServer
{
    List<PrintQueue> GetQueues();
    void Print(PrintQueue queue, string filePath);
}
