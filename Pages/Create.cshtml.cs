
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Models;

namespace ToDoList.Pages.TaskEntries
{
    public class CreateModel : PageModel
    {
        private readonly ToDoList.Models.TaskEntryContext _context;

        public CreateModel(ToDoList.Models.TaskEntryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskEntry TaskEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskEntry.Add(TaskEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}