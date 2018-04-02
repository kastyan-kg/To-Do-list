using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Pages.TaskEntries
{
    public class IndexModel : PageModel
    {
        private readonly ToDoList.Models.TaskEntryContext _context;

        public IndexModel(ToDoList.Models.TaskEntryContext context)
        {
            _context = context;
        }

        public IList<TaskEntry> TaskEntry { get;set; }

        public async Task OnGetAsync()
        {
            TaskEntry = await _context.TaskEntry.ToListAsync();
        }
    }
}
