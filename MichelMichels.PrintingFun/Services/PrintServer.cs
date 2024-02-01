using MichelMichels.PrintingFun.Services;
using System.IO;
using System.Printing;
using System.Text;

namespace MichelMichels.PrintingFun;

public class PrintServer : IPrintServer
{
    private readonly LocalPrintServer localPrintServer = new();

    public List<PrintQueue> GetQueues()
    {
        return localPrintServer.GetPrintQueues().ToList();
    }

    public void Print(PrintQueue queue, string filePath)
    {
        PrintSystemJobInfo job = queue.AddJob();

        Stream stream = job.JobStream;

        byte[] buffer = Encoding.Unicode.GetBytes("This is a test string for the print job stream.");
        stream.Write(buffer, 0, buffer.Length);
        stream.Close();
    }
}
