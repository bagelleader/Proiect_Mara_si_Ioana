using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.Regions
{
    public class DetailsModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public DetailsModel(MuntiRomania.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Region Region { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions.FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }
            else
            {
                Region = region;
            }
            return Page();
        }
    }
}
