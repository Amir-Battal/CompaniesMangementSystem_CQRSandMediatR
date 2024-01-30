﻿// <auto-generated />
using System;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231109124551_setReportTable")]
    partial class setReportTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainBranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MainBranchId");

                    b.ToTable("branches");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EstDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Produce", b =>
                {
                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Reportfrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Reportto")
                        .HasColumnType("datetime2");

                    b.HasKey("BranchId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("Reportfrom", "Reportto");

                    b.ToTable("produces", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Report", b =>
                {
                    b.Property<DateTime>("from")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("to")
                        .HasColumnType("datetime2");

                    b.Property<int>("branchId")
                        .HasColumnType("int");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.HasKey("from", "to");

                    b.ToTable("reports", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Supply", b =>
                {
                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SProductQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("SuppliedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("fromBranch")
                        .HasColumnType("int");

                    b.HasKey("BranchId", "ProductId");

                    b.ToTable("supplys", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Branch", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.Branch", "MainBranch")
                        .WithMany()
                        .HasForeignKey("MainBranchId");

                    b.Navigation("Company");

                    b.Navigation("MainBranch");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Produce", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.Report", null)
                        .WithMany("produces")
                        .HasForeignKey("Reportfrom", "Reportto");

                    b.Navigation("Branch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Report", b =>
                {
                    b.Navigation("produces");
                });
#pragma warning restore 612, 618
        }
    }
}