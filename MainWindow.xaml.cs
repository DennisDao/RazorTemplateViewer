using System.Windows;
using RazorTemplateViewer.ViewModels.MainWindow;

namespace RazorTemplateViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}