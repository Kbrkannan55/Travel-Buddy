﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using loginauth.Context;

#nullable disable

namespace KaniniTourism.Migrations
{
    [DbContext(typeof(TourismContext))]
    [Migration("20230801125453_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KaniniTourism.Models.Booking", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int?>("AdultCount")
                        .HasColumnType("int");

                    b.Property<int?>("ChildCount")
                        .HasColumnType("int");

                    b.Property<int?>("Id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PackageID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("PackageID");

                    b.HasIndex("UserId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("KaniniTourism.Models.Feedback", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("KaniniTourism.Models.Hotels", b =>
                {
                    b.Property<int?>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("HotelId"));

                    b.Property<string>("FoodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelRoomsAvailable")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PricePerPerson")
                        .HasColumnType("int");

                    b.Property<double?>("Ratings")
                        .HasColumnType("float");

                    b.HasKey("HotelId");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("KaniniTourism.Models.ImageGallery", b =>
                {
                    b.Property<int>("AdminImgsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminImgsId"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LocationDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AdminImgsId");

                    b.HasIndex("UserId");

                    b.ToTable("imageGallery");
                });

            modelBuilder.Entity("KaniniTourism.Models.Package", b =>
                {
                    b.Property<int?>("PackageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PackageID"));

                    b.Property<int?>("Days")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("HotelsHotelId")
                        .HasColumnType("int");

                    b.Property<int?>("Id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("In_Out_India")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItineraryDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nights")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("OfferDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("PricePerPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Totaldays")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageID");

                    b.HasIndex("HotelsHotelId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("packages");
                });

            modelBuilder.Entity("KaniniTourism.Models.Place", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("places");
                });

            modelBuilder.Entity("KaniniTourism.Models.Spot", b =>
                {
                    b.Property<int?>("SpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SpotId"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PlaceId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("SpotLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpotId");

                    b.HasIndex("PlaceId");

                    b.ToTable("spots");
                });

            modelBuilder.Entity("KaniniTourism.Models.Transaction", b =>
                {
                    b.Property<int>("TranactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranactionId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("BookingBookId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<double?>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("TranactionId");

                    b.HasIndex("BookingBookId");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("KaniniTourism.Models.TravelAgent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aadharnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgencyDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AgencyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("Phone")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("travelAgents");
                });

            modelBuilder.Entity("KaniniTourism.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aadharnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgencyDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AgencyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("Phone")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("KaniniTourism.Models.Booking", b =>
                {
                    b.HasOne("KaniniTourism.Models.Package", null)
                        .WithMany("Booking")
                        .HasForeignKey("PackageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KaniniTourism.Models.User", null)
                        .WithMany("Books")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("KaniniTourism.Models.ImageGallery", b =>
                {
                    b.HasOne("KaniniTourism.Models.User", null)
                        .WithMany("AdminImages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("KaniniTourism.Models.Package", b =>
                {
                    b.HasOne("KaniniTourism.Models.Hotels", null)
                        .WithMany("packages")
                        .HasForeignKey("HotelsHotelId");

                    b.HasOne("KaniniTourism.Models.Place", null)
                        .WithMany("Packages")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KaniniTourism.Models.User", null)
                        .WithMany("Packages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("KaniniTourism.Models.Spot", b =>
                {
                    b.HasOne("KaniniTourism.Models.Place", null)
                        .WithMany("Spots")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KaniniTourism.Models.Transaction", b =>
                {
                    b.HasOne("KaniniTourism.Models.Booking", null)
                        .WithMany("Transactions")
                        .HasForeignKey("BookingBookId");
                });

            modelBuilder.Entity("KaniniTourism.Models.Booking", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("KaniniTourism.Models.Hotels", b =>
                {
                    b.Navigation("packages");
                });

            modelBuilder.Entity("KaniniTourism.Models.Package", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("KaniniTourism.Models.Place", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("Spots");
                });

            modelBuilder.Entity("KaniniTourism.Models.User", b =>
                {
                    b.Navigation("AdminImages");

                    b.Navigation("Books");

                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}