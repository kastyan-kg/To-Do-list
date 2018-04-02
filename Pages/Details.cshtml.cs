using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Pages.TaskEntries
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoList.Models.TaskEntryContext _context;

        public DetailsModel(ToDoList.Models.TaskEntryContext context)
        {
            _context = context;
        }

        public TaskEntry TaskEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskEntry = await _context.TaskEntry.SingleOrDefaultAsync(m => m.ID == id);

            if (TaskEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
