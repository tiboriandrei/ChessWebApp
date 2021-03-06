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
    [Migration("20200723114621_ChessContext3")]
    partial class ChessContext3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GameStateId")
                        .HasColumnType("int");

                    b.Property<int?>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Player2Id")
                        .HasColumnType("int");

                    b.Property<string>("Winner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameStateId");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MatchHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfDraws")
                        .HasColumnType("int");

                    b.Property<int>("NrOfLosses")
                        .HasColumnType("int");

                    b.Property<int>("NrOfWins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChessTableId")
                        .HasColumnType("int");

                    b.Property<int>("CoordX")
                        .HasColumnType("int");

                    b.Property<int>("CoordY")
                        .HasColumnType("int");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<string>("Piece")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChessTableId");

                    b.ToTable("ChessSpot");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("ChessTable");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessGame", b =>
                {
                    b.HasOne("ChessWebApp.Data.Entities.ChessTable", "GameState")
                        .WithMany()
                        .HasForeignKey("GameStateId");

                    b.HasOne("ChessWebApp.Data.Entities.ChessPlayer", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("ChessWebApp.Data.Entities.ChessPlayer", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");
                });

            modelBuilder.Entity("ChessWebApp.Data.Entities.ChessSpot", b =>
                {
                    b.HasOne("ChessWebApp.Data.Entities.ChessTable", null)
                        .WithMany("Spots")
                        .HasForeignKey("ChessTableId");
                });
#pragma warning restore 612, 618
        }
    }
}
