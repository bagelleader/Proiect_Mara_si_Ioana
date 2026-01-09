using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.MountainRanges;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MountainRange MountainRange { get; set; } = new();

    public SelectList RegionList { get; set; } = default!;

    public void OnGet()
    {
        RegionList = new SelectList(_context.Regions, "RegionId", "Name");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            RegionList = new SelectList(_context.Regions, "RegionId", "Name");
            return Page();
        }

        _context.MountainRanges.Add(MountainRange);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
