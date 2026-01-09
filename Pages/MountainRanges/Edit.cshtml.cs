using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.MountainRanges;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MountainRange MountainRange { get; set; } = new();

    public SelectList RegionList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        MountainRange = await _context.MountainRanges.FindAsync(id);
        if (MountainRange == null) return NotFound();

        RegionList = new SelectList(_context.Regions, "RegionId", "Name", MountainRange.RegionId);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            RegionList = new SelectList(_context.Regions, "RegionId", "Name", MountainRange.RegionId);
            return Page();
        }

        _context.Attach(MountainRange).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
