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
    [Migration("20230429055232_newchanges")]
    partial class newchanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Drafter.Data.Entities.Draft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DraftType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Drafts");
                });

            modelBuilder.Entity("Drafter.Data.Entities.DrafterUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Drafter.Data.Entities.FantasyTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DraftId")
                        .HasColumnType("int");

                    b.Property<string>("DrafterUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DraftId");

                    b.HasIndex("DrafterUserId")
                        .IsUnique()
                        .HasFilter("[DrafterUserId] IS NOT NULL");

                    b.ToTable("FantasyTeams");
                });

            modelBuilder.Entity("Drafter.Data.Entities.Pick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DraftId")
                        .HasColumnType("int");

                    b.Property<int>("FantasyTeamId")
                        .HasColumnType("int");

                    b.Property<int>("PickNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("PickTakenTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DraftId");

                    b.HasIndex("FantasyTeamId");

                    b.ToTable("Picks");
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

                    b.Property<int>("DrafterUserId")
                        .HasColumnType("int");

                    b.Property<double>("FGA")
                        .HasColumnType("float");

                    b.Property<double>("FGM")
                        .HasColumnType("float");

                    b.Property<double>("FGP")
                        .HasColumnType("float");

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

                    b.HasIndex("DrafterUserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Drafter.Data.Entities.Draft", b =>
                {
                    b.HasOne("Drafter.Data.Entities.DrafterUser", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Drafter.Data.Entities.FantasyTeam", b =>
                {
                    b.HasOne("Drafter.Data.Entities.Draft", null)
                        .WithMany("Teams")
                        .HasForeignKey("DraftId");

                    b.HasOne("Drafter.Data.Entities.DrafterUser", "DrafterUser")
                        .WithOne("FantasyTeam")
                        .HasForeignKey("Drafter.Data.Entities.FantasyTeam", "DrafterUserId");

                    b.Navigation("DrafterUser");
                });

            modelBuilder.Entity("Drafter.Data.Entities.Pick", b =>
                {
                    b.HasOne("Drafter.Data.Entities.Draft", null)
                        .WithMany("Picks")
                        .HasForeignKey("DraftId");

                    b.HasOne("Drafter.Data.Entities.FantasyTeam", "FantasyTeam")
                        .WithMany()
                        .HasForeignKey("FantasyTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyTeam");
                });

            modelBuilder.Entity("Drafter.Data.Entities.Player", b =>
                {
                    b.HasOne("Drafter.Data.Entities.FantasyTeam", "FantasyTeam")
                        .WithMany("Players")
                        .HasForeignKey("DrafterUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyTeam");
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
                    b.HasOne("Drafter.Data.Entities.DrafterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Drafter.Data.Entities.DrafterUser", null)
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

                    b.HasOne("Drafter.Data.Entities.DrafterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Drafter.Data.Entities.DrafterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Drafter.Data.Entities.Draft", b =>
                {
                    b.Navigation("Picks");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Drafter.Data.Entities.DrafterUser", b =>
                {
                    b.Navigation("FantasyTeam");
                });

            modelBuilder.Entity("Drafter.Data.Entities.FantasyTeam", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
