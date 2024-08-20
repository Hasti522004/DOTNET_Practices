﻿// <auto-generated />
using System;
using Entity_Framework_Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity_Framework_Demo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240820123601_adddatainlanguage2")]
    partial class adddatainlanguage2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity_Framework_Demo.Data.BookPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BooksId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("BookPrices");
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Indian INR",
                            Title = "INR"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Doller",
                            Title = "Doller"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Euro",
                            Title = "Euro"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Dinar",
                            Title = "Dinar"
                        });
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Mumbai",
                            Title = "Hindi"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Gujrat",
                            Title = "Gujrati"
                        },
                        new
                        {
                            Id = 3,
                            Description = "USA",
                            Title = "English"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Tamilnadu",
                            Title = "Tamil"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Iran",
                            Title = "Urdu"
                        });
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.BookPrice", b =>
                {
                    b.HasOne("Entity_Framework_Demo.Data.Books", "Books")
                        .WithMany("BookPrices")
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity_Framework_Demo.Data.Currency", "Currency")
                        .WithMany("BookPrices")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Books", b =>
                {
                    b.HasOne("Entity_Framework_Demo.Data.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Books", b =>
                {
                    b.Navigation("BookPrices");
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Currency", b =>
                {
                    b.Navigation("BookPrices");
                });

            modelBuilder.Entity("Entity_Framework_Demo.Data.Language", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
