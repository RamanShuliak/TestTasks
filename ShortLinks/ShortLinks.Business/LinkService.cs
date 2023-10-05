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

        public async Task<LinkDto>? GetLinkByShortUrlAsync(string url)
        {
            var link = await _context.Links
                .FirstOrDefaultAsync(link => link.ShortUrl.Equals(url));

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
            var resultOfAdding = await _context.Links.AddAsync(link);
            var resultOfSaving = await _context.SaveChangesAsync();

            return resultOfSaving;
        }

        public async Task<int> UpdateLinkAsync(LinkDto linkDto)
        {
            var link = await _context.Links
                .FirstOrDefaultAsync(link => link.Id.Equals(linkDto.Id));

            link.LongUrl = linkDto.LongUrl;
            link.ShortUrl = linkDto.ShortUrl;
            var resultOfUpdate = _context.Entry(link).State = EntityState.Modified;
            var resultOfSaving = await _context.SaveChangesAsync();

            return resultOfSaving;
        }

        public async Task<int> UpdateNumberOfTransactionsOfLinkAsync(LinkDto linkDto)
        {
            var link = await _context.Links
                .FirstOrDefaultAsync(link => link.Id.Equals(linkDto.Id));

            link.NumberOfTransitions = linkDto.NumberOfTransitions;

            var resultOfUpdate = _context.Entry(link).State = EntityState.Modified;
            var resultOfSaving = await _context.SaveChangesAsync();

            return resultOfSaving;
        }

        public async Task<int> DeleteLinkAsync(Guid id)
        {
            var link = await _context.Links.FindAsync(id);

            var resultOfDelete = _context.Links.Remove(link);
            var resultOfSaving = await _context.SaveChangesAsync();

            return resultOfSaving;
        }

        public string GenerateShortUrl()
        {
            const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var shortUrl = new string(Enumerable.Repeat(CHARS, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return shortUrl;
        }
    }
}
