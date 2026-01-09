using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public CreateModel(MuntiRomania.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Name");
            return Page();
        }

        [BindProperty]
        public MountainRange MountainRange { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MountainRanges.Add(MountainRange);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
