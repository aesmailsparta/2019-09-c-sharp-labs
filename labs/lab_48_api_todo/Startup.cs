using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_48_api_todo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskItemContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class TaskItem
    {
        public int TaskItemID { get; set; }

        [Required]
        public string Description { get; set; }

        public bool TaskDone { get; set; }

        [Display(Name = "Date Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDue { get; set; }

        
        public int? UserID { get; set; }

        public int? CategoryID { get; set; }

        [ForeignKey ("UserID")]
        public virtual User User { get; set; }


        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

    }   
    
    public class User
    {
        //public User()
        //{
        //    TaskItems = new HashSet<TaskItem>();
        //}
        //[NotMapped]
        //public virtual ICollection<TaskItem> TaskItems { get; set; }

        public int UserID { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }


    }

    public class Category
    {
        //public Category()
        //{
        //    TaskItems = new HashSet<TaskItem>();
        //}
        //[NotMapped]
        //public virtual ICollection<TaskItem> TaskItems { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

    }

    public class TaskItemContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TaskItemContext(){
            Trace.WriteLine("test data");
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            builder.UseSqlite(@"Data Source=ToDoDatabase.db;");
            //builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=TaskDatabase;Integrated Security=true;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<TaskItem>()
            //    .HasOne(t => t.User)
            //    .WithMany(u => u.TaskItems);

            //builder.Entity<User>()
            //    .HasMany(u => u.TaskItems)
            //    .WithOne(t => t.User);

            //builder.Entity<TaskItem>()
            //    .HasOne(t => t.Category)
            //    .WithMany(c => c.TaskItems);

            //builder.Entity<Category>()
            //    .HasMany(c => c.TaskItems)
            //    .WithOne(t => t.Category);


            builder.Entity<User>().HasData(
                   new User { UserID = 1, Username = "Spartan", Name="SpartaBoy"},
                   new User { UserID = 2, Username = "Trainee", Name="Terrance"}
             );

            builder.Entity<Category>().HasData(
                   new Category { CategoryID = 1, CategoryName = "Holiday Packing", Description = "Items to pack for my holiday" },
                   new Category { CategoryID = 2, CategoryName = "Daily Tasks", Description = "List of to do items for today" },
                   new Category { CategoryID = 3, CategoryName = "Thoughts", Description = "List of my thoughts to create" }
             );

            builder.Entity<TaskItem>().HasData(
                   new TaskItem { TaskItemID = 1, Description = "My First Task", DateDue = DateTime.Parse("2019-05-02"), UserID = 1, CategoryID = 1},
                   new TaskItem { TaskItemID = 2, Description = "My Second Task", DateDue = DateTime.Parse("2019-02-07"), UserID = 1, CategoryID = 1},
                   new TaskItem { TaskItemID = 3, Description = "My Third Task", DateDue = DateTime.Parse("2019-03-06"), UserID = 1, CategoryID = 2},
                   new TaskItem { TaskItemID = 4, Description = "My Fourth Task", DateDue = DateTime.Parse("2019-03-06"), UserID = 1, CategoryID = 2},
                   new TaskItem { TaskItemID = 5, Description = "My Fifth Task", DateDue = DateTime.Parse("2019-01-09"), UserID = 1, CategoryID = 3}
             );

        }

    }
}
