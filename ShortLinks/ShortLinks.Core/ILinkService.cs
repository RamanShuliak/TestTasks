using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinks.Core
{
    public interface ILinkService
    {
        Task<List<LinkDto>?> GetLinksAsync();
        Task<LinkDto>? GetLinkByIdAsync(Guid id);
        Task<LinkDto>? GetLinkByShortUrlAsync(string url);
        Task<int> CreateLinkAsync(string longUrl);
        Task<int> UpdateLinkAsync(LinkDto linkDto);
        Task<int> UpdateNumberOfTransactionsOfLinkAsync(LinkDto linkDto);
        Task<int> DeleteLinkAsync(Guid id);
        public string GenerateShortUrl();

    }
}
