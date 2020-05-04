namespace ToDoApi.WebApi.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
