using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EcommerceApplication.DataContext;

namespace EcommerceApplication.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceApplication.Models.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartItemId");

                    b.Property<int?>("CustomerId");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("Quantity");

                    b.Property<decimal?>("UnitPrice");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<DateTime?>("DateEntered");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Id");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("PostalCode");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<decimal>("OrderTotal");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EcommerceApplication.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("Quantity");

                    b.Property<decimal?>("UnitPrice");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .HasMaxLength(100);

                    b.Property<int?>("ProductId");

                    b.HasKey("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Details");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("PictureId");

                    b.Property<string>("ProductImagePath");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<decimal>("UnitPrice");

                    b.Property<int?>("UnitsInStock");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EcommerceApplication.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("EcommerceApplication.Models.CartItem", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Customer", "Customers")
                        .WithMany("CartItems")
                        .HasForeignKey("CustomerId");

                    b.HasOne("EcommerceApplication.Models.Product", "Products")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Order", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Customer", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EcommerceApplication.Models.OrderLine", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Order", "Orders")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("EcommerceApplication.Models.Product", "Products")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Picture", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Product", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("EcommerceApplication.Models.SubCategory", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
