using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.MountainRanges;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MountainRange MountainRange { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        MountainRange = await _context.MountainRanges
            .Include(m => m.Region)
            .FirstOrDefaultAsync(m => m.MountainRangeId == id);

        if (MountainRange == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var entity = await _context.MountainRanges.FindAsync(MountainRange.MountainRangeId);
        if (entity != null)
        {
            _context.MountainRanges.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}
