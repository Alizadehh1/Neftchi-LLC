using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Interfaces;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Services
{
    public interface ITranslationService
    {
        Task<string> GetTranslation(string key, string language);
        Task SaveTranslationAsync(MultiLanguageContentDto dto);
    }
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository _repository;

        public TranslationService(ITranslationRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetTranslation(string key, string language)
        {
            var result = await _repository.GetAsync(key, language);
            return result?.Value ?? $"[{key}]";
        }

        public async Task SaveTranslationAsync(MultiLanguageContentDto dto)
        {
            var entries = new List<Translation>
            {
                new() { Key = dto.Key, Language = "az", Value = dto.Az },
                new() { Key = dto.Key, Language = "en", Value = dto.En },
                new() { Key = dto.Key, Language = "ru", Value = dto.Ru }
            };

            await _repository.SaveMultipleAsync(entries);
        }
    }

}
