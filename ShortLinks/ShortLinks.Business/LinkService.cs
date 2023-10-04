using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShortLinks.Core;
using ShortLinks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinks.Business
{
    public class LinkService : ILinkService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LinkService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LinkDto>?> GetLinksAsync()
        {
            var linksDtoList = await _context.Links
                .Select(link => _mapper.Map<LinkDto>(link))
                .ToListAsync();

            return linksDtoList;
        }

        public async Task<LinkDto>? GetLinkByIdAsync(Guid id)
        {
            var link =  await _context.Links.FindAsync(id);

            var linkDto = _mapper.Map<LinkDto>(link);

            return linkDto;
        }

        public async Task<int> CreateLinkAsync(string longUrl)
        {
            var link = new Link
            {
                Id = Guid.NewGuid(),
                LongUrl = longUrl,
                ShortUrl = GenerateShortUrl(),
                DateOfCreation = DateTime.Now,
                NumberOfTransitions = 0
            };
            await _context.Links.AddAsync(link);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> UpdateLinkAsync(LinkDto linkDto)
        {
            var link = await _context.Links
                .FirstOrDefaultAsync(link => link.LongUrl.Equals(linkDto.LongUrl));

            if (link == null)
            {
                return false;
            }
            link.LongUrl = linkDto.LongUrl;
            _context.Entry(link).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteLinkAsync(Guid id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return false;
            }
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerateShortUrl()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var shortUrl = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return shortUrl;
        }
    }
}
