using System.Windows;

namespace MichelMichels.PrintingFun;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow view = new(new MainViewModel(new PrintServer()));
        view.Show();
    }
}
