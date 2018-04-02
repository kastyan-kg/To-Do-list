using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ToDoList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaskEntryContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaskEntryContext>>()))
            {
                // Look for any task
                if (context.TaskEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.TaskEntry.AddRange(
                    new TaskEntry
                    {
                        Name = "Start assigment",
                        Description = "Start little pet project using .Net",
                        Deadline = DateTime.Parse("2018-2-12"),
                        IsFinished = false
                    },

                    new TaskEntry
                    {
                        Name = "Personal Task Tracker",
                        Description = "Get a visual picture of your scheduled tasks with this Gantt chart template. Often used in project management.",
                        Deadline = DateTime.Parse("2019-2-12"),
                        IsFinished = false
                    },

                    new TaskEntry
                    {
                        Name = "Daily Task List",
                        Description = "With this daily task list template you can schedule tasks throughout the day while also planning ahead for an entire week.",
                        Deadline = DateTime.Parse("2018-2-12"),
                        IsFinished = true
                    },

                    new TaskEntry
                    {
                        Name = "Weekly Task List",
                        Description = "This weekly task list schedule includes columns for assigning a category to each task, along with deadlines and completion status.",
                        Deadline = DateTime.Parse("2018-8-12"),
                        IsFinished = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}