﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WineAPI.Migrations
{
    [DbContext(typeof(WineContext))]
    partial class WineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15");

            modelBuilder.Entity("WineAPI.Models.WineBottle", b =>
                {
                    b.Property<int>("WineBottleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountInCeller")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FoodPairing")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Style")
                        .HasColumnType("TEXT");

                    b.Property<string>("Taste")
                        .HasColumnType("TEXT");

                    b.Property<int>("WineMakerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("WineBottleId");

                    b.HasIndex("WineMakerId");

                    b.ToTable("WineBottle");

                    b.HasData(
                        new
                        {
                            WineBottleId = 1,
                            CountInCeller = 10,
                            Description = "A very nice wine",
                            FoodPairing = "A good meal",
                            Image = "Great",
                            Link = "my link",
                            Size = 34,
                            Style = "Strong",
                            Taste = "Good",
                            WineMakerId = 1,
                            Year = "2021"
                        });
                });

            modelBuilder.Entity("WineAPI.Models.WineMaker", b =>
                {
                    b.Property<int>("WineMakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("WineMakerId");

                    b.ToTable("WineMaker");

                    b.HasData(
                        new
                        {
                            WineMakerId = 1,
                            Address = "Budapest utca 45",
                            Name = "Kindson Munonye"
                        });
                });

            modelBuilder.Entity("WineAPI.Models.WineBottle", b =>
                {
                    b.HasOne("WineAPI.Models.WineMaker", "WineMaker")
                        .WithMany("WineBottles")
                        .HasForeignKey("WineMakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
