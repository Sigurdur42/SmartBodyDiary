using System.Diagnostics;
using Avalonia.Controls;

namespace SmartBodyDiary;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;
    public MainWindow()
    {
        InitializeComponent();

        _viewModel = new();
        DataContext = _viewModel;

        Trace.TraceWarning("My first warning");
        Trace.TraceError("My first Error");
        Trace.TraceInformation("My first info");
    }
}