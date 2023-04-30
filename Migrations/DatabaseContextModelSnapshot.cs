﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace oopkr.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Models.ItemProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("itemid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("productid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("itemid");

                    b.HasIndex("productid");

                    b.ToTable("ItemProduct");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("totalPrice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Models.OrderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("itemid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("orderid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("itemid");

                    b.HasIndex("orderid");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Models.ItemProduct", b =>
                {
                    b.HasOne("Models.Item", "item")
                        .WithMany("itemProducts")
                        .HasForeignKey("itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Product", "product")
                        .WithMany("itemProducts")
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Models.OrderItem", b =>
                {
                    b.HasOne("Models.Item", "item")
                        .WithMany("orderItems")
                        .HasForeignKey("itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Models.Item", b =>
                {
                    b.Navigation("itemProducts");

                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Navigation("itemProducts");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
