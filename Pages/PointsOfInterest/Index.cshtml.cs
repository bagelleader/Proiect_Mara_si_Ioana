using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.PointsOfInterest;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<PointOfInterest> Points { get; set; } = new List<PointOfInterest>();

    public async Task OnGetAsync()
    {
        Points = await _context.PointsOfInterest
            .AsNoTracking()
            .ToListAsync();
    }
}
