using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichelMichels.PrintingFun.Services;
using System.Printing;

namespace MichelMichels.PrintingFun;

public partial class MainViewModel(IPrintServer printServer) : ObservableObject
{
    private readonly IPrintServer printServer = printServer ?? throw new ArgumentNullException(nameof(printServer));

    [ObservableProperty]
    private string _pdfFilePath;

    [ObservableProperty]
    private List<PrintQueue> _queues = [];

    [ObservableProperty]
    private PrintQueue? _selectedQueue;

    [RelayCommand]
    private void Load()
    {
        Queues = printServer.GetQueues();
    }

    [RelayCommand]
    private void Print()
    {
        if (SelectedQueue == null)
        {
            return;
        }

        printServer.Print(SelectedQueue, "");
    }
}
