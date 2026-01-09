using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.Trails;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Trail> Trails { get; set; } = new List<Trail>();

    public async Task OnGetAsync()
    {
        Trails = await _context.Trails
            .AsNoTracking()
            .Include(t => t.MountainRange)
            .ToListAsync();
    }
}
