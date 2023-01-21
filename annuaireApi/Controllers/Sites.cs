using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using annuaireApi.models;
using annuaireApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace annuaireApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        private readonly AnnuaireApiContext _context;

        public SitesController(AnnuaireApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> getAllSites()
        {
            return await _context.Site.ToListAsync();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> getSiteById(int id)
        {
            var site = await _context.Site.Where(s => s.id.Equals(id)).FirstOrDefaultAsync();
            if (site == null)
            {
                return NotFound();
            }
            else
            {
                return site;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Site>> addOneSite(Site site)
        {
            // vérifier les données reçues du navigateur ...
            // ...
            _context.Site.Add(site);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(addOneSite),new { id = site.id}, site);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteSite(int id)
        {
            var site = await _context.Site.FindAsync(id);
            if(site == null)
            {
                return NotFound(nameof(deleteSite));
            }
            _context.Site.Remove(site);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

