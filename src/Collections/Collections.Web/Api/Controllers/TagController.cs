using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Collections.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IReadRepository<Tag> _tagReadRepository;
        private readonly IRepository<Tag> _tagRepository;

        public TagController(IReadRepository<Tag> tagReadRepository, IRepository<Tag> tagRepository)
        {
            _tagReadRepository = tagReadRepository;
            _tagRepository = tagRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Search(string term)
        {
            if (term.IsNullOrEmpty()) return Ok();
            var specification = new TagsByPrefixSpec(term, 10);
            var tags = await _tagReadRepository.ListProjectedAsync<TagViewModel>(specification);
            return Ok(tags);
        }
    }
}
