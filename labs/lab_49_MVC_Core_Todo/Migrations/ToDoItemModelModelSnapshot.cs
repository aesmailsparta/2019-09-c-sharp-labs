﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_49_MVC_Core_Todo;

namespace lab_49_MVC_Core_Todo.Migrations
{
    [DbContext(typeof(ToDoItemModel))]
    partial class ToDoItemModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab_49_MVC_Core_Todo.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("lab_49_MVC_Core_Todo.ToDoItem", b =>
                {
                    b.Property<int>("ToDoItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime?>("DateDue")
                        .HasColumnType("date");

                    b.Property<bool?>("Done");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("UserID");

                    b.HasKey("ToDoItemID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("lab_49_MVC_Core_Todo.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastLoggedIn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("lab_49_MVC_Core_Todo.ToDoItem", b =>
                {
                    b.HasOne("lab_49_MVC_Core_Todo.Category", "Category")
                        .WithMany("ToDoItems")
                        .HasForeignKey("CategoryID");

                    b.HasOne("lab_49_MVC_Core_Todo.User", "User")
                        .WithMany("ToDoItems")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
