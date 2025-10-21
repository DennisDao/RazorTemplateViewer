using DinkToPdf;
using DinkToPdf.Contracts;
using Newtonsoft.Json;
using RazorLight;
using System.Dynamic;

namespace RazorTemplateViewer.Services
{
    public class PdfGenerator : IPdfService
    {
        private static IConverter _pdfConverter = new SynchronizedConverter(new PdfTools());

        public PdfGenerator()
        {
            
        }

        public async Task<byte[]> Render(string htmlTemplate, string json)
        {
            if (string.IsNullOrEmpty(htmlTemplate) || string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("htmlTemplate or json cannot be blank");
            }

            var razorEngine = new RazorLightEngineBuilder().Build();

            var model = JsonConvert.DeserializeObject<ExpandoObject>(json) ?? new ExpandoObject();
            var html = await razorEngine.CompileRenderStringAsync(new Guid().ToString(), htmlTemplate, model);
            var doc = new HtmlToPdfDocument() {  GlobalSettings = { PaperSize = DinkToPdf.PaperKind.A4 }, Objects =  { new ObjectSettings{ HtmlContent = html,}}};

            return _pdfConverter.Convert(doc);
        }
    }
}
