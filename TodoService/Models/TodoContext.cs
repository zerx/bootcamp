using EntityFramework.DynamicFilters;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TodoService.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base("TodoContext")
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TodoContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Filter("Deleted", (Todo t) => t.Deleted, false);
        }
    }
}