﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_42_ef_core_from_scratch;

namespace lab_42_ef_core_from_scratch.Migrations
{
    [DbContext(typeof(ToDoItemContext))]
    partial class ToDoItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab_42_ef_core_from_scratch.ToDoItem", b =>
                {
                    b.Property<int>("ToDoItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("ToDoItemName");

                    b.HasKey("ToDoItemId");

                    b.ToTable("ToDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
