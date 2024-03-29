﻿// <auto-generated />
using System;
using GroupBox.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroupBox.Data.Migrations
{
    [DbContext(typeof(GroupBoxDbContext))]
    [Migration("20190915225837_first to azure db")]
    partial class firsttoazuredb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupBox.Domain.Models.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GroupBox.Domain.Models.Password", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hash");

                    b.Property<string>("Salt");

                    b.HasKey("ID");

                    b.HasIndex("Hash")
                        .IsUnique()
                        .HasFilter("[Hash] IS NOT NULL");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("GroupBox.Domain.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int?>("GroupID");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("GroupBox.Domain.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupID");

                    b.Property<int?>("PasswordID");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("PasswordID");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupBox.Domain.Models.Group", b =>
                {
                    b.HasOne("GroupBox.Domain.Models.User")
                        .WithMany("Groups")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("GroupBox.Domain.Models.Post", b =>
                {
                    b.HasOne("GroupBox.Domain.Models.Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupID");

                    b.HasOne("GroupBox.Domain.Models.User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("GroupBox.Domain.Models.User", b =>
                {
                    b.HasOne("GroupBox.Domain.Models.Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupID");

                    b.HasOne("GroupBox.Domain.Models.Password", "Password")
                        .WithMany()
                        .HasForeignKey("PasswordID");
                });
#pragma warning restore 612, 618
        }
    }
}
