﻿// <auto-generated />
using System;
using FiestaMarketBackend.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FiestaMarketBackend.Infrastructure.Migrations
{
    [DbContext(typeof(FiestaDbContext))]
    [Migration("20240323192209_ChangedNavigationProdFavor")]
    partial class ChangedNavigationProdFavor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FavoriteProduct", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("favoritesId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductsId", "favoritesId");

                    b.HasIndex("favoritesId");

                    b.ToTable("FavoriteProduct");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

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

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Favorite");
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

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
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

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FavoriteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("FavoriteId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FavoriteProduct", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiestaMarketBackend.Core.Entities.Favorite", null)
                        .WithMany()
                        .HasForeignKey("favoritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Cart", b =>
                {
                    b.OwnsMany("FiestaMarketBackend.Core.Entities.CartItem", "Items", b1 =>
                        {
                            b1.Property<Guid>("CartId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Quantity")
                                .HasColumnType("integer");

                            b1.HasKey("CartId", "Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("CartItem");

                            b1.WithOwner()
                                .HasForeignKey("CartId");

                            b1.HasOne("FiestaMarketBackend.Core.Entities.Product", "Product")
                                .WithMany()
                                .HasForeignKey("ProductId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Product");
                        });

                    b.Navigation("Items");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Catalog", b =>
                {
                    b.OwnsMany("FiestaMarketBackend.Core.Entities.Image", "Images", b1 =>
                        {
                            b1.Property<Guid>("CatalogId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("CatalogId", "Id");

                            b1.ToTable("Catalogs_Images");

                            b1.WithOwner()
                                .HasForeignKey("CatalogId");
                        });

                    b.Navigation("Images");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Category", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Order", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FiestaMarketBackend.Core.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("ContactPerson")
                                .HasColumnType("text");

                            b1.Property<string>("DeliveryAddress")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Details")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsMany("FiestaMarketBackend.Core.Entities.OrderItem", "Items", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Quantity")
                                .HasColumnType("integer");

                            b1.HasKey("OrderId", "Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.HasOne("FiestaMarketBackend.Core.Entities.Product", "Product")
                                .WithMany()
                                .HasForeignKey("ProductId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Product");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Product", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.OwnsMany("FiestaMarketBackend.Core.Entities.Image", "Images", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Products_Images");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("FiestaMarketBackend.Core.Entities.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Games")
                                .HasColumnType("text");

                            b1.Property<string>("Material")
                                .HasColumnType("text");

                            b1.Property<string>("Size")
                                .HasColumnType("text");

                            b1.Property<string>("Text")
                                .HasColumnType("text");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Category");

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Images");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.User", b =>
                {
                    b.HasOne("FiestaMarketBackend.Core.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("FiestaMarketBackend.Core.Entities.Favorite", "Favorite")
                        .WithMany()
                        .HasForeignKey("FavoriteId");

                    b.OwnsMany("FiestaMarketBackend.Core.Entities.Address", "Addresses", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("ContactPerson")
                                .HasColumnType("text");

                            b1.Property<string>("DeliveryAddress")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Details")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("Users_Addresses");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Cart");

                    b.Navigation("Favorite");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("FiestaMarketBackend.Core.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
