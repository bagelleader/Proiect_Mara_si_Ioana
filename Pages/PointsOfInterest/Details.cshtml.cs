using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.PointsOfInterest;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public PointOfInterest Point { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Point = await _context.PointsOfInterest.FindAsync(id);
        if (Point == null) return NotFound();
        return Page();
    }
}
