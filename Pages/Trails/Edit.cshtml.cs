using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.Trails;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Trail Trail { get; set; } = new();

    public SelectList MountainRangeList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Trail = await _context.Trails.FindAsync(id);
        if (Trail == null) return NotFound();

        MountainRangeList = new SelectList(_context.MountainRanges, "MountainRangeId", "Name", Trail.MountainRangeId);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            MountainRangeList = new SelectList(_context.MountainRanges, "MountainRangeId", "Name", Trail.MountainRangeId);
            return Page();
        }

        _context.Attach(Trail).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
