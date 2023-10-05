using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using ShortLinks.Core;
using ShortLinks.DataBase;

namespace ShortLinks.Business.Test
{
    public class LinkServiceTest
    {
        public readonly Mock<ApplicationDbContext> _contextMock = new Mock<ApplicationDbContext>();
        public readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        
        private LinkService GetMockedLinkService()
        {
            var linkService = new LinkService(_contextMock.Object, _mapperMock.Object);

            return linkService;
        }

        [Fact]
        public async Task GetLinkByIdAsync_WithCorrectId_GetLinkDto()
        {
            var linkService = GetMockedLinkService();

            // Arrange
            var link = new Link 
            { 
                Id = Guid.NewGuid(), 
                LongUrl = "https://example.com", 
                ShortUrl = "abc123",
                NumberOfTransitions = 0
            };

            var linkDto = new LinkDto 
            { 
                Id = link.Id, 
                LongUrl = "https://example.com", 
                ShortUrl = "abc123",
                NumberOfTransitions = 0
            };

            //_contextMock.Setup(c => c.Links.FindAsync(link.Id)).ReturnsAsync(link);
            _mapperMock.Setup(m => m.Map<LinkDto>(link)).Returns(linkDto);

            // Act
            var result = await linkService.GetLinkByIdAsync(link.Id);

            // Assert
            Assert.Equal(linkDto, result);
        }
    }
}