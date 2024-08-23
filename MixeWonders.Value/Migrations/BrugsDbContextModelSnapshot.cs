﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MixeWonders.Values.Context;

#nullable disable

namespace MixeWonders.Value.Migrations
{
    [DbContext(typeof(BrugsDbContext))]
    partial class BrugsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Affiliations", (string)null);
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

                    b.ToTable("CreditDebits", (string)null);
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.GroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AffiliationEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AffiliationEntityId");

                    b.ToTable("Groups", (string)null);
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

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AffiliationEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AffiliationEntityId");

                    b.HasIndex("GroupEntityId");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AffiliationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupEntityId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.UserEntity", "User")
                        .WithOne("Affiliation")
                        .HasForeignKey("MixeWonders.Values.Entities.AffiliationEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("MixeWonders.Values.Entities.GroupEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.AffiliationEntity", null)
                        .WithMany("AffiliationGroups")
                        .HasForeignKey("AffiliationEntityId");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.PermissionEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.RoleEntity", null)
                        .WithMany("Permissions")
                        .HasForeignKey("RoleEntityId");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.RoleEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.AffiliationEntity", null)
                        .WithMany("AffiliationRoles")
                        .HasForeignKey("AffiliationEntityId");

                    b.HasOne("MixeWonders.Values.Entities.GroupEntity", null)
                        .WithMany("Roles")
                        .HasForeignKey("GroupEntityId");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.UserEntity", b =>
                {
                    b.HasOne("MixeWonders.Values.Entities.GroupEntity", null)
                        .WithMany("Users")
                        .HasForeignKey("GroupEntityId");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.AffiliationEntity", b =>
                {
                    b.Navigation("AffiliationGroups");

                    b.Navigation("AffiliationRoles");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.GroupEntity", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.RoleEntity", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("MixeWonders.Values.Entities.UserEntity", b =>
                {
                    b.Navigation("Affiliation");

                    b.Navigation("CreditDebits");
                });
#pragma warning restore 612, 618
        }
    }
}
