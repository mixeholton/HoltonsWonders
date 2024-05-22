﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MixeWonders.Values.Context;

#nullable disable

namespace MixeWonders.ClientServer.Migrations
{
    [DbContext(typeof(BrugsDbContext))]
    [Migration("20240520105427_e")]
    partial class e
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Affiliations");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationGroup", b =>
                {
                    b.Property<int>("AffiliationId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("AffiliationId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("AffiliationGroups");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationRole", b =>
                {
                    b.Property<int>("AffiliationId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("AffiliationId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AffiliationRoles");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.CreditDebitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("isCredit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CreditDebits");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.GroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.PermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.Property<int?>("RoleEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleEntityId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupEntityId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AffiliationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AffiliationId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationGroup", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.AffiliationEntity", "Affiliation")
                        .WithMany("AffiliationGroups")
                        .HasForeignKey("AffiliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MixeWonders.Values.Entities.GroupEntity", "Group")
                        .WithMany("AffiliationGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Affiliation");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationRole", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.AffiliationEntity", "Affiliation")
                        .WithMany("AffiliationRoles")
                        .HasForeignKey("AffiliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MixeWonders.Values.Entities.RoleEntity", "Role")
                        .WithMany("AffiliationRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Affiliation");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.CreditDebitEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.UserEntity", "User")
                        .WithMany("CreditDebits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.PermissionEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.RoleEntity", null)
                        .WithMany("Permissions")
                        .HasForeignKey("RoleEntityId");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.RoleEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.GroupEntity", null)
                        .WithMany("Roles")
                        .HasForeignKey("GroupEntityId");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.UserEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.AffiliationEntity", "Affiliation")
                        .WithOne("User")
                        .HasForeignKey("MixeWonders.Values.Entities.UserEntity", "AffiliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Affiliation");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationEntity", b =>
                {
                    b.Navigation("AffiliationGroups");

                    b.Navigation("AffiliationRoles");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.GroupEntity", b =>
                {
                    b.Navigation("AffiliationGroups");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.RoleEntity", b =>
                {
                    b.Navigation("AffiliationRoles");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.UserEntity", b =>
                {
                    b.Navigation("CreditDebits");
                });
#pragma warning restore 612, 618
        }
    }
}
