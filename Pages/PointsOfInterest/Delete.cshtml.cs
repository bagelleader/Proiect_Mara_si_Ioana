using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.PointsOfInterest;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PointOfInterest Point { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Point = await _context.PointsOfInterest.FindAsync(id);
        if (Point == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var entity = await _context.PointsOfInterest.FindAsync(Point.PointOfInterestId);
        if (entity != null)
        {
            _context.PointsOfInterest.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}
