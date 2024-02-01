using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasDemos;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnContentRendered(EventArgs e)
    {
        label.Content = "Loaded.";

        base.OnContentRendered(e);
    }

    private void canvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        int x = (int)e.GetPosition(this).X;
        int y = (int)e.GetPosition(this).Y;

        label.Content = $"[{DateTime.Now}] Mouse down on canvas ({x}, {y})";

        Rectangle rectangle = new()
        {
            Fill = new SolidColorBrush(Colors.Black),
            Width = 10,
            Height = 10,
        };

        canvas.Children.Add(rectangle);
        Canvas.SetLeft(rectangle, x - (10 / 2));
        Canvas.SetTop(rectangle, y - (10 / 2));
    }
}