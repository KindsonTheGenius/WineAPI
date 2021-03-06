// <auto-generated />
using System;
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

                    b.Property<int>("Style")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Taste")
                        .HasColumnType("TEXT");

                    b.Property<int>("WineImageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WineMakerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("WineBottleId");

                    b.HasIndex("WineMakerId");

                    b.ToTable("WineBottle");
                });

            modelBuilder.Entity("WineAPI.Models.WineImage", b =>
                {
                    b.Property<int>("WineImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("WineImageData")
                        .HasColumnType("BLOB");

                    b.Property<string>("WineImageTitle")
                        .HasColumnType("TEXT");

                    b.HasKey("WineImageId");

                    b.ToTable("WineImage");
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
