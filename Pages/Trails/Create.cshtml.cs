using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuntiRomania.Data;
using MuntiRomania.Models;
using Microsoft.AspNetCore.Authorization;

namespace MuntiRomania.Pages.Trails;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Trail Trail { get; set; } = new();

    public SelectList MountainRangeList { get; set; } = default!;

    public void OnGet()
    {
        MountainRangeList = new SelectList(_context.MountainRanges, "MountainRangeId", "Name");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            MountainRangeList = new SelectList(_context.MountainRanges, "MountainRangeId", "Name");
            return Page();
        }

        _context.Trails.Add(Trail);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
