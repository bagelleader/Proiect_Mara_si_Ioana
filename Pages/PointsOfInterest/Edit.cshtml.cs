using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;
using Microsoft.AspNetCore.Authorization;

namespace MuntiRomania.Pages.PointsOfInterest;

[Authorize]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        if (!ModelState.IsValid)
            return Page();

        _context.Attach(Point).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
