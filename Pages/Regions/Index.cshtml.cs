using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Data;
using MuntiRomania.Models;

namespace MuntiRomania.Pages.Regions
{
    public class IndexModel : PageModel
    {
        private readonly MuntiRomania.Data.ApplicationDbContext _context;

        public IndexModel(MuntiRomania.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Region> Region { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Region = await _context.Regions.ToListAsync();
        }
    }
}
