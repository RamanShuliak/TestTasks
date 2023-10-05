using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLinks.Core;
using ShortLinks.Models;

namespace ShortLinks.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly IMapper _mapper;

        public LinkController(ILinkService linkService, IMapper mapper)
        {
            _linkService = linkService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var linkDtoList = await _linkService.GetLinksAsync();

            return View(linkDtoList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLink()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLink(CreateLinkModel linkModel)
        {
            var result = await _linkService.CreateLinkAsync(linkModel.LongUrl);

            return RedirectToAction("Index", "Link");
        }

        [HttpGet]
        public IActionResult GenerateShortUrl()
        {
            var shortUrl = _linkService.GenerateShortUrl();
            return Json(shortUrl);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLink(Guid id)
        {
            if (id != Guid.Empty)
            {
                var linkDto = await _linkService.GetLinkByIdAsync(id);

                return View(linkDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLink(LinkDto linkDto)
        {
            var resultOfEdition = await _linkService.UpdateLinkAsync(linkDto);

            return RedirectToAction("Index", "Link");
        }

        public async Task<IActionResult> DeleteLink(Guid id)
        {
            var result = await _linkService.DeleteLinkAsync(id);

            if (result == 0)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Link");
        }

        [HttpGet]
        public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
        {
            var linkDto = await _linkService.GetLinkByShortUrlAsync(shortUrl);

            if (linkDto == null)
            {
                return NotFound();
            }

            linkDto.NumberOfTransitions++;

            var resultOfUpdate = await _linkService.UpdateNumberOfTransactionsOfLinkAsync(linkDto);

            return Redirect(linkDto.LongUrl);
        }
    }
}
