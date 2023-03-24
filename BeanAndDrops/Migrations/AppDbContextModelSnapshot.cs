﻿// <auto-generated />
using System;
using BeanAndDrops.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeanAndDrops.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeanAndDrops.Models.Entities.Category", b =>
                {
                    b.Property<string>("Category_Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Category_Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Category_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Category_Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("BeanAndDrops.Models.Entities.Product", b =>
                {
                    b.Property<string>("Product_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Category_Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Product_Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Product_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Product_Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Product_Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Product_Price")
                        .HasColumnType("int");

                    b.Property<int>("Product_Size")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("longtext");

                    b.HasKey("Product_id");

                    b.HasIndex("Category_Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("BeanAndDrops.Models.Entities.Product", b =>
                {
                    b.HasOne("BeanAndDrops.Models.Entities.Category", "category")
                        .WithMany()
                        .HasForeignKey("Category_Id");

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
