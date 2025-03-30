﻿// <auto-generated />
using System;
using DbController;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbController.Migrations
{
    [DbContext(typeof(Db_Controller))]
    [Migration("20250328145632_FullCreate")]
    partial class FullCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbController.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Tolkien"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Joanne",
                            LastName = "Rowling"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "George",
                            LastName = "Martin"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "J.R.R.",
                            LastName = "Martin"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "J.K.",
                            LastName = "Rowling"
                        });
                });

            modelBuilder.Entity("DbController.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CostPrice")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsItASequel")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("PublishingHouseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SellingPrice")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TrilogiesId")
                        .HasColumnType("int");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TrilogiesId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CostPrice = 10,
                            Genre = "Fantasy",
                            IsItASequel = true,
                            NumberOfPages = 1178,
                            PublishingHouseName = "Allen & Unwin",
                            SellingPrice = 20,
                            Title = "The Lord of the Rings",
                            TrilogiesId = 1,
                            YearOfPublication = 1954
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CostPrice = 7,
                            Genre = "Fantasy",
                            IsItASequel = false,
                            NumberOfPages = 310,
                            PublishingHouseName = "Allen & Unwin",
                            SellingPrice = 15,
                            Title = "The Hobbit",
                            TrilogiesId = 1,
                            YearOfPublication = 1937
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            CostPrice = 12,
                            Genre = "Fantasy",
                            IsItASequel = true,
                            NumberOfPages = 365,
                            PublishingHouseName = "Allen & Unwin",
                            SellingPrice = 25,
                            Title = "The Silmarillion",
                            TrilogiesId = 1,
                            YearOfPublication = 1977
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            CostPrice = 9,
                            Genre = "Fantasy",
                            IsItASequel = false,
                            NumberOfPages = 223,
                            PublishingHouseName = "Bloomsbury",
                            SellingPrice = 18,
                            Title = "Harry Potter and the Philosopher's Stone",
                            TrilogiesId = 2,
                            YearOfPublication = 1997
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            CostPrice = 10,
                            Genre = "Fantasy",
                            IsItASequel = true,
                            NumberOfPages = 251,
                            PublishingHouseName = "Bloomsbury",
                            SellingPrice = 20,
                            Title = "Harry Potter and the Chamber of Secrets",
                            TrilogiesId = 2,
                            YearOfPublication = 1998
                        });
                });

            modelBuilder.Entity("DbController.Entities.BookPostponed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookPostponed");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 3,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("DbController.Entities.SalesArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("SellingPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("SalesArchives");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            BookId = 1,
                            DateOfSale = new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPrice = 20,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            BookId = 4,
                            DateOfSale = new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPrice = 15,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            BookId = 2,
                            DateOfSale = new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPrice = 25,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            BookId = 4,
                            DateOfSale = new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPrice = 18,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            BookId = 5,
                            DateOfSale = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPrice = 20,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("DbController.Entities.Trilogies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameTrilogie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Trilogies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameTrilogie = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            NameTrilogie = "Harry Potter"
                        },
                        new
                        {
                            Id = 3,
                            NameTrilogie = "A Song of Ice and Fire"
                        },
                        new
                        {
                            Id = 4,
                            NameTrilogie = "The Chronicles of Narnia"
                        },
                        new
                        {
                            Id = 5,
                            NameTrilogie = "The Hunger Games"
                        });
                });

            modelBuilder.Entity("DbController.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Money = 100,
                            Password = "Password 1",
                            UserName = "UserName 1"
                        },
                        new
                        {
                            Id = 2,
                            Money = 120,
                            Password = "Password 2",
                            UserName = "UserName 2"
                        },
                        new
                        {
                            Id = 3,
                            Money = 70,
                            Password = "Password 3",
                            UserName = "UserName 3"
                        },
                        new
                        {
                            Id = 4,
                            Money = 50,
                            Password = "Password 4",
                            UserName = "UserName 4"
                        },
                        new
                        {
                            Id = 5,
                            Money = 80,
                            Password = "Password 5",
                            UserName = "UserName 5"
                        });
                });

            modelBuilder.Entity("DbController.Entities.Book", b =>
                {
                    b.HasOne("DbController.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DbController.Entities.Trilogies", "Trilogies")
                        .WithMany("Books")
                        .HasForeignKey("TrilogiesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Author");

                    b.Navigation("Trilogies");
                });

            modelBuilder.Entity("DbController.Entities.BookPostponed", b =>
                {
                    b.HasOne("DbController.Entities.Book", "Book")
                        .WithMany("BookPostponed")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbController.Entities.User", "User")
                        .WithMany("BookPostponeds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbController.Entities.SalesArchive", b =>
                {
                    b.HasOne("DbController.Entities.Author", "Author")
                        .WithMany("SalesArchives")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbController.Entities.Book", "Book")
                        .WithMany("SalesArchives")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbController.Entities.User", "User")
                        .WithMany("SalesArchives")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbController.Entities.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("SalesArchives");
                });

            modelBuilder.Entity("DbController.Entities.Book", b =>
                {
                    b.Navigation("BookPostponed");

                    b.Navigation("SalesArchives");
                });

            modelBuilder.Entity("DbController.Entities.Trilogies", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DbController.Entities.User", b =>
                {
                    b.Navigation("BookPostponeds");

                    b.Navigation("SalesArchives");
                });
#pragma warning restore 612, 618
        }
    }
}
