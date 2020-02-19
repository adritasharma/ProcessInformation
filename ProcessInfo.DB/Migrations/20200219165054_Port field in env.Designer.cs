﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcessInfo.DB.Models;

namespace ProcessInfo.DB.Migrations
{
    [DbContext(typeof(ProcessInfoDbContext))]
    [Migration("20200219165054_Port field in env")]
    partial class Portfieldinenv
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProcessInfo.DB.Models.Application", b =>
                {
                    b.Property<Guid>("ApplicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationName");

                    b.Property<string>("ApplicationType");

                    b.Property<string>("ProjectName");

                    b.Property<string>("Status");

                    b.Property<string>("TeamMembers");

                    b.Property<int>("WorkObjectName");

                    b.HasKey("ApplicationId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.ApplicationEnvironment", b =>
                {
                    b.Property<Guid>("ApplicationEnvironmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppPool");

                    b.Property<Guid>("ApplicationId");

                    b.Property<string>("ConfigFiles");

                    b.Property<string>("Database");

                    b.Property<Guid>("EnvironmentId");

                    b.Property<string>("IISInstance");

                    b.Property<string>("Port");

                    b.Property<string>("ServerPath");

                    b.Property<string>("SiteUrl");

                    b.Property<string>("VersionControlPath");

                    b.HasKey("ApplicationEnvironmentId");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("EnvironmentId");

                    b.ToTable("ApplicationEnvironment");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.Environment", b =>
                {
                    b.Property<Guid>("EnvironmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EnvironmentDescription");

                    b.Property<string>("EnvironmentName");

                    b.HasKey("EnvironmentId");

                    b.ToTable("Environment");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProcessInfo.DB.Models.ApplicationEnvironment", b =>
                {
                    b.HasOne("ProcessInfo.DB.Models.Application", "Application")
                        .WithMany("ApplicationEnvironments")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProcessInfo.DB.Models.Environment", "Environment")
                        .WithMany("ApplicationEnvironments")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
