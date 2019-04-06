namespace JokesFunApp.Services.DataServices
{
    using Ganss.XSS;

    public class HtmlSanitizerService : IHtmlSanitizerService
    {
        private readonly HtmlSanitizer htmlSanitizer;

        public HtmlSanitizerService(HtmlSanitizer htmlSanitizer)
        {
            this.htmlSanitizer = htmlSanitizer;
        }
        public string Sanitize(string input)
        {
            var sanitizedInput = this.htmlSanitizer.Sanitize(input);

            return sanitizedInput;
        }
    }
}
