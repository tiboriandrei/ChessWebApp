﻿// <auto-generated />
using System;
using ChessWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChessWebApp.Migrations
{
    [DbContext(typeof(ChessContext))]
    [Migration("20200721092848_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("GameStateId");

                    b.Property<int?>("Player1Id");

                    b.Property<int?>("Player2Id");

                    b.Property<string>("Winner");

                    b.HasKey("Id");

                    b.HasIndex("GameStateId");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("ChessTable");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("NrOfDraws");

                    b.Property<int>("NrOfLosses");

                    b.Property<int>("NrOfWins");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChessTableId");

                    b.Property<int>("CoordX");

                    b.Property<int>("CoordY");

                    b.Property<bool>("Occupied");

                    b.Property<string>("Piece");

                    b.HasKey("Id");

                    b.HasIndex("ChessTableId");

                    b.ToTable("Spot");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessGame", b =>
                {
                    b.HasOne("ChessWebApp.Data.Entities.ChessTable", "GameState")
                        .WithMany()
                        .HasForeignKey("GameStateId");

                    b.HasOne("ChessWebApp.Data.Entities.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("ChessWebApp.Data.Entities.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.Spot", b =>
                {
                    b.HasOne("ChessWebApp.Data.Entities.ChessTable")
                        .WithMany("Spots")
                        .HasForeignKey("ChessTableId");
                });
#pragma warning restore 612, 618
        }
    }
}
