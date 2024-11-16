﻿// <auto-generated />
using System;
using CropMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CropMS.Migrations
{
    [DbContext(typeof(CropDbContext))]
    partial class CropDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CropMS.Models.Farmer", b =>
                {
                    b.Property<Guid>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("CertifyAsOrganicFarmer")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FarmLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PesticideUsage")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProduceExpected")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmId");

                    b.ToTable("Farmers");
                });
#pragma warning restore 612, 618
        }
    }
}
