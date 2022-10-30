﻿// <auto-generated />
using System;
using Adventure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Adventure.Application.Migrations
{
    [DbContext(typeof(AdventureDbContext))]
    partial class AdventureDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Adventure.Domain.DomainModels.AdventureModels.Adventure", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.HasKey("Id");

                    b.ToTable("Adventure", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedBy = "System",
                            IsDeleted = false,
                            Name = "Doughnut Selection",
                            UpdatedAt = new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(1972), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatedBy = "System"
                        });
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.AdventureModels.AdventureSelection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("AdventureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Code")
                        .HasColumnType("tinyint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<byte?>("ParentCode")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(6810), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.ToTable("AdventureSelection", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa351139-3ad6-4794-b71d-9e690692e6d2"),
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)0,
                            Text = "DO I WANT A DOUGHNUT?"
                        },
                        new
                        {
                            Id = new Guid("a9f73734-121c-4ed4-9770-046134be1c96"),
                            Action = "Yes",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)1,
                            ParentCode = (byte)0,
                            Text = "Do I deserve it?"
                        },
                        new
                        {
                            Id = new Guid("4340e385-bbbc-419b-ab08-da0bd2be7c2b"),
                            Action = "No",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)2,
                            ParentCode = (byte)0,
                            Text = "Maybe you want an apple?"
                        },
                        new
                        {
                            Id = new Guid("fc7bb943-73f7-4400-99b0-eafa6fcfa8a9"),
                            Action = "Yes",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)3,
                            ParentCode = (byte)1,
                            Text = "Are you sure?"
                        },
                        new
                        {
                            Id = new Guid("6420f1a5-fa31-4eee-8d5a-9a813699594c"),
                            Action = "No",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)4,
                            ParentCode = (byte)1,
                            Text = "Is it a good doughnut?"
                        },
                        new
                        {
                            Id = new Guid("5297d938-0c1e-4cfd-b243-dfc1763ae463"),
                            Action = "Yes",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)5,
                            ParentCode = (byte)3,
                            Text = "Get it."
                        },
                        new
                        {
                            Id = new Guid("1c35f41f-1fbe-4269-90b3-e6c80ecf8435"),
                            Action = "No",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)6,
                            ParentCode = (byte)3,
                            Text = "Do jumping jacks first."
                        },
                        new
                        {
                            Id = new Guid("0a7d4e14-7289-4602-bcb6-4962b9c84dba"),
                            Action = "Yes",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)7,
                            ParentCode = (byte)4,
                            Text = "What are you waiting for? Grab it now."
                        },
                        new
                        {
                            Id = new Guid("d09f457e-6bfd-45e0-88c9-52088777bcaa"),
                            Action = "No",
                            AdventureId = new Guid("2ae13338-9ba6-431d-a00a-2837acc4fcee"),
                            Code = (byte)8,
                            ParentCode = (byte)4,
                            Text = "Wait 'till you find a sinful unforgettable doughnut."
                        });
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.SelectionModels.UserAdventureSelection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdventureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserAdventureSelection", (string)null);
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.SelectionModels.UserAdventureStepsSelection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdventureSelectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<byte>("Step")
                        .HasColumnType("tinyint");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2022, 10, 30, 15, 50, 1, 929, DateTimeKind.Unspecified).AddTicks(9805), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("System");

                    b.HasKey("Id");

                    b.HasIndex("AdventureSelectionId");

                    b.ToTable("UserAdventureStepsSelection", (string)null);
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.AdventureModels.AdventureSelection", b =>
                {
                    b.HasOne("Adventure.Domain.DomainModels.AdventureModels.Adventure", "Adventure")
                        .WithMany("Choices")
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adventure");
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.SelectionModels.UserAdventureStepsSelection", b =>
                {
                    b.HasOne("Adventure.Domain.DomainModels.SelectionModels.UserAdventureSelection", "AdventureSelection")
                        .WithMany("Steps")
                        .HasForeignKey("AdventureSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdventureSelection");
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.AdventureModels.Adventure", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("Adventure.Domain.DomainModels.SelectionModels.UserAdventureSelection", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}