namespace JokesFunApp.Services.DataServices
{
    public interface IHtmlSanitizerService
    {
        string Sanitize(string input);
    }
}
