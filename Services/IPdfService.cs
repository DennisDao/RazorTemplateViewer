namespace RazorTemplateViewer.Services
{
    interface IPdfService
    {
        public Task<byte[]> Render(string template, string model);
    }
}
