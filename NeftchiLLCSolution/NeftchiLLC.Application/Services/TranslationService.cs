using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NeftchiLLC.Application.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ResourceManager _resourceManager;
        private static readonly HashSet<string> _supportedLanguages = new() { "az", "en" }; // ✅ Define valid languages

        public TranslationService()
        {
            _resourceManager = new ResourceManager("NeftchiLLC.Application.Resources.Translations", Assembly.GetExecutingAssembly());
        }

        public string GetTranslation(string key, string language)
        {
            // ✅ Validate language
            if (!_supportedLanguages.Contains(language.ToLower()))
            {
                return "Invalid Language Code";  // Return error message if language is not valid
            }

            CultureInfo culture = new CultureInfo(language);
            var translatedText = _resourceManager.GetString(key, culture);

            return translatedText ?? key; // ✅ Return translation if found, else return the key
        }
    }
}
