using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.PointsOfInterest;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PointOfInterest Point { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.PointsOfInterest.Add(Point);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
