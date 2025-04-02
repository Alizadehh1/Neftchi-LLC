using System.Globalization;

namespace NeftchiLLC.Application.Services
{
    public interface ITranslationService
    {
        string GetTranslation(string key, string language);
    }
}