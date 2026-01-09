using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.Trails;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Trail Trail { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Trail = await _context.Trails
            .Include(t => t.MountainRange)
            .FirstOrDefaultAsync(t => t.TrailId == id);

        if (Trail == null) return NotFound();
        return Page();
    }
}
