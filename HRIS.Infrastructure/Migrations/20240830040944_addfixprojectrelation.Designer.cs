﻿// <auto-generated />
using System;
using HRIS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    [DbContext(typeof(hrisDbContext))]
    [Migration("20240830040944_addfixprojectrelation")]
    partial class addfixprojectrelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HRIS.Domain.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HRIS.Infrastructure.Departments", b =>
                {
                    b.Property<int>("IdDept")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_dept");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdDept"));

                    b.Property<int?>("Heademp")
                        .HasColumnType("integer")
                        .HasColumnName("heademp");

                    b.Property<int?>("IdLocation")
                        .HasColumnType("integer")
                        .HasColumnName("id_location");

                    b.Property<string>("NameDept")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name_dept");

                    b.Property<int>("NumberDept")
                        .HasColumnType("integer")
                        .HasColumnName("number_dept");

                    b.HasKey("IdDept")
                        .HasName("departments_pkey");

                    b.HasIndex("Heademp");

                    b.HasIndex("IdLocation");

                    b.HasIndex(new[] { "NumberDept" }, "departments_number_dept_key")
                        .IsUnique();

                    b.ToTable("departments");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Dependents", b =>
                {
                    b.Property<int>("IdDependent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_dependent");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdDependent"));

                    b.Property<DateOnly>("Dobdependent")
                        .HasColumnType("date")
                        .HasColumnName("dobdependent");

                    b.Property<int?>("IdEmp")
                        .HasColumnType("integer")
                        .HasColumnName("id_emp");

                    b.Property<string>("Namedependent")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("namedependent");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("relation");

                    b.Property<string>("Sexdependent")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("sexdependent");

                    b.HasKey("IdDependent")
                        .HasName("dependents_pkey");

                    b.HasIndex("IdEmp");

                    b.ToTable("dependents");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Employees", b =>
                {
                    b.Property<int>("IdEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_emp");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEmp"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<DateOnly>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<int?>("IdDept")
                        .HasColumnType("integer")
                        .HasColumnName("id_dept");

                    b.Property<string>("JobPosition")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("job_position");

                    b.Property<DateTime>("Lastupdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdate")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Level")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("level");

                    b.Property<string>("NameEmp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name_emp");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phone");

                    b.Property<string>("Reason")
                        .HasColumnType("text")
                        .HasColumnName("reason");

                    b.Property<string>("Sex")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("sex");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("ssn");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("status");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("IdEmp")
                        .HasName("employees_pkey");

                    b.HasIndex("IdDept");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Locations", b =>
                {
                    b.Property<int>("IdLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_location");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdLocation"));

                    b.Property<string>("Addresslocation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("addresslocation");

                    b.Property<string>("Namelocation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("namelocation");

                    b.HasKey("IdLocation")
                        .HasName("locations_pkey");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Projects", b =>
                {
                    b.Property<int>("IdProj")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_proj");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProj"));

                    b.Property<int>("IdDept")
                        .HasColumnType("integer")
                        .HasColumnName("id_dept");

                    b.Property<int>("IdLocation")
                        .HasColumnType("integer")
                        .HasColumnName("id_location");

                    b.Property<string>("Nameproj")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nameproj");

                    b.HasKey("IdProj")
                        .HasName("projects_pkey");

                    b.HasIndex(new[] { "IdDept" }, "projects_id_dept_key")
                        .IsUnique();

                    b.HasIndex(new[] { "IdLocation" }, "projects_id_location_key")
                        .IsUnique();

                    b.ToTable("projects");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Projemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Hoursperweek")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("hoursperweek");

                    b.Property<int?>("IdEmp")
                        .HasColumnType("integer")
                        .HasColumnName("id_emp");

                    b.Property<int?>("IdProj")
                        .HasColumnType("integer")
                        .HasColumnName("id_proj");

                    b.HasKey("Id")
                        .HasName("projemp_pkey");

                    b.HasIndex("IdEmp");

                    b.HasIndex("IdProj");

                    b.ToTable("projemp");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HRIS.Infrastructure.Departments", b =>
                {
                    b.HasOne("HRIS.Infrastructure.Employees", "HeadempNavigation")
                        .WithMany("Departments")
                        .HasForeignKey("Heademp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_heademp");

                    b.HasOne("HRIS.Infrastructure.Locations", "IdLocationNavigation")
                        .WithMany("Departments")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_id_location");

                    b.Navigation("HeadempNavigation");

                    b.Navigation("IdLocationNavigation");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Dependents", b =>
                {
                    b.HasOne("HRIS.Infrastructure.Employees", "IdEmpNavigation")
                        .WithMany("Dependents")
                        .HasForeignKey("IdEmp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_id_emp");

                    b.Navigation("IdEmpNavigation");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Employees", b =>
                {
                    b.HasOne("HRIS.Infrastructure.Departments", "IdDeptNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("IdDept")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_id_dept");

                    b.Navigation("IdDeptNavigation");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Projects", b =>
                {
                    b.HasOne("HRIS.Infrastructure.Departments", "IdDeptNavigation")
                        .WithMany("Projects")
                        .HasForeignKey("IdDept")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_id_dept");

                    b.HasOne("HRIS.Infrastructure.Locations", "IdLocationNavigation")
                        .WithMany("Projects")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_id_location");

                    b.Navigation("IdDeptNavigation");

                    b.Navigation("IdLocationNavigation");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Projemp", b =>
                {
                    b.HasOne("HRIS.Infrastructure.Employees", "IdEmpNavigation")
                        .WithMany("Projemp")
                        .HasForeignKey("IdEmp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_projemp_id_emp");

                    b.HasOne("HRIS.Infrastructure.Projects", "IdProjNavigation")
                        .WithMany("Projemp")
                        .HasForeignKey("IdProj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_projemp_id_proj");

                    b.Navigation("IdEmpNavigation");

                    b.Navigation("IdProjNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HRIS.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HRIS.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRIS.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HRIS.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRIS.Infrastructure.Departments", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Employees", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Dependents");

                    b.Navigation("Projemp");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Locations", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("HRIS.Infrastructure.Projects", b =>
                {
                    b.Navigation("Projemp");
                });
#pragma warning restore 612, 618
        }
    }
}
