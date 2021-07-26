﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPages;

namespace RazorPages.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RazorPages.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("RazorPages.Entities.User", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("UserName");

                    b.Property<int>("BCredit")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InviteCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvitedByName")
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("CreateTime")
                        .IsUnique();

                    b.HasIndex("InvitedByName");

                    b.ToTable("Register");

                    b.HasCheckConstraint("Ck_CreateTime", "CreateTime>=2020/1/1");
                });

            modelBuilder.Entity("RazorPages.Entities.User", b =>
                {
                    b.HasOne("RazorPages.Entities.User", "InvitedBy")
                        .WithMany()
                        .HasForeignKey("InvitedByName");

                    b.Navigation("InvitedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
