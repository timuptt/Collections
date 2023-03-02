using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Models.Items;
using Collections.Web.Models.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Collections.Web.Api.Controllers
{
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IReadRepository<Tag> _tagReadRepository;

        public TagController(IReadRepository<Tag> tagReadRepository, IRepository<Tag> tagRepository)
        {
            _tagReadRepository = tagReadRepository;
        }
        
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> Search(string term)
        {
            if (term.IsNullOrEmpty()) return Ok();
            var specification = new TagsByPrefixSpec(term, 10);
            var tags = await _tagReadRepository.ListProjectedAsync<TagViewModel>(specification);
            return Ok(tags);
        }

        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetTopTags()
        {
            var specification = new TagsWithWeightSpec(50);
            var tags = await _tagReadRepository.ListProjectedAsync<CloudTagViewModel>(specification);
            return Ok(tags);
        }
    }
}
