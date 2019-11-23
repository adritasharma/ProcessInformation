﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcessInfo.DB.Models;

namespace ProcessInfo.DB.Migrations
{
    [DbContext(typeof(ProcessInfoDbContext))]
    [Migration("20191123162212_application")]
    partial class application
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProcessInfo.DB.Models.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddedByUserId");

                    b.Property<string>("AppPool");

                    b.Property<string>("ApplicationName");

                    b.Property<string>("ApplicationType");

                    b.Property<string>("ConfigFiles");

                    b.Property<string>("Database");

                    b.Property<int>("EnvironmentId");

                    b.Property<string>("IISInstance");

                    b.Property<string>("ProjectName");

                    b.Property<string>("ServerPath");

                    b.Property<string>("SiteUrl");

                    b.Property<string>("Status");

                    b.Property<string>("TeamMembers");

                    b.Property<string>("VersionControlPath");

                    b.Property<int>("WorkObjectName");

                    b.HasKey("ApplicationId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<int?>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.User", b =>
                {
                    b.HasOne("ProcessInfo.DB.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
