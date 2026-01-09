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
    public class DetailsModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public DetailsModel(MuntiRomania.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
