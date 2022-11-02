﻿// <auto-generated />
using System;
using BattleShipV3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BattleShipV3.Shared.Migrations
{
    [DbContext(typeof(BattleshipDbContext))]
    [Migration("20221031181752_AddedSelectedShips")]
    partial class AddedSelectedShips
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BattleShipV3.Data.Models.LeaderboardHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LeaderboardHistories");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Missile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cooldown")
                        .HasColumnType("int");

                    b.Property<int>("MissileType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Missiles");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("MissileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MissileId");

                    b.ToTable("Ships");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ship");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.ShipPlacement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameMatchId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVerticalRotation")
                        .HasColumnType("bit");

                    b.Property<int>("ShipId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("XCoordinate")
                        .HasColumnType("int");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameMatchId");

                    b.HasIndex("ShipId");

                    b.HasIndex("UserId");

                    b.ToTable("ShipPlacements");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Turn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameMatchId")
                        .HasColumnType("int");

                    b.Property<int>("TurnType")
                        .HasColumnType("int");

                    b.Property<int>("XCoordinate")
                        .HasColumnType("int");

                    b.Property<int>("YCoordinate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameMatchId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.UserShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ShipId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.HasIndex("UserId");

                    b.ToTable("UserShips");
                });

            modelBuilder.Entity("BattleShipV3.Models.GameMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameState")
                        .HasColumnType("int");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("GameMatches");
                });

            modelBuilder.Entity("BattleShipV3.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("EloFrom")
                        .HasColumnType("float");

                    b.Property<double?>("EloTo")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerOneId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerTwoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerOneId");

                    b.HasIndex("PlayerTwoId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("BattleShipV3.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Elo")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Healer", b =>
                {
                    b.HasBaseType("BattleShipV3.Data.Models.Ship");

                    b.Property<int>("HealBonus")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Healer");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Submarine", b =>
                {
                    b.HasBaseType("BattleShipV3.Data.Models.Ship");

                    b.Property<int>("HiddenDuration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Submarine");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.LeaderboardHistory", b =>
                {
                    b.HasOne("BattleShipV3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Message", b =>
                {
                    b.HasOne("BattleShipV3.Models.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShipV3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Ship", b =>
                {
                    b.HasOne("BattleShipV3.Data.Models.Missile", "Missile")
                        .WithMany()
                        .HasForeignKey("MissileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Missile");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.ShipPlacement", b =>
                {
                    b.HasOne("BattleShipV3.Models.GameMatch", "GameMatch")
                        .WithMany()
                        .HasForeignKey("GameMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShipV3.Data.Models.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShipV3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMatch");

                    b.Navigation("Ship");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.Turn", b =>
                {
                    b.HasOne("BattleShipV3.Models.GameMatch", "GameMatch")
                        .WithMany()
                        .HasForeignKey("GameMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMatch");
                });

            modelBuilder.Entity("BattleShipV3.Data.Models.UserShip", b =>
                {
                    b.HasOne("BattleShipV3.Data.Models.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShipV3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ship");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BattleShipV3.Models.GameMatch", b =>
                {
                    b.HasOne("BattleShipV3.Models.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShipV3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BattleShipV3.Models.Listing", b =>
                {
                    b.HasOne("BattleShipV3.Models.User", "PlayerOne")
                        .WithMany()
                        .HasForeignKey("PlayerOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShipV3.Models.User", "PlayerTwo")
                        .WithMany()
                        .HasForeignKey("PlayerTwoId");

                    b.Navigation("PlayerOne");

                    b.Navigation("PlayerTwo");
                });
#pragma warning restore 612, 618
        }
    }
}
