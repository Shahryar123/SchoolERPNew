﻿// <auto-generated />
using System;
using DemoAttendenceFeature.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoAttendenceFeature.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240321045512_class-property-null")]
    partial class classpropertynull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoAttendenceFeature.Entities.Attendence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendence");
                });

            modelBuilder.Entity("DemoAttendenceFeature.Entities.Guardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guardian");
                });

            modelBuilder.Entity("DemoAttendenceFeature.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RollNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RollNo"));

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GuardianId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "GuardianId");

                    b.HasIndex("GuardianId");

                    b.ToTable("StudentGurdians", (string)null);
                });

            modelBuilder.Entity("DemoAttendenceFeature.Entities.Attendence", b =>
                {
                    b.HasOne("DemoAttendenceFeature.Entities.Student", "Student")
                        .WithMany("Attendences")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.HasOne("DemoAttendenceFeature.Entities.Guardian", null)
                        .WithMany()
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoAttendenceFeature.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemoAttendenceFeature.Entities.Student", b =>
                {
                    b.Navigation("Attendences");
                });
#pragma warning restore 612, 618
        }
    }
}
