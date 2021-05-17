﻿// <auto-generated />
using System;
using MarkelApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarkelApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210517161853_updateAggLimitModel")]
    partial class updateAggLimitModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarkelApp.Models.Analysis", b =>
                {
                    b.Property<int>("AnalysisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AggLimit_1")
                        .HasColumnType("bigint");

                    b.Property<long>("AggLimit_2")
                        .HasColumnType("bigint");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("AnalysisId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Analysis");
                });

            modelBuilder.Entity("MarkelApp.Models.Submission", b =>
                {
                    b.Property<int>("SubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("SubmissionDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmissionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("SubmissionId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("MarkelApp.Models.Analysis", b =>
                {
                    b.HasOne("MarkelApp.Models.Submission", "Submission")
                        .WithMany("Analyses")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("MarkelApp.Models.Submission", b =>
                {
                    b.Navigation("Analyses");
                });
#pragma warning restore 612, 618
        }
    }
}
