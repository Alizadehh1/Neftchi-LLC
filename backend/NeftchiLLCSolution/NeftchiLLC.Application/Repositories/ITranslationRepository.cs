using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Interfaces
{
    public interface ITranslationRepository
    {
        Task<Translation?> GetAsync(string key, string language);
        Task SaveOrUpdateAsync(Translation translation);
        Task SaveMultipleAsync(List<Translation> translations);
    }


}
