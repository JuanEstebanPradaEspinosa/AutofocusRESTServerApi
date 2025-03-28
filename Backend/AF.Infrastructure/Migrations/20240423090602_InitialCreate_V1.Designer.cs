﻿// <auto-generated />
using System;
using AF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AF.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240423090602_InitialCreate_V1")]
    partial class InitialCreate_V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AF.Infrastructure.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("TenantId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CarPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CarPictures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LessorId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessorId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Lessor", b =>
                {
                    b.HasBaseType("AF.Infrastructure.Entities.User");

                    b.Property<string>("BtwNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Lessor");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Tenant", b =>
                {
                    b.HasBaseType("AF.Infrastructure.Entities.User");

                    b.Property<string>("StudioName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Tenant");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Booking", b =>
                {
                    b.HasOne("AF.Infrastructure.Entities.Car", null)
                        .WithMany("Bookings")
                        .HasForeignKey("CarId");

                    b.HasOne("AF.Infrastructure.Entities.Tenant", null)
                        .WithMany("Bookings")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Car", b =>
                {
                    b.HasOne("AF.Infrastructure.Entities.Lessor", null)
                        .WithMany("Cars")
                        .HasForeignKey("LessorId");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Lessor", b =>
                {
                    b.HasOne("AF.Infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Tenant", b =>
                {
                    b.HasOne("AF.Infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Car", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Lessor", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AF.Infrastructure.Entities.Tenant", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
