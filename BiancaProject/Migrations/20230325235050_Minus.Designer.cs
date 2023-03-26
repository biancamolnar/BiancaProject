﻿// <auto-generated />
using System;
using BiancaProject.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiancaProject.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230325235050_Minus")]
    partial class Minus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BiancaProject.Models.Entities.CaseEntity", b =>
                {
                    b.Property<string>("CaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeWritten")
                        .HasColumnType("datetime2");

                    b.HasKey("CaseId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TenantId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.CommentEntity", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CaseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeWritten")
                        .HasColumnType("datetime2");

                    b.HasKey("CommentId");

                    b.HasIndex("CaseId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.StatusEntity", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.TenantEntity", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.CaseEntity", b =>
                {
                    b.HasOne("BiancaProject.Models.Entities.StatusEntity", "Status")
                        .WithMany("Cases")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiancaProject.Models.Entities.TenantEntity", "Tenant")
                        .WithMany("Cases")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.CommentEntity", b =>
                {
                    b.HasOne("BiancaProject.Models.Entities.CaseEntity", "Case")
                        .WithMany("Commments")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.CaseEntity", b =>
                {
                    b.Navigation("Commments");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.StatusEntity", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("BiancaProject.Models.Entities.TenantEntity", b =>
                {
                    b.Navigation("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
