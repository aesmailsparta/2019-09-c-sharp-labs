﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_48_api_todo;

namespace lab_48_api_todo.Migrations
{
    [DbContext(typeof(TaskItemContext))]
    partial class TaskItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("lab_48_api_todo.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new { CategoryID = 1, CategoryName = "Holiday Packing", Description = "Items to pack for my holiday" },
                        new { CategoryID = 2, CategoryName = "Daily Tasks", Description = "List of to do items for today" },
                        new { CategoryID = 3, CategoryName = "Thoughts", Description = "List of my thoughts to create" }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo.TaskItem", b =>
                {
                    b.Property<int>("TaskItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime>("DateDue");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("TaskDone");

                    b.Property<int?>("UserID");

                    b.HasKey("TaskItemID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new { TaskItemID = 1, CategoryID = 1, DateDue = new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "My First Task", TaskDone = false, UserID = 1 },
                        new { TaskItemID = 2, CategoryID = 1, DateDue = new DateTime(2019, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "My Second Task", TaskDone = false, UserID = 1 },
                        new { TaskItemID = 3, CategoryID = 2, DateDue = new DateTime(2019, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "My Third Task", TaskDone = false, UserID = 1 },
                        new { TaskItemID = 4, CategoryID = 2, DateDue = new DateTime(2019, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "My Fourth Task", TaskDone = false, UserID = 1 },
                        new { TaskItemID = 5, CategoryID = 3, DateDue = new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "My Fifth Task", TaskDone = false, UserID = 1 }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Username");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserID = 1, Name = "SpartaBoy", Username = "Spartan" },
                        new { UserID = 2, Name = "Terrance", Username = "Trainee" }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo.TaskItem", b =>
                {
                    b.HasOne("lab_48_api_todo.Category", "Category")
                        .WithMany("TaskItems")
                        .HasForeignKey("CategoryID");

                    b.HasOne("lab_48_api_todo.User", "User")
                        .WithMany("TaskItems")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
