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
    public class DeleteModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public DeleteModel(MuntiRomania.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions.FindAsync(id);
            if (region != null)
            {
                Region = region;
                _context.Regions.Remove(Region);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
