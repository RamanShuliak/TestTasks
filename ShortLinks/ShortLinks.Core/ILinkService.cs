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
        Task<int> CreateLinkAsync(string longUrl);
        Task<bool> UpdateLinkAsync(LinkDto linkDto);
        Task<bool> DeleteLinkAsync(Guid id);

    }
}
