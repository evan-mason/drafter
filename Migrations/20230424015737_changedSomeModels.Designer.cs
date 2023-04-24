﻿// <auto-generated />
using System;
using Drafter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Drafter.Migrations
{
    [DbContext(typeof(DrafterContext))]
    [Migration("20230424015737_changedSomeModels")]
    partial class changedSomeModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Drafter.Data.Entities.FantasyTeam", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FantasyTeams");
                });

            modelBuilder.Entity("Drafter.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AST")
                        .HasColumnType("float");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("BLK")
                        .HasColumnType("float");

                    b.Property<double>("DRB")
                        .HasColumnType("float");

                    b.Property<int>("DraftPosition")
                        .HasColumnType("int");

                    b.Property<DateTime>("DraftTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("FGA")
                        .HasColumnType("float");

                    b.Property<double>("FGM")
                        .HasColumnType("float");

                    b.Property<double>("FGP")
                        .HasColumnType("float");

                    b.Property<int>("FantasyTeamFK")
                        .HasColumnType("int");

                    b.Property<double>("FreeThrowPA")
                        .HasColumnType("float");

                    b.Property<double>("FreeThrowPG")
                        .HasColumnType("float");

                    b.Property<double>("FreeThrowPP")
                        .HasColumnType("float");

                    b.Property<int>("GamesPL")
                        .HasColumnType("int");

                    b.Property<int>("GamesStarted")
                        .HasColumnType("int");

                    b.Property<double>("Minutes")
                        .HasColumnType("float");

                    b.Property<string>("NBATeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ORB")
                        .HasColumnType("float");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<double>("STL")
                        .HasColumnType("float");

                    b.Property<double>("TOV")
                        .HasColumnType("float");

                    b.Property<double>("TRB")
                        .HasColumnType("float");

                    b.Property<double>("ThreePA")
                        .HasColumnType("float");

                    b.Property<double>("ThreePM")
                        .HasColumnType("float");

                    b.Property<double>("ThreePP")
                        .HasColumnType("float");

                    b.Property<double>("TwoPA")
                        .HasColumnType("float");

                    b.Property<double>("TwoPM")
                        .HasColumnType("float");

                    b.Property<double>("TwoPP")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FantasyTeamFK");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Drafter.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Drafter.Data.Entities.FantasyTeam", b =>
                {
                    b.HasOne("Drafter.Data.Entities.User", "User")
                        .WithOne("FantasyTeam")
                        .HasForeignKey("Drafter.Data.Entities.FantasyTeam", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Drafter.Data.Entities.Player", b =>
                {
                    b.HasOne("Drafter.Data.Entities.FantasyTeam", "FantasyTeam")
                        .WithMany("Players")
                        .HasForeignKey("FantasyTeamFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyTeam");
                });

            modelBuilder.Entity("Drafter.Data.Entities.FantasyTeam", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Drafter.Data.Entities.User", b =>
                {
                    b.Navigation("FantasyTeam")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
