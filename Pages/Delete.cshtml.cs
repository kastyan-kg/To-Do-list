using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Pages.TaskEntries
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoList.Models.TaskEntryContext _context;

        public DeleteModel(ToDoList.Models.TaskEntryContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskEntry = await _context.TaskEntry.FindAsync(id);

            if (TaskEntry != null)
            {
                _context.TaskEntry.Remove(TaskEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
