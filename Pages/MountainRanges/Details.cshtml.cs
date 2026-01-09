using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.MountainRanges;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public MountainRange MountainRange { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        MountainRange = await _context.MountainRanges
            .Include(m => m.Region)
            .FirstOrDefaultAsync(m => m.MountainRangeId == id);

        if (MountainRange == null)
            return NotFound();

        return Page();
    }
}
