﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using budgettracker.data;

#nullable disable

namespace budgettracker.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20240415211410_Initial-v1")]
    partial class Initialv1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Expenses", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Expenses_types", b =>
                {
                    b.Property<int>("ExpensesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpensesId"));

                    b.Property<string>("expenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpensesId");

                    b.ToTable("Expenses_types");
                });

            modelBuilder.Entity("Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncomeId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncomeId");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("Income_types", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncomeId"));

                    b.Property<string>("incomeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncomeId");

                    b.ToTable("Income_types");
                });
#pragma warning restore 612, 618
        }
    }
}