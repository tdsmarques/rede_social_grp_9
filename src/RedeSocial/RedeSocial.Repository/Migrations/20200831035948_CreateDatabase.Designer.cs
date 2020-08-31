﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedeSocial.Repository.Context;

namespace RedeSocial.Repository.Migrations
{
    [DbContext(typeof(RedeSocialContext))]
    [Migration("20200831035948_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RedeSocial.Domain.Account.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProfileId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ProfileId1");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Account", b =>
                {
                    b.HasOne("RedeSocial.Domain.Account.Profile", null)
                        .WithMany("Accounts")
                        .HasForeignKey("ProfileId");

                    b.HasOne("RedeSocial.Domain.Account.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId1");
                });
#pragma warning restore 612, 618
        }
    }
}
