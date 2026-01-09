using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.MountainRanges;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MountainRange> MountainRange { get; set; } = new List<MountainRange>();

    public async Task OnGetAsync()
    {
        MountainRange = await _context.MountainRanges
            .AsNoTracking()
            .Include(m => m.Region)
            .ToListAsync();
    }
}
