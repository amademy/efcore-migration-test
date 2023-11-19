﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace efcore_migration_test.Migrations
{
	[DbContext(typeof(AppDbContext))]
	partial class AppDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.0")
				.HasAnnotation("Relational:MaxIdentifierLength", 63);

			NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "product_trait", new[] { "foo", "bar", "buzz" });
			NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

			modelBuilder.Entity("Product", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("integer");

					NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

					b.Property<List<ProductTrait>>("Traits")
						.IsRequired()
						.HasColumnType("product_trait[]");

					b.HasKey("Id");

					b.ToTable("Products");
				});
#pragma warning restore 612, 618
		}
	}
}
