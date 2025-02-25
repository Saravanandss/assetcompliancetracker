﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using act.core.data;

namespace act.core.data.Migrations
{
    [DbContext(typeof(ActDbContext))]
    [Migration("20180824190017_InitialUtf8")]
    partial class InitialUtf8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("act.core.data.BuildSpecification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildSpecificationType");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("OperatingSystemName")
                        .HasMaxLength(256);

                    b.Property<string>("OperatingSystemVersion")
                        .HasMaxLength(32);

                    b.Property<string>("Overview");

                    b.Property<long>("OwnerEmployeeId");

                    b.Property<long?>("ParentId");

                    b.Property<int?>("Platform");

                    b.Property<bool>("RunningCoreOs");

                    b.Property<DateTime>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("WikiLink")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OwnerEmployeeId");

                    b.HasIndex("ParentId");

                    b.ToTable("BuildSpecification");
                });

            modelBuilder.Entity("act.core.data.ComplianceResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<long>("InventoryItemId");

                    b.Property<bool>("OperatingSystemTestPassed");

                    b.Property<Guid>("ResultId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemId");

                    b.HasIndex("ResultId", "InventoryItemId")
                        .IsUnique();

                    b.HasIndex("EndDate", "Id", "InventoryItemId");

                    b.ToTable("ComplianceResult");
                });

            modelBuilder.Entity("act.core.data.ComplianceResultError", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<long>("ComplianceResultId");

                    b.Property<string>("LongMessage")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ComplianceResultId", "Code", "Name");

                    b.ToTable("ComplianceResultError");
                });

            modelBuilder.Entity("act.core.data.ComplianceResultTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ComplianceResultId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("PortType");

                    b.Property<int>("ResultType");

                    b.Property<bool>("ShouldExist");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ComplianceResultId", "ResultType", "PortType", "ShouldExist", "Name");

                    b.ToTable("ComplianceResultTest");
                });

            modelBuilder.Entity("act.core.data.Employee", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("PreferredName")
                        .HasMaxLength(64);

                    b.Property<long?>("ReportingDirectorId");

                    b.Property<string>("SamAccountName")
                        .IsRequired()
                        .HasColumnType("nchar(64)");

                    b.Property<long?>("SupervisorId");

                    b.HasKey("Id");

                    b.HasIndex("ReportingDirectorId");

                    b.HasIndex("SamAccountName")
                        .IsUnique();

                    b.HasIndex("SupervisorId");

                    b.HasIndex("FirstName", "Id");

                    b.HasIndex("LastName", "Id");

                    b.HasIndex("PreferredName", "Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("act.core.data.Environment", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("ChefAutomateOrg")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<string>("ChefAutomateToken")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("ChefAutomateUrl")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Environment");
                });

            modelBuilder.Entity("act.core.data.Function", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("act.core.data.Justification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BuildSpecificationId");

                    b.Property<string>("Color");

                    b.Property<string>("JustificationText")
                        .IsRequired();

                    b.Property<int>("JustificationType");

                    b.Property<DateTime>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BuildSpecificationId");

                    b.ToTable("Justification");
                });

            modelBuilder.Entity("act.core.data.Node", b =>
                {
                    b.Property<long>("InventoryItemId");

                    b.Property<long?>("BuildSpecificationId");

                    b.Property<Guid?>("ChefNodeId");

                    b.Property<int>("ComplianceStatus");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("EnvironmentId");

                    b.Property<DateTime?>("FailingSince")
                        .HasColumnType("datetime");

                    b.Property<string>("Fqdn")
                        .HasMaxLength(256);

                    b.Property<int>("FunctionId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("LastComplianceResultDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("LastComplianceResultId");

                    b.Property<DateTime?>("LastEmailedOn")
                        .HasColumnType("datetime");

                    b.Property<long>("OwnerEmployeeId");

                    b.Property<int>("PciScope")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("4");

                    b.Property<int>("Platform");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nchar(4)");

                    b.HasKey("InventoryItemId");

                    b.HasIndex("BuildSpecificationId");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("FunctionId");

                    b.HasIndex("OwnerEmployeeId");

                    b.HasIndex("Platform");

                    b.HasIndex("ProductCode");

                    b.HasIndex("Fqdn", "InventoryItemId");

                    b.HasIndex("PciScope", "InventoryItemId");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("act.core.data.Port", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BuildSpecificationId");

                    b.Property<int>("From");

                    b.Property<bool>("IsExternal");

                    b.Property<bool>("IsOutgoing");

                    b.Property<long?>("JustificationId");

                    b.Property<int>("PortType");

                    b.Property<DateTime>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("To");

                    b.HasKey("Id");

                    b.HasIndex("BuildSpecificationId");

                    b.HasIndex("JustificationId");

                    b.ToTable("Port");
                });

            modelBuilder.Entity("act.core.data.Product", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nchar(4)");

                    b.Property<bool>("ExludeFromReports");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Code");

                    b.HasIndex("Name");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("act.core.data.SoftwareComponent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BuildSpecificationId");

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<long?>("JustificationId");

                    b.Property<int>("JustificationType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("NonCore");

                    b.Property<int?>("PciScope");

                    b.Property<DateTime>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BuildSpecificationId");

                    b.HasIndex("JustificationId");

                    b.ToTable("SoftwareComponent");
                });

            modelBuilder.Entity("act.core.data.SoftwareComponentEnvironment", b =>
                {
                    b.Property<int>("EnvironmentId");

                    b.Property<long>("SoftwareComponentId");

                    b.HasKey("EnvironmentId", "SoftwareComponentId");

                    b.HasIndex("SoftwareComponentId");

                    b.ToTable("SoftwareComponentEnvironment");
                });

            modelBuilder.Entity("act.core.data.BuildSpecification", b =>
                {
                    b.HasOne("act.core.data.Employee", "Owner")
                        .WithMany("BuildSpecifications")
                        .HasForeignKey("OwnerEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.BuildSpecification", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("act.core.data.ComplianceResult", b =>
                {
                    b.HasOne("act.core.data.Node", "Node")
                        .WithMany("ComplianceResults")
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("act.core.data.ComplianceResultError", b =>
                {
                    b.HasOne("act.core.data.ComplianceResult", "ComplianceResult")
                        .WithMany("Errors")
                        .HasForeignKey("ComplianceResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("act.core.data.ComplianceResultTest", b =>
                {
                    b.HasOne("act.core.data.ComplianceResult", "ComplianceResult")
                        .WithMany("Tests")
                        .HasForeignKey("ComplianceResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("act.core.data.Employee", b =>
                {
                    b.HasOne("act.core.data.Employee", "ReportingDirector")
                        .WithMany()
                        .HasForeignKey("ReportingDirectorId");

                    b.HasOne("act.core.data.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");
                });

            modelBuilder.Entity("act.core.data.Justification", b =>
                {
                    b.HasOne("act.core.data.BuildSpecification", "BuildSpecification")
                        .WithMany("Justifications")
                        .HasForeignKey("BuildSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("act.core.data.Node", b =>
                {
                    b.HasOne("act.core.data.BuildSpecification", "BuildSpecification")
                        .WithMany("Nodes")
                        .HasForeignKey("BuildSpecificationId");

                    b.HasOne("act.core.data.Environment", "Environment")
                        .WithMany("Nodes")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.Function", "Function")
                        .WithMany("Nodes")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.Employee", "Owner")
                        .WithMany("Nodes")
                        .HasForeignKey("OwnerEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.Product", "Product")
                        .WithMany("Nodes")
                        .HasForeignKey("ProductCode");
                });

            modelBuilder.Entity("act.core.data.Port", b =>
                {
                    b.HasOne("act.core.data.BuildSpecification", "BuildSpecification")
                        .WithMany("Ports")
                        .HasForeignKey("BuildSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.Justification", "Justification")
                        .WithMany("Ports")
                        .HasForeignKey("JustificationId");
                });

            modelBuilder.Entity("act.core.data.SoftwareComponent", b =>
                {
                    b.HasOne("act.core.data.BuildSpecification", "BuildSpecification")
                        .WithMany("SoftwareComponents")
                        .HasForeignKey("BuildSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.Justification", "Justification")
                        .WithMany("SoftwareComponents")
                        .HasForeignKey("JustificationId");
                });

            modelBuilder.Entity("act.core.data.SoftwareComponentEnvironment", b =>
                {
                    b.HasOne("act.core.data.Environment", "Environment")
                        .WithMany("SoftwareComponentEnvironments")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("act.core.data.SoftwareComponent", "SoftwareComponent")
                        .WithMany("SoftwareComponentEnvironments")
                        .HasForeignKey("SoftwareComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
