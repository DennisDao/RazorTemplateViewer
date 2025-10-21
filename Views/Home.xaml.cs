using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using DinkToPdf;
using RazorLight;
using RazorTemplateViewer.Services;
using RazorTemplateViewer.ViewModels.Home;


namespace RazorTemplateViewer.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private DispatcherTimer typingTimer;
        private const string BLANK_PDF = "JVBERi0xLjQKMSAwIG9iago8PAovVGl0bGUgKP7/KQovQ3JlYXRvciAo/v8AdwBrAGgAdABtAGwAdABvAHAAZABmACAAMAAuADEAMgAuADQpCi9Qcm9kdWNlciAo/v8AUQB0ACAANAAuADgALgA3KQovQ3JlYXRpb25EYXRlIChEOjIwMjUxMDE5MjEwMzU1KzExJzAwJykKPj4KZW5kb2JqCjMgMCBvYmoKPDwKL1R5cGUgL0V4dEdTdGF0ZQovU0EgdHJ1ZQovU00gMC4wMgovY2EgMS4wCi9DQSAxLjAKL0FJUyBmYWxzZQovU01hc2sgL05vbmU+PgplbmRvYmoKNCAwIG9iagpbL1BhdHRlcm4gL0RldmljZVJHQl0KZW5kb2JqCjYgMCBvYmoKPDwKL1R5cGUgL0NhdGFsb2cKL1BhZ2VzIDIgMCBSCj4+CmVuZG9iago1IDAgb2JqCjw8Ci9UeXBlIC9QYWdlCi9QYXJlbnQgMiAwIFIKL0NvbnRlbnRzIDcgMCBSCi9SZXNvdXJjZXMgOSAwIFIKL0Fubm90cyAxMCAwIFIKL01lZGlhQm94IFswIDAgNTk2IDg0Ml0KPj4KZW5kb2JqCjkgMCBvYmoKPDwKL0NvbG9yU3BhY2UgPDwKL1BDU3AgNCAwIFIKL0NTcCAvRGV2aWNlUkdCCi9DU3BnIC9EZXZpY2VHcmF5Cj4+Ci9FeHRHU3RhdGUgPDwKL0dTYSAzIDAgUgo+PgovUGF0dGVybiA8PAo+PgovRm9udCA8PAo+PgovWE9iamVjdCA8PAo+Pgo+PgplbmRvYmoKMTAgMCBvYmoKWyBdCmVuZG9iago3IDAgb2JqCjw8Ci9MZW5ndGggOCAwIFIKL0ZpbHRlciAvRmxhdGVEZWNvZGUKPj4Kc3RyZWFtCnic03cPTlRIL1bQdw4uUEiG0s7BXAZ65qYGEKAAgrrIAkYWelC2goWhMZStkJzLVahQyBXIFQgkgbRCIBcA8vgUVgplbmRzdHJlYW0KZW5kb2JqCjggMCBvYmoKNjYKZW5kb2JqCjIgMCBvYmoKPDwKL1R5cGUgL1BhZ2VzCi9LaWRzIApbCjUgMCBSCl0KL0NvdW50IDEKL1Byb2NTZXQgWy9QREYgL1RleHQgL0ltYWdlQiAvSW1hZ2VDXQo+PgplbmRvYmoKeHJlZgowIDExCjAwMDAwMDAwMDAgNjU1MzUgZiAKMDAwMDAwMDAwOSAwMDAwMCBuIAowMDAwMDAwNzk2IDAwMDAwIG4gCjAwMDAwMDAxNjMgMDAwMDAgbiAKMDAwMDAwMDI1OCAwMDAwMCBuIAowMDAwMDAwMzQ0IDAwMDAwIG4gCjAwMDAwMDAyOTUgMDAwMDAgbiAKMDAwMDAwMDYzOCAwMDAwMCBuIAowMDAwMDAwNzc4IDAwMDAwIG4gCjAwMDAwMDA0NjMgMDAwMDAgbiAKMDAwMDAwMDYxOCAwMDAwMCBuIAp0cmFpbGVyCjw8Ci9TaXplIDExCi9JbmZvIDEgMCBSCi9Sb290IDYgMCBSCj4+CnN0YXJ0eHJlZgo4OTQKJSVFT0YK";

        public Home()
        {
            InitializeComponent();

            typingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };
            typingTimer.Tick += TypingTimer_Tick;

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await pdfWebViewer.EnsureCoreWebView2Async(null);
            string pdfDatUri = $"data:application/pdf;base64,{BLANK_PDF}";
            pdfWebViewer.CoreWebView2.Navigate(pdfDatUri);

            HtmlEditor.TextChanged += HtmlEditor_TextChanged;
            JsonEditor.TextChanged += HtmlEditor_TextChanged;
        }

        private void HtmlEditor_TextChanged(object? sender, EventArgs e)
        {
            typingTimer.Stop();
            typingTimer.Start();
        }

        private async void TypingTimer_Tick(object sender, EventArgs e)
        {
            // Stop timer once triggered
            typingTimer.Stop();
            var vm = this.DataContext as HomeViewModel;
            if (!vm.IsRendering)
            {
                vm.IsRendering = true;
                await Render();
                vm.IsRendering = false;
            } 
        }

        private async Task Render()
        {
            var htmlTemplate = HtmlEditor.Document.Text;
            var json = JsonEditor.Text;

            try
            {
                await Task.Run(async () =>
                {
                    IPdfService pdfService = new PdfGenerator();
                    var bytes = await pdfService.Render(htmlTemplate, json);
                    string base64Pdf = Convert.ToBase64String(bytes);
                    string pdfDatUri = $"data:application/pdf;base64,{base64Pdf}";

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        pdfWebViewer.CoreWebView2.Navigate(pdfDatUri);
                    });
                });
            }
            catch (Exception ex) 
            {
                
            }
        }
    }
}
