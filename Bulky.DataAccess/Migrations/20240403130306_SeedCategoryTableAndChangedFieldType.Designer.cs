﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
  [DbContext(typeof(ApplicationDbContext))]
  [Migration("20240403130306_SeedCategoryTableAndChangedFieldType")]
  partial class SeedCategoryTableAndChangedFieldType
  {
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "8.0.3")
          .HasAnnotation("Relational:MaxIdentifierLength", 128);

      SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

      modelBuilder.Entity("BulkyWeb.Category", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<int>("DisplayOrder")
                      .HasColumnType("int");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Categories");

            b.HasData(
                      new
                      {
                        Id = 1,
                        DisplayOrder = 1,
                        Name = "Action"
                      },
                      new
                      {
                        Id = 2,
                        DisplayOrder = 2,
                        Name = "Scifi"
                      },
                      new
                      {
                        Id = 3,
                        DisplayOrder = 3,
                        Name = "History"
                      });
          });
#pragma warning restore 612, 618
    }
  }
}
