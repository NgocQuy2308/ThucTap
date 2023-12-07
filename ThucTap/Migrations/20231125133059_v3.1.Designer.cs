﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThucTap.Entity;

#nullable disable

namespace ThucTap.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231125133059_v3.1")]
    partial class v31
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ThucTap.Entity.Account", b =>
                {
                    b.Property<int>("Account_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Account_id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DecentralizationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetPasswordTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Account_id");

                    b.HasIndex("DecentralizationId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ThucTap.Entity.Cart_item", b =>
                {
                    b.Property<int>("Cart_item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cart_item_id"));

                    b.Property<int>("Cart_id")
                        .HasColumnType("int");

                    b.Property<int?>("CartsCart_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int?>("Product_id1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Cart_item_id");

                    b.HasIndex("CartsCart_id");

                    b.HasIndex("Product_id1");

                    b.ToTable("Cart_Items");
                });

            modelBuilder.Entity("ThucTap.Entity.Carts", b =>
                {
                    b.Property<int>("Cart_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cart_id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<int?>("User_id1")
                        .HasColumnType("int");

                    b.HasKey("Cart_id");

                    b.HasIndex("User_id1");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ThucTap.Entity.ConfirmEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RequiredDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<int?>("User_id1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_id1");

                    b.ToTable("ConfirmEmails");
                });

            modelBuilder.Entity("ThucTap.Entity.Decentralization", b =>
                {
                    b.Property<int>("decentralization_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("decentralization_id"));

                    b.Property<string>("Authority_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("decentralization_id");

                    b.ToTable("Decentralizations");
                });

            modelBuilder.Entity("ThucTap.Entity.Order", b =>
                {
                    b.Property<int>("Order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_id"));

                    b.Property<double>("Actual_price")
                        .HasColumnType("float");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order_status_id")
                        .HasColumnType("int");

                    b.Property<int?>("Order_status_id1")
                        .HasColumnType("int");

                    b.Property<double>("Original_price")
                        .HasColumnType("float");

                    b.Property<int>("Payment_id")
                        .HasColumnType("int");

                    b.Property<int?>("Payment_id1")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<int?>("User_id1")
                        .HasColumnType("int");

                    b.HasKey("Order_id");

                    b.HasIndex("Order_status_id1");

                    b.HasIndex("Payment_id1");

                    b.HasIndex("User_id1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ThucTap.Entity.Order_detail", b =>
                {
                    b.Property<int>("Order_detail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_detail_id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<int?>("Order_id1")
                        .HasColumnType("int");

                    b.Property<int>("Price_total")
                        .HasColumnType("int");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int?>("Product_id1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Order_detail_id");

                    b.HasIndex("Order_id1");

                    b.HasIndex("Product_id1");

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("ThucTap.Entity.Order_status", b =>
                {
                    b.Property<int>("Order_status_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_status_id"));

                    b.Property<string>("Status_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Order_status_id");

                    b.ToTable("Order_Statuses");
                });

            modelBuilder.Entity("ThucTap.Entity.Payment", b =>
                {
                    b.Property<int>("Payment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payment_id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Payment_id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ThucTap.Entity.Product", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_id"));

                    b.Property<string>("Avatar_image_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Name_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_of_view")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Product_type_id")
                        .HasColumnType("int");

                    b.Property<int?>("Product_type_id1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Product_id");

                    b.HasIndex("Product_type_id1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ThucTap.Entity.Product_image", b =>
                {
                    b.Property<int>("Product_image_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_image_id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int?>("Product_id1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Product_image_id");

                    b.HasIndex("Product_id1");

                    b.ToTable("Product_Images");
                });

            modelBuilder.Entity("ThucTap.Entity.Product_review", b =>
                {
                    b.Property<int>("Product_review_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_review_id"));

                    b.Property<string>("Content_rated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content_seen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Point_evaluation")
                        .HasColumnType("int");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int?>("Product_id1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<int?>("User_id1")
                        .HasColumnType("int");

                    b.HasKey("Product_review_id");

                    b.HasIndex("Product_id1");

                    b.HasIndex("User_id1");

                    b.ToTable("Product_Reviews");
                });

            modelBuilder.Entity("ThucTap.Entity.Product_type", b =>
                {
                    b.Property<int>("Product_type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_type_id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image_type_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_product_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Product_type_id");

                    b.ToTable("Product_Types");
                });

            modelBuilder.Entity("ThucTap.Entity.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Account_id")
                        .HasColumnType("int");

                    b.Property<int?>("Account_id1")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Account_id1");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("ThucTap.Entity.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"));

                    b.Property<int>("Account_id")
                        .HasColumnType("int");

                    b.Property<int?>("Account_id1")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.HasIndex("Account_id1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ThucTap.Entity.Account", b =>
                {
                    b.HasOne("ThucTap.Entity.Decentralization", "Decentralization")
                        .WithMany("accounts")
                        .HasForeignKey("DecentralizationId");

                    b.Navigation("Decentralization");
                });

            modelBuilder.Entity("ThucTap.Entity.Cart_item", b =>
                {
                    b.HasOne("ThucTap.Entity.Carts", "Carts")
                        .WithMany("Cart_items")
                        .HasForeignKey("CartsCart_id");

                    b.HasOne("ThucTap.Entity.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("Product_id1");

                    b.Navigation("Carts");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ThucTap.Entity.Carts", b =>
                {
                    b.HasOne("ThucTap.Entity.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("User_id1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThucTap.Entity.ConfirmEmail", b =>
                {
                    b.HasOne("ThucTap.Entity.User", "User")
                        .WithMany("ConfirmEmails")
                        .HasForeignKey("User_id1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThucTap.Entity.Order", b =>
                {
                    b.HasOne("ThucTap.Entity.Order_status", "Order_status")
                        .WithMany("orders")
                        .HasForeignKey("Order_status_id1");

                    b.HasOne("ThucTap.Entity.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("Payment_id1");

                    b.HasOne("ThucTap.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("User_id1");

                    b.Navigation("Order_status");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThucTap.Entity.Order_detail", b =>
                {
                    b.HasOne("ThucTap.Entity.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("Order_id1");

                    b.HasOne("ThucTap.Entity.Product", "Product")
                        .WithMany("Order_Details")
                        .HasForeignKey("Product_id1");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ThucTap.Entity.Product", b =>
                {
                    b.HasOne("ThucTap.Entity.Product_type", "Product_Type")
                        .WithMany("Products")
                        .HasForeignKey("Product_type_id1");

                    b.Navigation("Product_Type");
                });

            modelBuilder.Entity("ThucTap.Entity.Product_image", b =>
                {
                    b.HasOne("ThucTap.Entity.Product", "Product")
                        .WithMany("Product_Images")
                        .HasForeignKey("Product_id1");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ThucTap.Entity.Product_review", b =>
                {
                    b.HasOne("ThucTap.Entity.Product", "Product")
                        .WithMany("Product_Reviews")
                        .HasForeignKey("Product_id1");

                    b.HasOne("ThucTap.Entity.User", "User")
                        .WithMany("product_Reviews")
                        .HasForeignKey("User_id1");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThucTap.Entity.RefreshToken", b =>
                {
                    b.HasOne("ThucTap.Entity.Account", "account")
                        .WithMany("Tokens")
                        .HasForeignKey("Account_id1");

                    b.Navigation("account");
                });

            modelBuilder.Entity("ThucTap.Entity.User", b =>
                {
                    b.HasOne("ThucTap.Entity.Account", "Account")
                        .WithMany("user")
                        .HasForeignKey("Account_id1");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ThucTap.Entity.Account", b =>
                {
                    b.Navigation("Tokens");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ThucTap.Entity.Carts", b =>
                {
                    b.Navigation("Cart_items");
                });

            modelBuilder.Entity("ThucTap.Entity.Decentralization", b =>
                {
                    b.Navigation("accounts");
                });

            modelBuilder.Entity("ThucTap.Entity.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ThucTap.Entity.Order_status", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("ThucTap.Entity.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ThucTap.Entity.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Order_Details");

                    b.Navigation("Product_Images");

                    b.Navigation("Product_Reviews");
                });

            modelBuilder.Entity("ThucTap.Entity.Product_type", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ThucTap.Entity.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("ConfirmEmails");

                    b.Navigation("Orders");

                    b.Navigation("product_Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
