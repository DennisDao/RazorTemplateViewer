using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RazorTemplateViewer.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private bool _isSizeChanged = false;
        public Home()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await InitWebView();
            InitHtmlEditor();
            InitJsonEditor();
        }

        private void InitJsonEditor()
        {
            JsonEditor.Text  = @"
            {
              ""id"": 1024,
              ""name"": ""ZebraTech"",
              ""isActive"": true,
              ""created"": ""2025-10-18T23:09:00Z"",
              ""tags"": [""AI"", ""WPF"", ""PDF"", ""Razor""],
              ""metrics"": {
                ""downloads"": 15432,
                ""rating"": 4.7,
                ""contributors"": 12
              },
              ""features"": [
                { ""name"": ""Template Rendering"", ""enabled"": true },
                { ""name"": ""PDF Export"", ""enabled"": true },
                { ""name"": ""Live Preview"", ""enabled"": false }
              ]
            }";
        }

        //private void pdfWebViewer_SizeChanged(object sender, RoutedEventArgs e)
        //{
        //    pdfWebViewer.Width = Double.NaN;
        //    HtmlEditor.SizeChanged -= pdfWebViewer_SizeChanged;
        //    JsonEditor.SizeChanged -= pdfWebViewer_SizeChanged;
        //}

        private async Task InitWebView()
        {
            await pdfWebViewer.EnsureCoreWebView2Async(null);

            byte[] pdfBytes;
            using (FileStream fs = new FileStream(@"C:\Users\Dennis\Desktop\Documents\thue duong cua ong.pdf", FileMode.Open, FileAccess.Read))
            {
                pdfBytes = new byte[fs.Length];
                fs.Read(pdfBytes, 0, pdfBytes.Length);
            }

            string base64Pdf = Convert.ToBase64String(pdfBytes);
            string pdfDatUri = $"data:application/pdf;base64,{base64Pdf}";

            pdfWebViewer.CoreWebView2.Navigate(pdfDatUri);
            //pdfWebViewer.Width = 800;
        }

        private async void InitHtmlEditor()
        {
            HtmlEditor.Text = @"
            <!DOCTYPE html>
            <html lang=""en"">
            <head>
              <meta charset=""UTF-8"">
              <title>Fruit Fiesta</title>
              <style>
                body {
                  font-family: Arial, sans-serif;
                  background-color: #f0f8ff;
                  text-align: center;
                  padding: 20px;
                }
                h1 {
                  color: #ff6347;
                }
                ul {
                  list-style-type: none;
                  padding: 0;
                }
                li {
                  background: #ffe4b5;
                  margin: 5px;
                  padding: 10px;
                  border-radius: 5px;
                }
                button {
                  margin-top: 20px;
                  padding: 10px 20px;
                  font-size: 16px;
                }
              </style>
            </head>
            <body>
              <h1>Welcome to Fruit Fiesta 🍓🍍🍇</h1>
              <p>Here are some delicious fruits:</p>
              <ul>
                <li>Strawberries</li>
                <li>Pineapple</li>
                <li>Grapes</li>
                <li>Mango</li>
                <li>Blueberries</li>
              </ul>
              <button onclick=""document.body.style.backgroundColor = '#ffe4e1'"">
                Change Background
              </button>
            </body>
            </html>";
        }

        private void GridSplitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            if(_isSizeChanged == false)
            {
                pdfWebViewer.Width = Double.NaN;
                _isSizeChanged = true;

            }
           
        }
    }
}
