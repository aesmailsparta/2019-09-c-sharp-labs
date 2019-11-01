namespace lab_49_MVC_Core_Todo
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoItemModel : DbContext
    {
        public ToDoItemModel(DbContextOptions<ToDoItemModel> options):base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=ToDoItemsDatabase;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .Property(e => e.Item)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(t => t.ToDoItems)
                .WithOne(c => c.Category);

            modelBuilder.Entity<Category>().Property(c => c.CategoryName).IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(t => t.ToDoItems)
                .WithOne(u => u.User);

            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();

            modelBuilder.Entity<ToDoItem>()
                .HasOne(c => c.Category)
                .WithMany(t => t.ToDoItems);

            modelBuilder.Entity<ToDoItem>()
                .HasOne(u => u.User)
                .WithMany(t => t.ToDoItems);

            modelBuilder.Entity<ToDoItem>().Property(t => t.Item).IsRequired();
        }
    }
}
