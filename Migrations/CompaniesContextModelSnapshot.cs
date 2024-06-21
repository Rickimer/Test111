﻿// <auto-generated />
using Companies_example1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Test1.Migrations
{
    [DbContext(typeof(CompaniesContext))]
    partial class CompaniesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Companies_example1.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BinarySign")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            BinarySign = false,
                            Name = "Company1"
                        },
                        new
                        {
                            Id = -2,
                            BinarySign = false,
                            Name = "Company2"
                        },
                        new
                        {
                            Id = -3,
                            BinarySign = true,
                            Name = "Company3"
                        },
                        new
                        {
                            Id = -4,
                            BinarySign = true,
                            Name = "Company4"
                        },
                        new
                        {
                            Id = -5,
                            BinarySign = true,
                            Name = "Company5"
                        });
                });

            modelBuilder.Entity("Companies_example1.Model.CompanyBranches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompaniesBranches");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CompanyId = -1,
                            Name = "C1_B1"
                        },
                        new
                        {
                            Id = -2,
                            CompanyId = -1,
                            Name = "C1_B2"
                        },
                        new
                        {
                            Id = -3,
                            CompanyId = -2,
                            Name = "C2_B1"
                        },
                        new
                        {
                            Id = -4,
                            CompanyId = -3,
                            Name = "C3_B1"
                        },
                        new
                        {
                            Id = -5,
                            CompanyId = -3,
                            Name = "C3_B2"
                        },
                        new
                        {
                            Id = -6,
                            CompanyId = -3,
                            Name = "C3_B3"
                        },
                        new
                        {
                            Id = -7,
                            CompanyId = -3,
                            Name = "C3_B4"
                        },
                        new
                        {
                            Id = -8,
                            CompanyId = -5,
                            Name = "C5_B1"
                        });
                });

            modelBuilder.Entity("Companies_example1.Model.CompanyBranches", b =>
                {
                    b.HasOne("Companies_example1.Model.Company", "Company")
                        .WithMany("CompaniesBranches")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Companies_example1.Model.Company", b =>
                {
                    b.Navigation("CompaniesBranches");
                });
#pragma warning restore 612, 618
        }
    }
}