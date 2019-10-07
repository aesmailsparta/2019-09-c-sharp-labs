using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;


namespace lab_42_ef_core_from_scratch
{
    class Program
    {
        static List<ToDoItem> items = new List<ToDoItem>();
        static void Main(string[] args)
        {
            using (var db = new ToDoItemContext())
            {
                var todo = new ToDoItem()
                {
                    ToDoItemName = "first task",
                    DateCreated = DateTime.Now
                };

                db.ToDoItems.Add(todo);
                db.SaveChanges();
            }

            using(var db = new ToDoItemContext())
            {
                items = db.ToDoItems.ToList();
            }

            items.ForEach(i => Console.WriteLine($"{i.ToDoItemId, -10}{i.ToDoItemName, -15}{i.DateCreated.ToShortDateString()}"));
        }
    }

    public class ToDoItem
    {
        public int ToDoItemId { get; set; }

        public string ToDoItemName { get; set; }

        public DateTime DateCreated { get; set; }
    }

    public class ToDoItemContext : DbContext
    {

        public ToDoItemContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=ToDoDatabase.db;");
            //builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ToDoDatabase;Integrated Security=true;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }

    }
}