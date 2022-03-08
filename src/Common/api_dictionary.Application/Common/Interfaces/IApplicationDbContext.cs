using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        DbSet<District> Districts { get; set; }

        DbSet<Village> Villages { get; set; }

        DbSet<Translation> Translations { get; set; }
        DbSet<ThematicDictionary> ThematicDictionaries { get; set; }
        DbSet<ThematicDictionaryTranslation> ThematicDictionaryTranslations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
