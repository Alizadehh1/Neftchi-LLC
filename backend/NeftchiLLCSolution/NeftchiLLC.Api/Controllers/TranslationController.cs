using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Api.Controllers
{
    [ApiController]
    [Route("api/translation")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("{language}/{key}")]
        public async Task<IActionResult> Get(string language, string key)
        {
            var value = await _translationService.GetTranslation(key, language);
            return Ok(new { key, value });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MultiLanguageContentDto dto)
        {
            await _translationService.SaveTranslationAsync(dto);
            return Ok();
        }
 
    }
}
