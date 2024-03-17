﻿// <auto-generated />
using System;
using FiestaMarketBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FiestaMarketBackend.Infrastructure.Migrations
{
    [DbContext(typeof(FiestaDbContext))]
    [Migration("20240317130529_UpdatedEntites")]
    partial class UpdatedEntites
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CatalogId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionMarkDown")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DescriptionId")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MinQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<bool>("Recommended")
                        .HasColumnType("boolean");

                    b.Property<bool>("Relevant")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.ProductDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Games")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductDescription");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Category", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Image", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Catalog", "Catalog")
                        .WithMany("Images")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiestaMarketBackend.Core.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Product", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("FiestaMarketBackend.Core.Entities.ProductDescription", "Description")
                        .WithOne("Product")
                        .HasForeignKey("FiestaMarketBackend.Core.Entities.Product", "DescriptionId");

                    b.Navigation("Category");

                    b.Navigation("Description");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Catalog", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Product", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.ProductDescription", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
