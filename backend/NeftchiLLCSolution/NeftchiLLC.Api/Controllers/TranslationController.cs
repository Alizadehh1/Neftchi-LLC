using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Api.Controllers
{
    [Route("api/translation")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("{language}/{key}")]
        public IActionResult GetTranslation(string language, string key)
        {
            var translatedText = _translationService.GetTranslation(key, language);
            return Ok(new { key, translatedText });
        }
    }
}
