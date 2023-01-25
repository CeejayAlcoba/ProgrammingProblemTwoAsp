﻿// <auto-generated />
using System;
using DataAccessEfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessEfCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Credential", b =>
                {
                    b.Property<int>("credentialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("hashed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("salted")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("credentialId");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            credentialId = 1,
                            hashed = "tRpuHyCTQXB0qHHBjdy31uHfUpPDMEXMW73NmH7wQ1I=",
                            salted = new byte[] { 31, 98, 216, 245, 120, 65, 245, 24, 52, 167, 115, 222, 47, 36, 137, 13 },
                            username = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("credentialId")
                        .HasColumnType("int");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("positionId")
                        .HasColumnType("int");

                    b.HasKey("employeeId");

                    b.HasIndex("credentialId");

                    b.HasIndex("positionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            employeeId = 1,
                            birthday = new DateTime(2023, 1, 25, 11, 21, 40, 426, DateTimeKind.Local).AddTicks(8129),
                            credentialId = 1,
                            firstname = "admin",
                            gender = "male",
                            lastname = "admin",
                            positionId = 1
                        });
                });

            modelBuilder.Entity("Domain.Position", b =>
                {
                    b.Property<int>("positionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("positionId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            positionId = 1,
                            type = "Admin"
                        },
                        new
                        {
                            positionId = 2,
                            type = "Manager"
                        },
                        new
                        {
                            positionId = 3,
                            type = "Supervisor"
                        },
                        new
                        {
                            positionId = 4,
                            type = "Staff"
                        });
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.HasOne("Domain.Credential", "credential")
                        .WithMany()
                        .HasForeignKey("credentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Position", "position")
                        .WithMany()
                        .HasForeignKey("positionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("credential");

                    b.Navigation("position");
                });
#pragma warning restore 612, 618
        }
    }
}
