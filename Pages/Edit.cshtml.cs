using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages
{
    public class EditModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public EditModel(MuntiRomania.Data.ApplicationDbContext context)
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

            var mountainrange =  await _context.MountainRanges.FirstOrDefaultAsync(m => m.MountainRangeId == id);
            if (mountainrange == null)
            {
                return NotFound();
            }
            MountainRange = mountainrange;
           ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MountainRange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MountainRangeExists(MountainRange.MountainRangeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MountainRangeExists(int id)
        {
            return _context.MountainRanges.Any(e => e.MountainRangeId == id);
        }
    }
}
