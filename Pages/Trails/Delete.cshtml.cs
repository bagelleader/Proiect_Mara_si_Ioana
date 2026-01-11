using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;
using Microsoft.AspNetCore.Authorization;

namespace MuntiRomania.Pages.Trails;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Trail Trail { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Trail = await _context.Trails
            .Include(t => t.MountainRange)
            .FirstOrDefaultAsync(t => t.TrailId == id);

        if (Trail == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var entity = await _context.Trails.FindAsync(Trail.TrailId);
        if (entity != null)
        {
            _context.Trails.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}
