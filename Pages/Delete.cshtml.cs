using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public DeleteModel(MuntiRomania.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MountainRange MountainRange { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mountainrange = await _context.MountainRanges.FirstOrDefaultAsync(m => m.MountainRangeId == id);

            if (mountainrange == null)
            {
                return NotFound();
            }
            else
            {
                MountainRange = mountainrange;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mountainrange = await _context.MountainRanges.FindAsync(id);
            if (mountainrange != null)
            {
                MountainRange = mountainrange;
                _context.MountainRanges.Remove(MountainRange);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
