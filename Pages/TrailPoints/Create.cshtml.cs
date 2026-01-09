using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.TrailPoints;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TrailPoint TrailPoint { get; set; } = new();

    public SelectList TrailList { get; set; } = default!;
    public SelectList PointList { get; set; } = default!;

    public void OnGet()
    {
        TrailList = new SelectList(_context.Trails, "TrailId", "Name");
        PointList = new SelectList(_context.PointsOfInterest, "PointOfInterestId", "Name");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            TrailList = new SelectList(_context.Trails, "TrailId", "Name");
            PointList = new SelectList(_context.PointsOfInterest, "PointOfInterestId", "Name");
            return Page();
        }

        _context.TrailPoints.Add(TrailPoint);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}
