﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Calculator.Model;

namespace Calculator.Migrations
{
    [DbContext(typeof(CalculatorContext))]
    [Migration("20170406131341_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Calculator.Model.OperationResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Operation");

                    b.Property<double>("Result");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("Resulte");
                });
        }
    }
}
