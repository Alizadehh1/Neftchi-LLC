using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Interfaces;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Repositories.Concrete
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly DbContext _context;

        public TranslationRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Translation?> GetAsync(string key, string language)
        {
            return await _context.Set<Translation>()
                .FirstOrDefaultAsync(x => x.Key == key && x.Language == language);
        }

        public async Task SaveOrUpdateAsync(Translation translation)
        {
            var existing = await GetAsync(translation.Key, translation.Language);
            if (existing != null)
            {
                existing.Value = translation.Value;
            }
            else
            {
                await _context.Set<Translation>().AddAsync(translation);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveMultipleAsync(List<Translation> translations)
        {
            foreach (var t in translations)
            {
                await SaveOrUpdateAsync(t);
            }
        }
    }
}
